namespace xytextreader
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TB_Path = new System.Windows.Forms.TextBox();
            this.B_Open = new System.Windows.Forms.Button();
            this.B_DiffPaths = new System.Windows.Forms.Button();
            this.CHK_Readable = new System.Windows.Forms.CheckBox();
            this.B_Parse = new System.Windows.Forms.Button();
            this.CHK_AutoSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 72);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(645, 391);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // TB_Path
            // 
            this.TB_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Path.Location = new System.Drawing.Point(12, 17);
            this.TB_Path.Name = "TB_Path";
            this.TB_Path.ReadOnly = true;
            this.TB_Path.Size = new System.Drawing.Size(606, 20);
            this.TB_Path.TabIndex = 1;
            // 
            // B_Open
            // 
            this.B_Open.Location = new System.Drawing.Point(12, 43);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(75, 23);
            this.B_Open.TabIndex = 2;
            this.B_Open.Text = "Open";
            this.B_Open.UseVisualStyleBackColor = true;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // B_DiffPaths
            // 
            this.B_DiffPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_DiffPaths.Location = new System.Drawing.Point(624, 15);
            this.B_DiffPaths.Name = "B_DiffPaths";
            this.B_DiffPaths.Size = new System.Drawing.Size(33, 23);
            this.B_DiffPaths.TabIndex = 3;
            this.B_DiffPaths.Text = "diff";
            this.B_DiffPaths.UseVisualStyleBackColor = true;
            this.B_DiffPaths.Click += new System.EventHandler(this.B_TextDiff_Click);
            // 
            // CHK_Readable
            // 
            this.CHK_Readable.AutoSize = true;
            this.CHK_Readable.Location = new System.Drawing.Point(93, 47);
            this.CHK_Readable.Name = "CHK_Readable";
            this.CHK_Readable.Size = new System.Drawing.Size(91, 17);
            this.CHK_Readable.TabIndex = 4;
            this.CHK_Readable.Text = "Remove \\r,\\n";
            this.CHK_Readable.UseVisualStyleBackColor = true;
            // 
            // B_Parse
            // 
            this.B_Parse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Parse.Location = new System.Drawing.Point(560, 41);
            this.B_Parse.Name = "B_Parse";
            this.B_Parse.Size = new System.Drawing.Size(97, 23);
            this.B_Parse.TabIndex = 5;
            this.B_Parse.Text = "Parse";
            this.B_Parse.UseVisualStyleBackColor = true;
            this.B_Parse.Click += new System.EventHandler(this.B_Parse_Click);
            // 
            // CHK_AutoSave
            // 
            this.CHK_AutoSave.AutoSize = true;
            this.CHK_AutoSave.Location = new System.Drawing.Point(190, 47);
            this.CHK_AutoSave.Name = "CHK_AutoSave";
            this.CHK_AutoSave.Size = new System.Drawing.Size(97, 17);
            this.CHK_AutoSave.TabIndex = 6;
            this.CHK_AutoSave.Text = "AutoSave Text";
            this.CHK_AutoSave.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 475);
            this.Controls.Add(this.CHK_AutoSave);
            this.Controls.Add(this.B_Parse);
            this.Controls.Add(this.CHK_Readable);
            this.Controls.Add(this.B_DiffPaths);
            this.Controls.Add(this.B_Open);
            this.Controls.Add(this.TB_Path);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "xytext";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox TB_Path;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_DiffPaths;
        private System.Windows.Forms.CheckBox CHK_Readable;
        private System.Windows.Forms.Button B_Parse;
        private System.Windows.Forms.CheckBox CHK_AutoSave;
    }
}

