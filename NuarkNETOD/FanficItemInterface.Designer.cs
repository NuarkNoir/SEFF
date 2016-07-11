namespace NuarkNETOD
{
    partial class FanficItemInterface
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fb2download = new System.Windows.Forms.Button();
            this.htmldownload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FID = new System.Windows.Forms.Label();
            this.words = new System.Windows.Forms.Label();
            this.reads = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fb2download
            // 
            this.fb2download.Enabled = false;
            this.fb2download.Location = new System.Drawing.Point(315, 20);
            this.fb2download.Name = "fb2download";
            this.fb2download.Size = new System.Drawing.Size(47, 30);
            this.fb2download.TabIndex = 0;
            this.fb2download.Text = "FB2";
            this.fb2download.UseVisualStyleBackColor = true;
            this.fb2download.Click += new System.EventHandler(this.fb2download_Click);
            // 
            // htmldownload
            // 
            this.htmldownload.Enabled = false;
            this.htmldownload.Location = new System.Drawing.Point(262, 20);
            this.htmldownload.Name = "htmldownload";
            this.htmldownload.Size = new System.Drawing.Size(47, 30);
            this.htmldownload.TabIndex = 1;
            this.htmldownload.Text = "HTML";
            this.htmldownload.UseVisualStyleBackColor = true;
            this.htmldownload.Click += new System.EventHandler(this.htmldownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(140, 3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(37, 13);
            this.title.TabIndex = 3;
            this.title.Text = "#title#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Слов:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID:";
            // 
            // FID
            // 
            this.FID.AutoSize = true;
            this.FID.Location = new System.Drawing.Point(19, 3);
            this.FID.Name = "FID";
            this.FID.Size = new System.Drawing.Size(29, 13);
            this.FID.TabIndex = 6;
            this.FID.Text = "#id#";
            // 
            // words
            // 
            this.words.AutoSize = true;
            this.words.Location = new System.Drawing.Point(33, 20);
            this.words.Name = "words";
            this.words.Size = new System.Drawing.Size(49, 13);
            this.words.TabIndex = 7;
            this.words.Text = "#words#";
            // 
            // reads
            // 
            this.reads.AutoSize = true;
            this.reads.Location = new System.Drawing.Point(127, 20);
            this.reads.Name = "reads";
            this.reads.Size = new System.Drawing.Size(47, 13);
            this.reads.TabIndex = 9;
            this.reads.Text = "#reads#";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Чтений:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Рейтинг:";
            // 
            // rate
            // 
            this.rate.AutoSize = true;
            this.rate.Location = new System.Drawing.Point(49, 37);
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(39, 13);
            this.rate.TabIndex = 11;
            this.rate.Text = "#rate#";
            // 
            // FanficItemInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.rate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.reads);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.words);
            this.Controls.Add(this.FID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.htmldownload);
            this.Controls.Add(this.fb2download);
            this.Name = "FanficItemInterface";
            this.Size = new System.Drawing.Size(363, 53);
            this.Load += new System.EventHandler(this.FContr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fb2download;
        private System.Windows.Forms.Button htmldownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FID;
        private System.Windows.Forms.Label words;
        private System.Windows.Forms.Label reads;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label rate;
    }
}
