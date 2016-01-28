namespace ycnotify
{
    partial class mainForm
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
            this.content = new System.Windows.Forms.WebBrowser();
            this.hideButton = new System.Windows.Forms.Button();
            this.minutesCombobox = new System.Windows.Forms.ComboBox();
            this.checkLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(12, 12);
            this.content.MinimumSize = new System.Drawing.Size(20, 20);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(636, 250);
            this.content.TabIndex = 3;
            this.content.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.content_DocumentCompleted);
            this.content.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.content_Navigated);
            // 
            // hideButton
            // 
            this.hideButton.Location = new System.Drawing.Point(573, 268);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(75, 23);
            this.hideButton.TabIndex = 4;
            this.hideButton.Text = "Hide";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // minutesCombobox
            // 
            this.minutesCombobox.FormattingEnabled = true;
            this.minutesCombobox.Items.AddRange(new object[] {
            "1 minute",
            "5 minutes",
            "10 minutes",
            "30 minutes",
            "1 hour"});
            this.minutesCombobox.Location = new System.Drawing.Point(446, 269);
            this.minutesCombobox.Name = "minutesCombobox";
            this.minutesCombobox.Size = new System.Drawing.Size(121, 21);
            this.minutesCombobox.TabIndex = 5;
            this.minutesCombobox.SelectedIndexChanged += new System.EventHandler(this.minutesCombobox_SelectedIndexChanged);
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.Location = new System.Drawing.Point(331, 273);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(109, 13);
            this.checkLabel.TabIndex = 6;
            this.checkLabel.Text = "Check YC HN every: ";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 294);
            this.Controls.Add(this.checkLabel);
            this.Controls.Add(this.minutesCombobox);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.content);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(676, 333);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(676, 333);
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "latest on YCombinator : Hacker News";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.WebBrowser content;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.ComboBox minutesCombobox;
        private System.Windows.Forms.Label checkLabel;
    }
}

