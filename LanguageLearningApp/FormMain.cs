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
                wordManager.Create(word);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
