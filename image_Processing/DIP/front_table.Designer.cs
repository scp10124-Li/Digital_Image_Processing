namespace DIP
{
    partial class front_table
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBtoGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalFlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalFlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreeRotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreeRotationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(515, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stStripLabel
            // 
            this.stStripLabel.Name = "stStripLabel";
            this.stStripLabel.Size = new System.Drawing.Size(128, 17);
            this.stStripLabel.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.iPToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.histogramsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(515, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // iPToolStripMenuItem
            // 
            this.iPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBtoGrayToolStripMenuItem});
            this.iPToolStripMenuItem.Name = "iPToolStripMenuItem";
            this.iPToolStripMenuItem.Size = new System.Drawing.Size(29, 20);
            this.iPToolStripMenuItem.Text = "&IP";
            this.iPToolStripMenuItem.Click += new System.EventHandler(this.iPToolStripMenuItem_Click);
            // 
            // rGBtoGrayToolStripMenuItem
            // 
            this.rGBtoGrayToolStripMenuItem.Name = "rGBtoGrayToolStripMenuItem";
            this.rGBtoGrayToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.rGBtoGrayToolStripMenuItem.Text = "RGBtoGray";
            this.rGBtoGrayToolStripMenuItem.Click += new System.EventHandler(this.rGBtoGrayToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalFlipToolStripMenuItem,
            this.horizontalFlipToolStripMenuItem,
            this.degreeRotationToolStripMenuItem,
            this.degreeRotationToolStripMenuItem1});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.imageToolStripMenuItem.Text = "&image";
            // 
            // verticalFlipToolStripMenuItem
            // 
            this.verticalFlipToolStripMenuItem.Name = "verticalFlipToolStripMenuItem";
            this.verticalFlipToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.verticalFlipToolStripMenuItem.Text = "Vertical Flip";
            this.verticalFlipToolStripMenuItem.Click += new System.EventHandler(this.verticalFlipToolStripMenuItem_Click);
            // 
            // horizontalFlipToolStripMenuItem
            // 
            this.horizontalFlipToolStripMenuItem.Name = "horizontalFlipToolStripMenuItem";
            this.horizontalFlipToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.horizontalFlipToolStripMenuItem.Text = "Horizontal Flip";
            this.horizontalFlipToolStripMenuItem.Click += new System.EventHandler(this.horizontalFlipToolStripMenuItem_Click);
            // 
            // degreeRotationToolStripMenuItem
            // 
            this.degreeRotationToolStripMenuItem.Name = "degreeRotationToolStripMenuItem";
            this.degreeRotationToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.degreeRotationToolStripMenuItem.Text = "Counterclockwise_Rotation";
            this.degreeRotationToolStripMenuItem.Click += new System.EventHandler(this.degreeRotationToolStripMenuItem_Click_1);
            // 
            // degreeRotationToolStripMenuItem1
            // 
            this.degreeRotationToolStripMenuItem1.Name = "degreeRotationToolStripMenuItem1";
            this.degreeRotationToolStripMenuItem1.Size = new System.Drawing.Size(226, 22);
            this.degreeRotationToolStripMenuItem1.Text = "clockwise_Rotation";
            this.degreeRotationToolStripMenuItem1.Click += new System.EventHandler(this.degreeRotationToolStripMenuItem1_Click_1);
            // 
            // histogramsToolStripMenuItem
            // 
            this.histogramsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equalizationToolStripMenuItem,
            this.equalizationToolStripMenuItem1});
            this.histogramsToolStripMenuItem.Name = "histogramsToolStripMenuItem";
            this.histogramsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.histogramsToolStripMenuItem.Text = "property";
            this.histogramsToolStripMenuItem.Click += new System.EventHandler(this.histogramsToolStripMenuItem_Click);
            // 
            // equalizationToolStripMenuItem
            // 
            this.equalizationToolStripMenuItem.Name = "equalizationToolStripMenuItem";
            this.equalizationToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.equalizationToolStripMenuItem.Text = "Histograms";
            this.equalizationToolStripMenuItem.Click += new System.EventHandler(this.equalizationToolStripMenuItem_Click);
            // 
            // equalizationToolStripMenuItem1
            // 
            this.equalizationToolStripMenuItem1.Name = "equalizationToolStripMenuItem1";
            this.equalizationToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.equalizationToolStripMenuItem1.Text = "Equalization";
            this.equalizationToolStripMenuItem1.Click += new System.EventHandler(this.equalizationToolStripMenuItem1_Click);
            // 
            // oFileDlg
            // 
            this.oFileDlg.FileName = "openFileDialog1";
            // 
            // front_table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 448);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "front_table";
            this.Text = "B11217059";
            this.Load += new System.EventHandler(this.DIPSample_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stStripLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem rGBtoGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalFlipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalFlipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreeRotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreeRotationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem histogramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizationToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}