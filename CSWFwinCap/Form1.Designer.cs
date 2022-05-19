namespace CSWFwinCap
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServerBTN = new System.Windows.Forms.Button();
            this.ClientBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerBTN
            // 
            this.ServerBTN.Location = new System.Drawing.Point(397, 226);
            this.ServerBTN.Name = "ServerBTN";
            this.ServerBTN.Size = new System.Drawing.Size(75, 91);
            this.ServerBTN.TabIndex = 1;
            this.ServerBTN.Text = "Server";
            this.ServerBTN.UseVisualStyleBackColor = true;
            this.ServerBTN.Click += new System.EventHandler(this.ServerBTN_Click);
            // 
            // ClientBTN
            // 
            this.ClientBTN.Location = new System.Drawing.Point(221, 213);
            this.ClientBTN.Name = "ClientBTN";
            this.ClientBTN.Size = new System.Drawing.Size(75, 116);
            this.ClientBTN.TabIndex = 2;
            this.ClientBTN.Text = "Client";
            this.ClientBTN.UseVisualStyleBackColor = true;
            this.ClientBTN.Click += new System.EventHandler(this.ClientBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClientBTN);
            this.Controls.Add(this.ServerBTN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private Button ServerBTN;
        private Button ClientBTN;
    }
}