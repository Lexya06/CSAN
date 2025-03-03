using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using MyList;
using System.Security.Cryptography;
using System.Threading;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;
using System.Net.Http;


namespace DevicesInNetwork
{
   
    public partial class DevicesInUserNet : Form
    {
        userNetInterfaces uNet;
        
        public DevicesInUserNet()
        {
            InitializeComponent();
            uNet = new userNetInterfaces(NetworkInterface.GetAllNetworkInterfaces().Where(ni => ni.GetIPProperties().UnicastAddresses.Any(ip => userNetInterfaces.interfaceSettings.isLocalNetSubC(ip.Address))).ToArray());
            NetworkInterface[] adapters = uNet.allUserInterfaces;
            foreach(NetworkInterface adapter in adapters)
            {
                cbUserInterfaces.Items.Add(adapter.Name);
            }
            
            cbUserInterfaces.SelectedIndex = 0;
            dgvDevicesInNetInfo.ColumnCount = 3;
            
            dgvDevicesInNetInfo.Columns[0].Name = "Ip";
            dgvDevicesInNetInfo.Columns[1].Name = "MAC-адрес";
            dgvDevicesInNetInfo.Columns[2].Name = "Порты";

            dgvInterfaceParams.ColumnCount = 3;
            dgvInterfaceParams.Columns[0].Name = "Ip";
            dgvInterfaceParams.Columns[1].Name = "MAC-адрес";
            dgvInterfaceParams.Columns[2].Name = "Порты";

           

            string iPHostEntry = Dns.GetHostName();
            tbHostName.Text = iPHostEntry;
            tbHostName.ReadOnly = true;
            

        }



        


        private void cbChooseInterface_CheckedChanged(object sender, EventArgs e)
        {
            dgvInterfaceParams.Rows.Clear();
            dgvDevicesInNetInfo.Rows.Clear();
            if (cbChooseInterface.Checked)
            {
                
                cbChooseInterface.Enabled = false;
                NetworkInterface interested = uNet.getInterfaceByName(cbUserInterfaces.SelectedItem.ToString());
                int ind = dgvInterfaceParams.Rows.Add();
                


                UnicastIPAddressInformation infoIP = interested.GetIPProperties().UnicastAddresses.FirstOrDefault(ipv4 => ipv4.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                if (infoIP != null)
                {
                    
                    IPAddress interestedIP = infoIP.Address;
                    dgvInterfaceParams[0, ind].Value = interestedIP;
                    dgvInterfaceParams[1, ind].Value = interested.GetPhysicalAddress();
                    IPAddress interestedMask = infoIP.IPv4Mask;
                    Network thisNet = new Network(interestedIP, interestedMask);
                    SemaphoreSlim semaphore = new SemaphoreSlim(1);
                    thisNet.getPortsToDevice(interestedIP, 0, dgvInterfaceParams, semaphore);
                    thisNet.getOnlineDevs(dgvDevicesInNetInfo, thisNet.getIpDeviceNum(interestedIP, thisNet.getDeviceBits(thisNet.CountAllDevs)),cbChooseInterface);
                          
                }

                

                


            }
        }

        

        
    }



    public class userNetInterfaces
    {
        public class interfaceSettings
        {
            static internal bool isLocalNetSubC(IPAddress ip)
            {
                return ip.ToString().Contains("192.168");
            }
            
        }
        public NetworkInterface[] allUserInterfaces { get; set; }


       
        public NetworkInterface getInterfaceByName(string interfaceName)
        {
            int i = 0;
            bool flag = false;
            int countInterfaces = allUserInterfaces.Length;
            for (; i < countInterfaces && !flag; i++)
            {
                if (allUserInterfaces[i].Name == interfaceName)
                {
                    flag = true;
                }
            }
            i--;
            return allUserInterfaces[i];
        }
        
        public userNetInterfaces(NetworkInterface[] networkInterfaces)
        {
            allUserInterfaces = networkInterfaces;
        }
       
    }

    public struct Host
    {
        public IPAddress Ip { get; set; }
        public string MAC { get; set; }

    }
    
    public class Network
    {
        MyList<Host> devices;

        

        private void FindPortsWithNMap(IPAddress ip,MyList<int>ports)
        {
            
            string stringIp = ip.ToString();
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", $"/c nmap -F {stringIp}");
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.CreateNoWindow = true;
            string output;
            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                string[] lines = output.Split(new[] { "\r\n" }, StringSplitOptions.None);
                int length = lines.Length;
                int i = 0;
                while (i < length){
                    if (lines[i].Contains("open"))
                    {
                        string[] parseToNum = lines[i].Split('/');
                        ports.Add(Convert.ToInt32(parseToNum[0]));
                    }
                    i++;   
                }
                
            }
            
        }
        public void getPortsToDevice(IPAddress ip,int ind,DataGridView dgv,SemaphoreSlim semaphore)
        {

            // protocol - TCP
            semaphore.Wait();
            MyList<int> ports = new MyList<int>();
            
            FindPortsWithNMap(ip,ports);
            string stringWithPorts = String.Join(", ",ports.toArray());
            lock (dgv)
            {
                dgv.Invoke((Action)(() => { dgv[2, ind].Value = stringWithPorts; }));
               
            }
            semaphore.Release();


        }
        
         private void prepareDevice(MyList<Host> list, byte[] prefixBytes,int deviceNum, SemaphoreSlim semaphore, DataGridView dlv)
         {
            int bytesCount = prefixBytes.Length;
            byte[] factIP = new byte[bytesCount];
            byte[] arrNum = BitConverter.GetBytes(deviceNum);
            Array.Reverse(arrNum);
            for (int j = 0; j < bytesCount; j++)
            {
                factIP[j] = (byte)(arrNum[j] | prefixBytes[j]);
            }
            IPAddress ip = new IPAddress(factIP);


            semaphore.Wait();
            
            Ping ping = new Ping();
            PingReply reply;
            try
            {
                reply = ping.Send(ip);
                if (reply.Status == IPStatus.Success)
                {
                   
                    string macAddr = getMacAddress(ip);
                    Host host = new Host();
                    host.Ip = ip;
                    host.MAC = macAddr;
                    lock (list)
                    {
                        list.Add(host);
                    }

                    lock (dlv)
                    {
                        int ind = 0;
                        dlv.Invoke((Action)(() =>
                        {
                            ind = dlv.Rows.Add();
                            
                            dlv[0, ind].Value = host.Ip.ToString();
                            dlv[1, ind].Value = host.MAC;
                        }));
                        Task.Run(() => { getPortsToDevice(ip, ind, dlv,semaphore); });
                    }
                        
                    


                }

            }
            finally
            {
                semaphore.Release();
            }
           
        
            
            

         }

       
        private string getMacAddress(IPAddress ip)
        {
            string stringIp = ip.ToString();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe",$"/c arp -a {stringIp}");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            string output;
            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();


                
                string[] lines = output.Split(new[] { "\r\n" },StringSplitOptions.None);
                bool flag = false;
                string[] ipParts = null;
                int length = lines.Length;
                for (int i = 0; i < length && !flag; i++)
                {
                    if (lines[i].Contains(stringIp))
                    {
                        ipParts = lines[i].Split(new[] {" "},StringSplitOptions.RemoveEmptyEntries);
                        flag = true;
                    }
                }
                if (ipParts == null)
                {
                    return null;
                }
                return ipParts[1];
            }
        }
        
        public async void getOnlineDevs(DataGridView dgv,int interfaceNum,CheckBox chb)
        {
            
            devices = new MyList<Host>();
            SemaphoreSlim semaphore = new SemaphoreSlim(0,30);
            List<Task> tasks = new List<Task>();
            
            byte[] prefixBytes = PrefixNet.GetAddressBytes();
            int bytesCount = prefixBytes.Length;

            await Task.Run(() =>
            {
                for (int i = 1; i < interfaceNum; i++)
                {
                    int currentIndex = i;
                    tasks.Add( Task.Run(() => prepareDevice(devices, prefixBytes, currentIndex, semaphore, dgv)));
                }
                for (int i = interfaceNum + 1; i < CountAllDevs - 1; i++)
                {
                    int currentIndex = i;
                    tasks.Add(Task.Run(() => prepareDevice(devices, prefixBytes, currentIndex, semaphore, dgv)));
                }

            });
            
          
            semaphore.Release(30);
            await Task.WhenAll(tasks);
            chb.Invoke((Action)(()=>{ chb.Enabled = true; }));
            

        }
        private void getPrefixNet()
        {
            
            byte[] ip = Ip.GetAddressBytes();
            byte[] mask = Mask.GetAddressBytes();
            int ipLength = ip.Length;
            byte[] first = new byte[ipLength];
            for (int i = 0; i < ipLength; i++)
            {
                first[i] = (byte)(ip[i] & mask[i]);
            }
            PrefixNet = new IPAddress(first);
           
            
        }

        public int getIpDeviceNum(IPAddress ip,int deviceBits)
        {
            int pred = 1;
            int mask = 0;
            for (int i = 0; i < deviceBits; i++)
            {
                mask = mask | pred;
                pred = mask;
                mask <<= 1;
                
            }
            byte[]maskBytes = BitConverter.GetBytes(pred);
            Array.Reverse(maskBytes);
            byte[] ipBytes = ip.GetAddressBytes();
            int length = ipBytes.Length;
            byte[] resBytes = new byte[length];
            
            for (int i = 0; i < length; i++)
            {
                resBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
                
            }
            int sum = 0;
            int mnozh = 1;
            for (int i = length - 1; i >= 0; i--)
            {
                sum += resBytes[i] * mnozh;
                mnozh *= 256;

            }
            return sum;

            

        }
        public int getDeviceBits(int deviceKol)
        {
            int answer = 1;
            int temp = 2;
            while (temp < deviceKol)
            {
                temp <<= 1;
                answer++;
            }
            return answer;
        }
        public int getAllDevices(IPAddress interestedMask)
        {
            byte[] maskBytes = interestedMask.GetAddressBytes();
            int lastInd = maskBytes.Length - 1;
            int zeroBits = 0;
            bool flag = true;
            while (flag)
            {
                int diff = 0;
                byte temp = maskBytes[lastInd];
                while ((temp & 1) == 0 && diff != 8)
                {
                    temp >>= 1;
                    zeroBits++;
                    diff++;
                }
                if ((temp & 1) != 0)
                {
                    flag = false;
                }
                if (diff == 8)
                {
                    lastInd--;
                }
            }
            int devCount = 1;
            for (int i = zeroBits; i > 0; i--)
            {
                devCount <<= 1;
            }
            
            return devCount;

        }
        public int CountAllDevs {  get; set; }
        
        public IPAddress PrefixNet {  get; set; }
        public IPAddress Ip { get; }
        public IPAddress Mask { get; }
        public Network(IPAddress ip, IPAddress mask)
        {
            Ip = ip;
            Mask = mask;
            CountAllDevs = getAllDevices(Mask);
            getPrefixNet();
        }
    }
}
