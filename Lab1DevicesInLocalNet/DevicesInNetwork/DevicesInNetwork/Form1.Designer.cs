namespace DevicesInNetwork
{
    partial class DevicesInUserNet
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbUserInterfaces = new System.Windows.Forms.ComboBox();
            this.lbChooseInterface = new System.Windows.Forms.Label();
            this.cbChooseInterface = new System.Windows.Forms.CheckBox();
            this.dgvDevicesInNetInfo = new System.Windows.Forms.DataGridView();
            this.dgvInterfaceParams = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHostName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevicesInNetInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaceParams)).BeginInit();
            this.SuspendLayout();
            // 
            // cbUserInterfaces
            // 
            this.cbUserInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserInterfaces.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbUserInterfaces.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbUserInterfaces.FormattingEnabled = true;
            this.cbUserInterfaces.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.cbUserInterfaces.Location = new System.Drawing.Point(23, 37);
            this.cbUserInterfaces.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUserInterfaces.Name = "cbUserInterfaces";
            this.cbUserInterfaces.Size = new System.Drawing.Size(235, 23);
            this.cbUserInterfaces.Sorted = true;
            this.cbUserInterfaces.TabIndex = 0;
            // 
            // lbChooseInterface
            // 
            this.lbChooseInterface.AutoSize = true;
            this.lbChooseInterface.BackColor = System.Drawing.Color.Yellow;
            this.lbChooseInterface.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbChooseInterface.Location = new System.Drawing.Point(28, 9);
            this.lbChooseInterface.Name = "lbChooseInterface";
            this.lbChooseInterface.Size = new System.Drawing.Size(218, 19);
            this.lbChooseInterface.TabIndex = 1;
            this.lbChooseInterface.Text = "Выберите сетевой интерфейс:";
            // 
            // cbChooseInterface
            // 
            this.cbChooseInterface.AutoSize = true;
            this.cbChooseInterface.Location = new System.Drawing.Point(264, 46);
            this.cbChooseInterface.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbChooseInterface.Name = "cbChooseInterface";
            this.cbChooseInterface.Size = new System.Drawing.Size(15, 14);
            this.cbChooseInterface.TabIndex = 3;
            this.cbChooseInterface.UseVisualStyleBackColor = true;
            this.cbChooseInterface.CheckedChanged += new System.EventHandler(this.cbChooseInterface_CheckedChanged);
            // 
            // dgvDevicesInNetInfo
            // 
            this.dgvDevicesInNetInfo.AllowUserToAddRows = false;
            this.dgvDevicesInNetInfo.AllowUserToDeleteRows = false;
            this.dgvDevicesInNetInfo.AllowUserToResizeColumns = false;
            this.dgvDevicesInNetInfo.AllowUserToResizeRows = false;
            this.dgvDevicesInNetInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevicesInNetInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDevicesInNetInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDevicesInNetInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvDevicesInNetInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevicesInNetInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDevicesInNetInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevicesInNetInfo.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDevicesInNetInfo.EnableHeadersVisualStyles = false;
            this.dgvDevicesInNetInfo.Location = new System.Drawing.Point(23, 155);
            this.dgvDevicesInNetInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDevicesInNetInfo.Name = "dgvDevicesInNetInfo";
            this.dgvDevicesInNetInfo.ReadOnly = true;
            this.dgvDevicesInNetInfo.RowHeadersVisible = false;
            this.dgvDevicesInNetInfo.RowHeadersWidth = 51;
            this.dgvDevicesInNetInfo.RowTemplate.Height = 24;
            this.dgvDevicesInNetInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDevicesInNetInfo.Size = new System.Drawing.Size(420, 141);
            this.dgvDevicesInNetInfo.TabIndex = 5;
            // 
            // dgvInterfaceParams
            // 
            this.dgvInterfaceParams.AllowUserToAddRows = false;
            this.dgvInterfaceParams.AllowUserToDeleteRows = false;
            this.dgvInterfaceParams.AllowUserToResizeColumns = false;
            this.dgvInterfaceParams.AllowUserToResizeRows = false;
            this.dgvInterfaceParams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInterfaceParams.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInterfaceParams.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInterfaceParams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInterfaceParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInterfaceParams.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInterfaceParams.EnableHeadersVisualStyles = false;
            this.dgvInterfaceParams.Location = new System.Drawing.Point(23, 94);
            this.dgvInterfaceParams.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvInterfaceParams.Name = "dgvInterfaceParams";
            this.dgvInterfaceParams.ReadOnly = true;
            this.dgvInterfaceParams.RowHeadersVisible = false;
            this.dgvInterfaceParams.RowHeadersWidth = 51;
            this.dgvInterfaceParams.RowTemplate.Height = 24;
            this.dgvInterfaceParams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvInterfaceParams.Size = new System.Drawing.Size(420, 42);
            this.dgvInterfaceParams.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ваш хост:";
            // 
            // tbHostName
            // 
            this.tbHostName.Location = new System.Drawing.Point(301, 37);
            this.tbHostName.Multiline = true;
            this.tbHostName.Name = "tbHostName";
            this.tbHostName.Size = new System.Drawing.Size(125, 36);
            this.tbHostName.TabIndex = 8;
            // 
            // DevicesInUserNet
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(464, 331);
            this.Controls.Add(this.tbHostName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvInterfaceParams);
            this.Controls.Add(this.dgvDevicesInNetInfo);
            this.Controls.Add(this.cbChooseInterface);
            this.Controls.Add(this.lbChooseInterface);
            this.Controls.Add(this.cbUserInterfaces);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DevicesInUserNet";
            this.Text = "DevicesInUserNet";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevicesInNetInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterfaceParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUserInterfaces;
        private System.Windows.Forms.Label lbChooseInterface;
        private System.Windows.Forms.CheckBox cbChooseInterface;
        public System.Windows.Forms.DataGridView dgvDevicesInNetInfo;
        public System.Windows.Forms.DataGridView dgvInterfaceParams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHostName;
    }
}

