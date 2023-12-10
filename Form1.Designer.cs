namespace NetworkProfilesCleaner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_2clean = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_2save = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_c2s = new System.Windows.Forms.Button();
            this.button_s2c = new System.Windows.Forms.Button();
            this.button_swap = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_backup = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.checkBox_mutiline = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(533, 223);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.listBox_2clean);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "To Clean";
            // 
            // listBox_2clean
            // 
            this.listBox_2clean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_2clean.FormattingEnabled = true;
            this.listBox_2clean.ItemHeight = 12;
            this.listBox_2clean.Location = new System.Drawing.Point(3, 17);
            this.listBox_2clean.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.listBox_2clean.Name = "listBox_2clean";
            this.listBox_2clean.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_2clean.Size = new System.Drawing.Size(234, 197);
            this.listBox_2clean.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.listBox_2save);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(289, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "To Save";
            // 
            // listBox_2save
            // 
            this.listBox_2save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_2save.FormattingEnabled = true;
            this.listBox_2save.ItemHeight = 12;
            this.listBox_2save.Location = new System.Drawing.Point(3, 17);
            this.listBox_2save.Name = "listBox_2save";
            this.listBox_2save.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_2save.Size = new System.Drawing.Size(235, 197);
            this.listBox_2save.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.button_c2s);
            this.flowLayoutPanel1.Controls.Add(this.button_s2c);
            this.flowLayoutPanel1.Controls.Add(this.button_swap);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(249, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(34, 78);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // button_c2s
            // 
            this.button_c2s.Location = new System.Drawing.Point(3, 3);
            this.button_c2s.Name = "button_c2s";
            this.button_c2s.Size = new System.Drawing.Size(30, 20);
            this.button_c2s.TabIndex = 0;
            this.button_c2s.Text = ">";
            this.button_c2s.UseVisualStyleBackColor = true;
            this.button_c2s.Click += new System.EventHandler(this.button_c2s_Click);
            // 
            // button_s2c
            // 
            this.button_s2c.Location = new System.Drawing.Point(3, 29);
            this.button_s2c.Name = "button_s2c";
            this.button_s2c.Size = new System.Drawing.Size(30, 20);
            this.button_s2c.TabIndex = 1;
            this.button_s2c.Text = "<";
            this.button_s2c.UseVisualStyleBackColor = true;
            this.button_s2c.Click += new System.EventHandler(this.button_s2c_Click);
            // 
            // button_swap
            // 
            this.button_swap.Location = new System.Drawing.Point(3, 55);
            this.button_swap.Name = "button_swap";
            this.button_swap.Size = new System.Drawing.Size(30, 20);
            this.button_swap.TabIndex = 2;
            this.button_swap.Text = "<>";
            this.button_swap.UseVisualStyleBackColor = true;
            this.button_swap.Click += new System.EventHandler(this.button_swap_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.button_refresh);
            this.flowLayoutPanel2.Controls.Add(this.button_clear);
            this.flowLayoutPanel2.Controls.Add(this.button_backup);
            this.flowLayoutPanel2.Controls.Add(this.button_open);
            this.flowLayoutPanel2.Controls.Add(this.checkBox_mutiline);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 229);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(533, 29);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(3, 3);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 0;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(84, 3);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 1;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_backup
            // 
            this.button_backup.Location = new System.Drawing.Point(165, 3);
            this.button_backup.Name = "button_backup";
            this.button_backup.Size = new System.Drawing.Size(75, 23);
            this.button_backup.TabIndex = 2;
            this.button_backup.Text = "Backup";
            this.button_backup.UseVisualStyleBackColor = true;
            this.button_backup.Click += new System.EventHandler(this.button_backup_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(246, 3);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(150, 23);
            this.button_open.TabIndex = 3;
            this.button_open.Text = "Open in Regedit.exe";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // checkBox_mutiline
            // 
            this.checkBox_mutiline.AutoSize = true;
            this.checkBox_mutiline.Location = new System.Drawing.Point(402, 3);
            this.checkBox_mutiline.Name = "checkBox_mutiline";
            this.checkBox_mutiline.Size = new System.Drawing.Size(90, 16);
            this.checkBox_mutiline.TabIndex = 4;
            this.checkBox_mutiline.Text = "MultiColumn";
            this.checkBox_mutiline.UseVisualStyleBackColor = true;
            this.checkBox_mutiline.CheckedChanged += new System.EventHandler(this.checkBox_mutiline_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(539, 261);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 261);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Form1";
            this.Text = "Network Profile Cleaner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_2clean;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_2save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button_c2s;
        private System.Windows.Forms.Button button_s2c;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_backup;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_swap;
        private System.Windows.Forms.CheckBox checkBox_mutiline;
    }
}

