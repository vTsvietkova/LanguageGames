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
    public partial class WordInfo : Form
    {
        private Word word;
        private int WordId;
        private WordManager wordManager = new();
        private Definition definition = null;
        public WordInfo(Word word)
        {
            InitializeComponent();
            this.word = word;
        }
        public WordInfo(int id)
        {
            InitializeComponent();
            this.word = new WordManager().Get(id);
            if(this.word != null)
            {
                this.WordId = this.word.Id;
            }
            else
            {
                this.WordId=id;
            }
        }
        private void GetWordAndRefresh(int id)
        {
            this.word = new WordManager().Get(id);
            if (this.word != null)
            {
                this.WordId = this.word.Id;
            }
            else
            {
                this.WordId=id;
            }
            dgvDefinitions.DataSource = word.Definitions;
        }
        private void WordInfo_Load(object sender, EventArgs e)
        {
            dgvDefinitions.DataSource = word.Definitions;
            cbPartOfSpeach.DataSource = Enum.GetValues(typeof(PartOfSpeach));
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if(definition is null)
            {
                if(this.word != null)
                {
                    wordManager.AddDefinition(new Definition(0, tbDefinition.Text, int.Parse(tbHits.Text), (PartOfSpeach)Enum.Parse(typeof(PartOfSpeach), cbPartOfSpeach.Text)), word);
                }
                else
                {
                    wordManager.AddDefinition(new Definition(0, tbDefinition.Text, int.Parse(tbHits.Text), (PartOfSpeach)Enum.Parse(typeof(PartOfSpeach), cbPartOfSpeach.Text)), new Word("word", WordId));
                }
            }
            else
            {
                definition.Def = tbDefinition.Text;
                definition.PartOfSpeach = (PartOfSpeach)Enum.Parse(typeof(PartOfSpeach), cbPartOfSpeach.Text);
                definition.Votes = int.Parse(tbHits.Text);
                wordManager.UpdateDefinition(definition);
            }
            GetWordAndRefresh(WordId);
        }

        private void btnDeleteDef_Click(object sender, EventArgs e)
        {
            wordManager.DeleteDefinition(((Word)dgvDefinitions.SelectedRows[0].DataBoundItem).Id);
            GetWordAndRefresh(WordId);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            definition = (Definition)dgvDefinitions.SelectedRows[0].DataBoundItem;
            tbDefinition.Text = definition.Def;
            cbPartOfSpeach.SelectedIndex =(int)definition.PartOfSpeach;
            tbHits.Text = definition.Votes.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            definition = null;
        }
    }
}
