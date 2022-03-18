
namespace LanguageLearningApp
{
    partial class FormMain
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
            this.lblCreateWord = new System.Windows.Forms.Label();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnClearWord = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvWords = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCreateWord
            // 
            this.lblCreateWord.AutoSize = true;
            this.lblCreateWord.Location = new System.Drawing.Point(187, 29);
            this.lblCreateWord.Name = "lblCreateWord";
            this.lblCreateWord.Size = new System.Drawing.Size(75, 20);
            this.lblCreateWord.TabIndex = 0;
            this.lblCreateWord.Text = "Add word";
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(79, 52);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(304, 27);
            this.tbWord.TabIndex = 1;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(93, 85);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(117, 31);
            this.btnAddWord.TabIndex = 2;
            this.btnAddWord.Text = "Add";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnClearWord
            // 
            this.btnClearWord.Location = new System.Drawing.Point(238, 85);
            this.btnClearWord.Name = "btnClearWord";
            this.btnClearWord.Size = new System.Drawing.Size(117, 31);
            this.btnClearWord.TabIndex = 3;
            this.btnClearWord.Text = "Clear";
            this.btnClearWord.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbWord);
            this.panel1.Controls.Add(this.btnClearWord);
            this.panel1.Controls.Add(this.lblCreateWord);
            this.panel1.Controls.Add(this.btnAddWord);
            this.panel1.Location = new System.Drawing.Point(12, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 143);
            this.panel1.TabIndex = 4;
            // 
            // dgvWords
            // 
            this.dgvWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWords.Location = new System.Drawing.Point(12, 75);
            this.dgvWords.Name = "dgvWords";
            this.dgvWords.RowHeadersWidth = 51;
            this.dgvWords.RowTemplate.Height = 29;
            this.dgvWords.Size = new System.Drawing.Size(454, 143);
            this.dgvWords.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 224);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(210, 29);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(250, 224);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(216, 29);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "View detailed info";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 505);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvWords);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "Main form";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCreateWord;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnClearWord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvWords;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
    }
}

