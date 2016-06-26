namespace winDovizKurKaydedici
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKaydet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGrafikGoster = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVtSorgula = new System.Windows.Forms.Button();
            this.btnWebSorgula = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBitTar = new System.Windows.Forms.DateTimePicker();
            this.dtpBasTar = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.clbKurlar = new System.Windows.Forms.CheckedListBox();
            this.dgvSonuclar = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSonuclar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKaydet,
            this.btnGrafikGoster});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(152, 22);
            this.btnKaydet.Text = "Kaydet";
            // 
            // btnGrafikGoster
            // 
            this.btnGrafikGoster.Name = "btnGrafikGoster";
            this.btnGrafikGoster.Size = new System.Drawing.Size(152, 22);
            this.btnGrafikGoster.Text = "Grafik Göster";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnVtSorgula);
            this.panel1.Controls.Add(this.btnWebSorgula);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpBitTar);
            this.panel1.Controls.Add(this.dtpBasTar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 50);
            this.panel1.TabIndex = 5;
            // 
            // btnVtSorgula
            // 
            this.btnVtSorgula.Location = new System.Drawing.Point(666, 3);
            this.btnVtSorgula.Name = "btnVtSorgula";
            this.btnVtSorgula.Size = new System.Drawing.Size(75, 41);
            this.btnVtSorgula.TabIndex = 7;
            this.btnVtSorgula.Text = "VT Sorgula";
            this.btnVtSorgula.UseVisualStyleBackColor = true;
            this.btnVtSorgula.Click += new System.EventHandler(this.btnVtSorgula_Click);
            // 
            // btnWebSorgula
            // 
            this.btnWebSorgula.Location = new System.Drawing.Point(585, 3);
            this.btnWebSorgula.Name = "btnWebSorgula";
            this.btnWebSorgula.Size = new System.Drawing.Size(75, 41);
            this.btnWebSorgula.TabIndex = 7;
            this.btnWebSorgula.Text = "Web\'den Getir";
            this.btnWebSorgula.UseVisualStyleBackColor = true;
            this.btnWebSorgula.Click += new System.EventHandler(this.btnWebSorgula_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(291, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bitiş Tar. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Başl. Tar. :";
            // 
            // dtpBitTar
            // 
            this.dtpBitTar.Location = new System.Drawing.Point(368, 10);
            this.dtpBitTar.Name = "dtpBitTar";
            this.dtpBitTar.Size = new System.Drawing.Size(200, 23);
            this.dtpBitTar.TabIndex = 3;
            // 
            // dtpBasTar
            // 
            this.dtpBasTar.Location = new System.Drawing.Point(85, 10);
            this.dtpBasTar.Name = "dtpBasTar";
            this.dtpBasTar.Size = new System.Drawing.Size(200, 23);
            this.dtpBasTar.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.clbKurlar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvSonuclar);
            this.splitContainer1.Size = new System.Drawing.Size(753, 298);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 6;
            // 
            // clbKurlar
            // 
            this.clbKurlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbKurlar.FormattingEnabled = true;
            this.clbKurlar.Location = new System.Drawing.Point(0, 0);
            this.clbKurlar.Name = "clbKurlar";
            this.clbKurlar.Size = new System.Drawing.Size(148, 298);
            this.clbKurlar.TabIndex = 0;
            // 
            // dgvSonuclar
            // 
            this.dgvSonuclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSonuclar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSonuclar.Location = new System.Drawing.Point(0, 0);
            this.dgvSonuclar.Name = "dgvSonuclar";
            this.dgvSonuclar.Size = new System.Drawing.Size(601, 298);
            this.dgvSonuclar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 372);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Döviz Kur Kaydedici";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSonuclar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnWebSorgula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpBitTar;
        private System.Windows.Forms.DateTimePicker dtpBasTar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox clbKurlar;
        private System.Windows.Forms.DataGridView dgvSonuclar;
        private System.Windows.Forms.Button btnVtSorgula;
        private System.Windows.Forms.ToolStripMenuItem btnKaydet;
        private System.Windows.Forms.ToolStripMenuItem btnGrafikGoster;
    }
}

