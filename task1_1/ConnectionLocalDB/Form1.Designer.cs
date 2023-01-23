namespace ConnectionLocalDB
{
    partial class ConnectLocalDB
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
            this.territoriesListBox = new System.Windows.Forms.ListBox();
            this.territoryDescTextBox = new System.Windows.Forms.TextBox();
            this.territoryLabel = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // territoriesListBox
            // 
            this.territoriesListBox.FormattingEnabled = true;
            this.territoriesListBox.ItemHeight = 75;
            this.territoriesListBox.Location = new System.Drawing.Point(160, 262);
            this.territoriesListBox.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.territoriesListBox.Name = "territoriesListBox";
            this.territoriesListBox.Size = new System.Drawing.Size(922, 154);
            this.territoriesListBox.TabIndex = 0;
            // 
            // territoryDescTextBox
            // 
            this.territoryDescTextBox.Location = new System.Drawing.Point(467, 72);
            this.territoryDescTextBox.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.territoryDescTextBox.Name = "territoryDescTextBox";
            this.territoryDescTextBox.Size = new System.Drawing.Size(615, 83);
            this.territoryDescTextBox.TabIndex = 1;
            // 
            // territoryLabel
            // 
            this.territoryLabel.AutoSize = true;
            this.territoryLabel.Location = new System.Drawing.Point(147, 81);
            this.territoryLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.territoryLabel.Name = "territoryLabel";
            this.territoryLabel.Size = new System.Drawing.Size(230, 75);
            this.territoryLabel.TabIndex = 2;
            this.territoryLabel.Text = "Territory";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(727, 173);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(355, 71);
            this.searchBtn.TabIndex = 3;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // ConnectLocalDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(28F, 75F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 729);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.territoryLabel);
            this.Controls.Add(this.territoryDescTextBox);
            this.Controls.Add(this.territoriesListBox);
            this.Font = new System.Drawing.Font("Segoe Print", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.Name = "ConnectLocalDB";
            this.Text = "ConnectionLocalDb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox territoriesListBox;
        private System.Windows.Forms.TextBox territoryDescTextBox;
        private System.Windows.Forms.Label territoryLabel;
        private System.Windows.Forms.Button searchBtn;
    }
}

