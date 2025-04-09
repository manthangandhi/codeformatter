namespace CodeFormatterApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.TextBox txtFormattedCode;
        private System.Windows.Forms.Button btnFormat;
        private Button btnCopyFormatted = new Button();
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFormMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactMenuItem;
        private System.Windows.Forms.Label lblSourceCode;
        private System.Windows.Forms.Label lblFormattedCode;

        private ToolStripMenuItem fileMenuItem = new ToolStripMenuItem("File");
        private ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open");
        private ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save Formatted Code");


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFormMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.txtFormattedCode = new System.Windows.Forms.TextBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblSourceCode = new System.Windows.Forms.Label();
            this.lblFormattedCode = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.settingsMenuItem,
                this.clearFormMenuItem,
                this.contactMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            this.menuStrip.BackColor = Color.Black;
            this.menuStrip.ForeColor = Color.White;
            this.menuStrip.Renderer = new CustomMenuRenderer();

            // file menu
            this.menuStrip.Items.Insert(0, this.fileMenuItem);
            this.fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.openMenuItem, this.saveMenuItem });
            this.openMenuItem.Click += new EventHandler(this.openMenuItem_Click);
            this.saveMenuItem.Click += new EventHandler(this.saveMenuItem_Click);
           
            // clearFormMenuItem
            this.clearFormMenuItem.Name = "clearFormMenuItem";
            this.clearFormMenuItem.Size = new System.Drawing.Size(77, 20);
            this.clearFormMenuItem.Text = "Clear Form";
            this.clearFormMenuItem.Click += new System.EventHandler(this.clearFormMenuItem_Click);

            // contactMenuItem
            this.contactMenuItem.Name = "contactMenuItem";
            this.contactMenuItem.Size = new System.Drawing.Size(81, 20);
            this.contactMenuItem.Text = "About";
            this.contactMenuItem.Click += new System.EventHandler(this.contactMenuItem_Click);

            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.lblLanguage, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.cbLanguage, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnFormat, 2, 0); 
            // this.tableLayoutPanel.Controls.Add(this.btnCopyFormatted, 3, 0); 
            this.tableLayoutPanel.Controls.Add(this.lblSourceCode, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblFormattedCode, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.txtSourceCode, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.txtFormattedCode, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.progressBar, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.lblFooter, 0, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Increased from 30F to 50F
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 426);
            this.tableLayoutPanel.TabIndex = 1;

            // lblSourceCode
            this.lblSourceCode.AutoSize = true;
            this.lblSourceCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tableLayoutPanel.SetColumnSpan(this.lblSourceCode, 2);
            // this.lblSourceCode.Location = new System.Drawing.Point(100, 55); // Adjusted Y from 35 to 55 for more space
            this.lblSourceCode.Name = "lblSourceCode";
            this.lblSourceCode.Size = new System.Drawing.Size(394, 20);
            this.lblSourceCode.TabIndex = 4;
            this.lblSourceCode.Text = "Source Code";
            this.lblSourceCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSourceCode.Anchor = System.Windows.Forms.AnchorStyles.None;

            // txtSourceCode
            this.tableLayoutPanel.SetColumnSpan(this.txtSourceCode, 2);
            this.txtSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourceCode.Location = new System.Drawing.Point(3, 93); // Adjusted Y from 73 to 93
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceCode.Size = new System.Drawing.Size(394, 280); // Adjusted height from 300 to 280
            this.txtSourceCode.TabIndex = 0;
            this.txtSourceCode.MaxLength = 999999;
            this.txtSourceCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblFormattedCode
            this.lblFormattedCode.AutoSize = true;
            this.lblFormattedCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // this.lblFormattedCode.Location = new System.Drawing.Point(500, 55); // Adjusted Y from 35 to 55 for more space
            this.lblFormattedCode.Name = "lblFormattedCode";
            this.lblFormattedCode.Size = new System.Drawing.Size(294, 20);
            this.lblFormattedCode.TabIndex = 5;
            this.lblFormattedCode.Text = "Formatted Code";
            this.lblFormattedCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormattedCode.Anchor = System.Windows.Forms.AnchorStyles.None;

            // txtFormattedCode
            this.txtFormattedCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFormattedCode.Location = new System.Drawing.Point(403, 93); // Adjusted Y from 73 to 93
            this.txtFormattedCode.Multiline = true;
            this.txtFormattedCode.Name = "txtFormattedCode";
            this.txtFormattedCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFormattedCode.Size = new System.Drawing.Size(394, 280); // Adjusted height from 300 to 280
            this.txtFormattedCode.TabIndex = 1;
            this.txtFormattedCode.MaxLength = 999999;
            this.txtFormattedCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblLanguage
            this.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(35, 17); // Adjusted Y from 7 to 17
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(61, 15);
            this.lblLanguage.TabIndex = 2;
            this.lblLanguage.Text = "Language:";
            this.lblLanguage.Font = new System.Drawing.Font("Segoe UI", 9F);

            // cbLanguage
            this.cbLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] {
            "C#",
            "VB",
            "SQL"});
            this.cbLanguage.Location = new System.Drawing.Point(103, 13); // Adjusted Y from 3 to 13
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(125, 23);
            this.cbLanguage.TabIndex = 3;
            this.cbLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // this.cbLanguage.BackColor = System.Drawing.Color.Blue;
            this.cbLanguage.ForeColor = System.Drawing.Color.Black;
            
            // btnFormat
            this.btnFormat.Anchor = System.Windows.Forms.AnchorStyles.None; // Changed to Anchor Right
            this.btnFormat.Location = new System.Drawing.Point(710, 13); // Adjusted from (403, 41) to right side
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(75, 23);
            this.btnFormat.TabIndex = 6;
            this.btnFormat.Text = "Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            this.btnFormat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormat.BackColor = System.Drawing.Color.FromArgb(0, 112, 60);
            this.btnFormat.ForeColor = System.Drawing.Color.White;
            this.btnFormat.FlatAppearance.BorderSize = 0;

            // button copy
            this.btnCopyFormatted.Anchor = System.Windows.Forms.AnchorStyles.None; // Changed to Anchor Right
            this.btnCopyFormatted.Location = new System.Drawing.Point(710, 13); // Adjusted from (403, 41) to right side
            this.btnCopyFormatted.Text = "Copy";
            this.btnCopyFormatted.Size = new Size(75, 23);
            this.btnCopyFormatted.Location = new Point(710, 13);
            this.btnCopyFormatted.Click += new EventHandler(this.btnCopyFormatted_Click);
            this.btnCopyFormatted.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCopyFormatted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyFormatted.BackColor = System.Drawing.Color.FromArgb(0, 112, 60);
            this.btnCopyFormatted.ForeColor = System.Drawing.Color.White;
            this.btnCopyFormatted.FlatAppearance.BorderSize = 0;

            // progressBar
            this.tableLayoutPanel.SetColumnSpan(this.progressBar, 3);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 379);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(794, 14);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;

            // lblFooter
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFooter.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lblFooter, 3);
            this.lblFooter.Location = new System.Drawing.Point(280, 406);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(239, 15);
            this.lblFooter.TabIndex = 8;
            this.lblFooter.Text = "Made with ❤ by Manthan Gandhi";
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Code Formatter";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}