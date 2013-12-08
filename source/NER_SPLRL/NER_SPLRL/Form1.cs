using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NER_SPLRL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //persianLocationTaggerButton_click
        private void button1_Click(object sender, EventArgs e)
        {
            PersianLocationTagger plt = new PersianLocationTagger();
            plt.LoadCorpus(@"C:\Users\Omid\Desktop\file(9).txt");
            plt.TagCorpus();
            plt.SaveCorpus(@"C:\Users\Omid\Desktop\file(9)-t.txt");
        }

        private void SlovakLocationTaggerButton_Click(object sender, EventArgs e)
        {
            SlovakLocationTagger plt = new SlovakLocationTagger();
            plt.LoadCorpus(@"C:\Users\Omid\Desktop\slovak-text.txt");
            plt.TagCorpus();
            plt.SaveCorpus(@"C:\Users\Omid\Desktop\slovak-text-tagged.txt");

        }
    }
}
