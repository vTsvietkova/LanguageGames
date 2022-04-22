using Data.WordData;
using LanguageLearningLogic;
using LanguageLearningLogic.WordClasses;
using System;
using System.Windows.Forms;

namespace LanguageLearningApp
{
    public partial class WordInfo : Form
    {
        private Word word;
        private int WordId;
        private WordManager wordManager = new(new WordDAL());
        private Definition definition = null;
        public WordInfo(Word word)
        {
            InitializeComponent();
            this.word = word;
        }
        public WordInfo(int id)
        {
            InitializeComponent();
            this.word = new WordManager(new WordDAL()).Get(id);
            if(this.word is not null && this.word.Id != 0)
            {
                this.WordId = this.word.Id;
            }
            else
            {
                this.word = null;
                this.WordId=id;
            }
        }
        private void GetWordAndRefresh(int id)
        {
            this.word = new WordManager(new WordDAL()).Get(id);
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
            if(word is not null)
            {
                dgvDefinitions.DataSource = word.Definitions;
            }
            cbPartOfSpeach.DataSource = Enum.GetValues(typeof(PartOfSpeach));
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if(definition is null)
            {
                if(this.word is not null && this.word.Id != 0)
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
            if(WordId != 0)
            {
                GetWordAndRefresh(WordId);
            }
            else
            {
                GetWordAndRefresh(this.word.Id);
            }
        }

        private void btnDeleteDef_Click(object sender, EventArgs e)
        {
            wordManager.DeleteDefinition(((Definition)dgvDefinitions.SelectedRows[0].DataBoundItem).Id);
            if (WordId != 0)
            {
                GetWordAndRefresh(WordId);
            }
            else
            {
                GetWordAndRefresh(this.word.Id);
            }
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
