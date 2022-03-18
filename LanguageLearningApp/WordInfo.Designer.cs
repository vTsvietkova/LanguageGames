
namespace LanguageLearningApp
{
    partial class WordInfo
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
            this.btnDeleteDef = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.dgvDefinitions = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbPartOfSpeach = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDefinition = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHits = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefinitions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteDef
            // 
            this.btnDeleteDef.Location = new System.Drawing.Point(33, 248);
            this.btnDeleteDef.Name = "btnDeleteDef";
            this.btnDeleteDef.Size = new System.Drawing.Size(144, 29);
            this.btnDeleteDef.TabIndex = 0;
            this.btnDeleteDef.Text = "Delete";
            this.btnDeleteDef.UseVisualStyleBackColor = true;
            this.btnDeleteDef.Click += new System.EventHandler(this.btnDeleteDef_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(265, 248);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(144, 29);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // dgvDefinitions
            // 
            this.dgvDefinitions.AllowUserToAddRows = false;
            this.dgvDefinitions.AllowUserToDeleteRows = false;
            this.dgvDefinitions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefinitions.Location = new System.Drawing.Point(12, 28);
            this.dgvDefinitions.Name = "dgvDefinitions";
            this.dgvDefinitions.ReadOnly = true;
            this.dgvDefinitions.RowHeadersWidth = 51;
            this.dgvDefinitions.RowTemplate.Height = 29;
            this.dgvDefinitions.Size = new System.Drawing.Size(660, 214);
            this.dgvDefinitions.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(497, 248);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 29);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbPartOfSpeach
            // 
            this.cbPartOfSpeach.FormattingEnabled = true;
            this.cbPartOfSpeach.Location = new System.Drawing.Point(126, 304);
            this.cbPartOfSpeach.Name = "cbPartOfSpeach";
            this.cbPartOfSpeach.Size = new System.Drawing.Size(144, 28);
            this.cbPartOfSpeach.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Part of speach";
            // 
            // tbDefinition
            // 
            this.tbDefinition.Location = new System.Drawing.Point(18, 393);
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.Size = new System.Drawing.Size(252, 57);
            this.tbDefinition.TabIndex = 6;
            this.tbDefinition.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Definition";
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(18, 456);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(252, 29);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "Commit changes";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hits";
            // 
            // tbHits
            // 
            this.tbHits.Location = new System.Drawing.Point(126, 338);
            this.tbHits.Name = "tbHits";
            this.tbHits.Size = new System.Drawing.Size(146, 27);
            this.tbHits.TabIndex = 10;
            // 
            // WordInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 495);
            this.Controls.Add(this.tbHits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDefinition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPartOfSpeach);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvDefinitions);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnDeleteDef);
            this.Name = "WordInfo";
            this.Text = "WordInfo";
            this.Load += new System.EventHandler(this.WordInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefinitions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteDef;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.DataGridView dgvDefinitions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbPartOfSpeach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tbDefinition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHits;
    }
}