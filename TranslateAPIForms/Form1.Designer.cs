namespace TranslateAPIForms
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
            this.tbAuthkey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTransl = new System.Windows.Forms.Button();
            this.tbT2t = new System.Windows.Forms.TextBox();
            this.tbTransl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.LogOut = new System.Windows.Forms.TextBox();
            this.buttonTranslateAgenda = new System.Windows.Forms.Button();
            this.buttonTranslateInfo = new System.Windows.Forms.Button();
            this.buttonTranslateRoteiro = new System.Windows.Forms.Button();
            this.buttonTranslateTag = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTransl2 = new System.Windows.Forms.TextBox();
            this.tbTransl3 = new System.Windows.Forms.TextBox();
            this.tbTransl4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbAuthkey
            // 
            this.tbAuthkey.Location = new System.Drawing.Point(140, 11);
            this.tbAuthkey.Margin = new System.Windows.Forms.Padding(4);
            this.tbAuthkey.Name = "tbAuthkey";
            this.tbAuthkey.Size = new System.Drawing.Size(252, 22);
            this.tbAuthkey.TabIndex = 0;
            this.tbAuthkey.Text = "f25c0d27622240d29357a5fa0be7191e";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auth Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Text to Translate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Translation";
            // 
            // btnTransl
            // 
            this.btnTransl.Location = new System.Drawing.Point(285, 169);
            this.btnTransl.Margin = new System.Windows.Forms.Padding(4);
            this.btnTransl.Name = "btnTransl";
            this.btnTransl.Size = new System.Drawing.Size(107, 28);
            this.btnTransl.TabIndex = 6;
            this.btnTransl.Text = "TraduzirTexto";
            this.btnTransl.UseVisualStyleBackColor = true;
            this.btnTransl.Click += new System.EventHandler(this.btnTransl_Click);
            // 
            // tbT2t
            // 
            this.tbT2t.Location = new System.Drawing.Point(140, 50);
            this.tbT2t.Margin = new System.Windows.Forms.Padding(4);
            this.tbT2t.Multiline = true;
            this.tbT2t.Name = "tbT2t";
            this.tbT2t.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbT2t.Size = new System.Drawing.Size(252, 93);
            this.tbT2t.TabIndex = 7;
            // 
            // tbTransl
            // 
            this.tbTransl.Location = new System.Drawing.Point(427, 30);
            this.tbTransl.Margin = new System.Windows.Forms.Padding(4);
            this.tbTransl.Multiline = true;
            this.tbTransl.Name = "tbTransl";
            this.tbTransl.ReadOnly = true;
            this.tbTransl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTransl.Size = new System.Drawing.Size(312, 469);
            this.tbTransl.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Language";
            // 
            // cbLang
            // 
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Items.AddRange(new object[] {
            "en",
            "es"});
            this.cbLang.Location = new System.Drawing.Point(142, 165);
            this.cbLang.Margin = new System.Windows.Forms.Padding(4);
            this.cbLang.Name = "cbLang";
            this.cbLang.Size = new System.Drawing.Size(133, 24);
            this.cbLang.TabIndex = 10;
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(140, 474);
            this.LogOut.Margin = new System.Windows.Forms.Padding(4);
            this.LogOut.Multiline = true;
            this.LogOut.Name = "LogOut";
            this.LogOut.ReadOnly = true;
            this.LogOut.Size = new System.Drawing.Size(210, 39);
            this.LogOut.TabIndex = 11;
            // 
            // buttonTranslateAgenda
            // 
            this.buttonTranslateAgenda.Location = new System.Drawing.Point(142, 211);
            this.buttonTranslateAgenda.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTranslateAgenda.Name = "buttonTranslateAgenda";
            this.buttonTranslateAgenda.Size = new System.Drawing.Size(121, 28);
            this.buttonTranslateAgenda.TabIndex = 12;
            this.buttonTranslateAgenda.Text = "TraduzirAgenda";
            this.buttonTranslateAgenda.UseVisualStyleBackColor = true;
            this.buttonTranslateAgenda.Click += new System.EventHandler(this.buttonTranslateAgenda_Click);
            // 
            // buttonTranslateInfo
            // 
            this.buttonTranslateInfo.Location = new System.Drawing.Point(271, 211);
            this.buttonTranslateInfo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTranslateInfo.Name = "buttonTranslateInfo";
            this.buttonTranslateInfo.Size = new System.Drawing.Size(121, 28);
            this.buttonTranslateInfo.TabIndex = 13;
            this.buttonTranslateInfo.Text = "TraduzirInfo";
            this.buttonTranslateInfo.UseVisualStyleBackColor = true;
            this.buttonTranslateInfo.Click += new System.EventHandler(this.buttonTranslateInfo_Click);
            // 
            // buttonTranslateRoteiro
            // 
            this.buttonTranslateRoteiro.Location = new System.Drawing.Point(140, 247);
            this.buttonTranslateRoteiro.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTranslateRoteiro.Name = "buttonTranslateRoteiro";
            this.buttonTranslateRoteiro.Size = new System.Drawing.Size(121, 28);
            this.buttonTranslateRoteiro.TabIndex = 14;
            this.buttonTranslateRoteiro.Text = "TraduzirRoteiro";
            this.buttonTranslateRoteiro.UseVisualStyleBackColor = true;
            this.buttonTranslateRoteiro.Click += new System.EventHandler(this.buttonTranslateRoteiro_Click);
            // 
            // buttonTranslateTag
            // 
            this.buttonTranslateTag.Location = new System.Drawing.Point(269, 247);
            this.buttonTranslateTag.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTranslateTag.Name = "buttonTranslateTag";
            this.buttonTranslateTag.Size = new System.Drawing.Size(121, 28);
            this.buttonTranslateTag.TabIndex = 15;
            this.buttonTranslateTag.Text = "TraduzirTag";
            this.buttonTranslateTag.UseVisualStyleBackColor = true;
            this.buttonTranslateTag.Click += new System.EventHandler(this.buttonTranslateTag_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 217);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tables";
            // 
            // tbTransl2
            // 
            this.tbTransl2.Location = new System.Drawing.Point(747, 30);
            this.tbTransl2.Margin = new System.Windows.Forms.Padding(4);
            this.tbTransl2.Multiline = true;
            this.tbTransl2.Name = "tbTransl2";
            this.tbTransl2.ReadOnly = true;
            this.tbTransl2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTransl2.Size = new System.Drawing.Size(312, 469);
            this.tbTransl2.TabIndex = 17;
            // 
            // tbTransl3
            // 
            this.tbTransl3.Location = new System.Drawing.Point(1067, 30);
            this.tbTransl3.Margin = new System.Windows.Forms.Padding(4);
            this.tbTransl3.Multiline = true;
            this.tbTransl3.Name = "tbTransl3";
            this.tbTransl3.ReadOnly = true;
            this.tbTransl3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTransl3.Size = new System.Drawing.Size(312, 469);
            this.tbTransl3.TabIndex = 18;
            // 
            // tbTransl4
            // 
            this.tbTransl4.Location = new System.Drawing.Point(1387, 30);
            this.tbTransl4.Margin = new System.Windows.Forms.Padding(4);
            this.tbTransl4.Multiline = true;
            this.tbTransl4.Name = "tbTransl4";
            this.tbTransl4.ReadOnly = true;
            this.tbTransl4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTransl4.Size = new System.Drawing.Size(312, 469);
            this.tbTransl4.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1771, 526);
            this.Controls.Add(this.tbTransl4);
            this.Controls.Add(this.tbTransl3);
            this.Controls.Add(this.tbTransl2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonTranslateTag);
            this.Controls.Add(this.buttonTranslateRoteiro);
            this.Controls.Add(this.buttonTranslateInfo);
            this.Controls.Add(this.buttonTranslateAgenda);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.cbLang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTransl);
            this.Controls.Add(this.tbT2t);
            this.Controls.Add(this.btnTransl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAuthkey);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Api Translation Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAuthkey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTransl;
        private System.Windows.Forms.TextBox tbT2t;
        private System.Windows.Forms.TextBox tbTransl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.TextBox LogOut;
        private System.Windows.Forms.Button buttonTranslateAgenda;
        private System.Windows.Forms.Button buttonTranslateInfo;
        private System.Windows.Forms.Button buttonTranslateRoteiro;
        private System.Windows.Forms.Button buttonTranslateTag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTransl2;
        private System.Windows.Forms.TextBox tbTransl3;
        private System.Windows.Forms.TextBox tbTransl4;
    }
}

