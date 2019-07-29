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
            this.button_SetCustomerRootDir = new System.Windows.Forms.Button();
            this.button_SetStorageDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_RootCustomerDirPath
            // 
            this.textBox_RootCustomerDirPath.Location = new System.Drawing.Point(111, 6);
            this.textBox_RootCustomerDirPath.Name = "textBox_RootCustomerDirPath";
            this.textBox_RootCustomerDirPath.Size = new System.Drawing.Size(258, 20);
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
            this.tb_CustomerStoragePath.Size = new System.Drawing.Size(258, 20);
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
            // button_SetCustomerRootDir
            // 
            this.button_SetCustomerRootDir.Location = new System.Drawing.Point(375, 4);
            this.button_SetCustomerRootDir.Name = "button_SetCustomerRootDir";
            this.button_SetCustomerRootDir.Size = new System.Drawing.Size(75, 23);
            this.button_SetCustomerRootDir.TabIndex = 4;
            this.button_SetCustomerRootDir.Text = "Set";
            this.button_SetCustomerRootDir.UseVisualStyleBackColor = true;
            this.button_SetCustomerRootDir.Click += new System.EventHandler(this.Button_SetCustomerRootDir_Click);
            // 
            // button_SetStorageDir
            // 
            this.button_SetStorageDir.Location = new System.Drawing.Point(375, 30);
            this.button_SetStorageDir.Name = "button_SetStorageDir";
            this.button_SetStorageDir.Size = new System.Drawing.Size(75, 23);
            this.button_SetStorageDir.TabIndex = 5;
            this.button_SetStorageDir.Text = "Set";
            this.button_SetStorageDir.UseVisualStyleBackColor = true;
            this.button_SetStorageDir.Click += new System.EventHandler(this.Button_SetStorageDir_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 167);
            this.Controls.Add(this.button_SetStorageDir);
            this.Controls.Add(this.button_SetCustomerRootDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_CustomerStoragePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_RootCustomerDirPath);
            this.Name = "SetupForm";
            this.Text = "SetupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RootCustomerDirPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_CustomerStoragePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_SetCustomerRootDir;
        private System.Windows.Forms.Button button_SetStorageDir;
    }
}