namespace WindowsFormsApp1
{
    partial class HomeForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectKRCDiagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView_Customers = new System.Windows.Forms.ListView();
            this.Customers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(556, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectArchiveToolStripMenuItem,
            this.selectKRCDiagToolStripMenuItem,
            this.setupToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectArchiveToolStripMenuItem
            // 
            this.selectArchiveToolStripMenuItem.Name = "selectArchiveToolStripMenuItem";
            this.selectArchiveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectArchiveToolStripMenuItem.Text = "Select Archive";
            this.selectArchiveToolStripMenuItem.Click += new System.EventHandler(this.SelectArchiveToolStripMenuItem_Click);
            // 
            // selectKRCDiagToolStripMenuItem
            // 
            this.selectKRCDiagToolStripMenuItem.Name = "selectKRCDiagToolStripMenuItem";
            this.selectKRCDiagToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectKRCDiagToolStripMenuItem.Text = "Select KRCDiag";
            this.selectKRCDiagToolStripMenuItem.Click += new System.EventHandler(this.SelectKRCDiagToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.SetupToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // listView_Customers
            // 
            this.listView_Customers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Customers});
            this.listView_Customers.FullRowSelect = true;
            this.listView_Customers.GridLines = true;
            this.listView_Customers.Location = new System.Drawing.Point(0, 27);
            this.listView_Customers.Name = "listView_Customers";
            this.listView_Customers.Size = new System.Drawing.Size(189, 321);
            this.listView_Customers.TabIndex = 1;
            this.listView_Customers.UseCompatibleStateImageBehavior = false;
            this.listView_Customers.View = System.Windows.Forms.View.Details;
            this.listView_Customers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_Customers_ItemSelectionChanged);
            // 
            // Customers
            // 
            this.Customers.Text = "Customers";
            this.Customers.Width = 186;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 350);
            this.Controls.Add(this.listView_Customers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeForm";
            this.Text = "ArchiveStorer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectKRCDiagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ListView listView_Customers;
        private System.Windows.Forms.ColumnHeader Customers;
    }
}

