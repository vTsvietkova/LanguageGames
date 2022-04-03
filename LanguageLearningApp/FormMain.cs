using LanguageLearning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class FormMain : Form
    {
        WordManager wordManager = new();
        Word Word;
        public List<Definition> definitions { get; set; }
        public FormMain()
        {
            InitializeComponent();
            wordManager = new();
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
