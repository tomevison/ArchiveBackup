namespace WindowsFormsApp1
{
    partial class SetupForm
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
            this.textBox_RootCustomerDirPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_CustomerStoragePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_SaveStorageDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_RootCustomerDirPath
            // 
            this.textBox_RootCustomerDirPath.Location = new System.Drawing.Point(111, 6);
            this.textBox_RootCustomerDirPath.Name = "textBox_RootCustomerDirPath";
            this.textBox_RootCustomerDirPath.Size = new System.Drawing.Size(272, 20);
            this.textBox_RootCustomerDirPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Root Dir";
            // 
            // tb_CustomerStoragePath
            // 
            this.tb_CustomerStoragePath.Location = new System.Drawing.Point(111, 32);
            this.tb_CustomerStoragePath.Name = "tb_CustomerStoragePath";
            this.tb_CustomerStoragePath.Size = new System.Drawing.Size(272, 20);
            this.tb_CustomerStoragePath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Storage Dir";
            // 
            // button_SaveStorageDir
            // 
            this.button_SaveStorageDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SaveStorageDir.Location = new System.Drawing.Point(308, 116);
            this.button_SaveStorageDir.Name = "button_SaveStorageDir";
            this.button_SaveStorageDir.Size = new System.Drawing.Size(75, 23);
            this.button_SaveStorageDir.TabIndex = 5;
            this.button_SaveStorageDir.Text = "Save";
            this.button_SaveStorageDir.UseVisualStyleBackColor = true;
            this.button_SaveStorageDir.Click += new System.EventHandler(this.Button_SaveStorageDir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "This will write entries to ArchiveBackup.Config.xml";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 151);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_SaveStorageDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_CustomerStoragePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_RootCustomerDirPath);
            this.Name = "SetupForm";
            this.Text = "Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RootCustomerDirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_CustomerStoragePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_SaveStorageDir;
        private System.Windows.Forms.Label label3;
    }
}