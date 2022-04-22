using Data.WordData;
using LanguageLearningLogic;
using LanguageLearningLogic.WordClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class FormMain : Form
    {
        WordManager wordManager = new(new WordDAL());
        Word Word;
        public List<Definition> definitions { get; set; }
        public FormMain()
        {
            InitializeComponent();
            wordManager = new(new WordDAL());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                dgvWords.DataSource = wordManager.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            try
            {
                Word word = new(tbWord.Text);
                int id = wordManager.Create(word);
                new WordInfo(id).Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            wordManager.DeleteWord(((Word)dgvWords.SelectedRows[0].DataBoundItem).Id);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            new WordInfo((Word)dgvWords.SelectedRows[0].DataBoundItem).Show();
        }
    }
}
