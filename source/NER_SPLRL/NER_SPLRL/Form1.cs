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

        private PersianLocationTagger plt;
        private SlovakLocationTagger slt;
        private PersianPersonTagger ppt;
        private SlovakPersonTagger spt;
        private PersianTimeTagger ptt;
        private SlovakTimeTagger stt;

        public Form1()
        {
            InitializeComponent();

            plt = new PersianLocationTagger();
            slt = new SlovakLocationTagger();
            ppt = new PersianPersonTagger();
            spt = new SlovakPersonTagger();
            ptt = new PersianTimeTagger();
            stt = new SlovakTimeTagger();


            
        
        }

        //persianLocationTaggerButton_click
        private void button1_Click(object sender, EventArgs e)
        {
            PersianLocationTagger plt = new PersianLocationTagger();
            plt.LoadCorpus(@"C:\Users\Omid\Desktop\file(9).txt");
            plt.TagCorpus();
            plt.SaveCorpus(@"C:\Users\Omid\Desktop\file(9)-lt.txt");
        }

        private void SlovakLocationTaggerButton_Click(object sender, EventArgs e)
        {
            SlovakLocationTagger plt = new SlovakLocationTagger();
            plt.LoadCorpus(@"C:\Users\Omid\Desktop\slovak-text.txt");
            plt.TagCorpus();
            plt.SaveCorpus(@"C:\Users\Omid\Desktop\slovak-text-tagged.txt");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersianPersonTagger plt = new PersianPersonTagger();
            plt.LoadCorpus(@"C:\Users\Omid\Desktop\file(9).txt");
            plt.TagCorpus();
            plt.SaveCorpus(@"C:\Users\Omid\Desktop\file(9)-pt.txt");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SlovakPersonTagger plt = new SlovakPersonTagger();
            plt.LoadCorpus(@"C:\Users\Omid\Desktop\slovak-text.txt");
            plt.TagCorpus();
            plt.SaveCorpus(@"C:\Users\Omid\Desktop\slovak-text-ptagged.txt");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            PersianTimeTagger ptt = new PersianTimeTagger();
            ptt.LoadCorpus(@"C:\Users\Omid\Desktop\file(9).txt");
            ptt.TagCorpus();
            ptt.SaveCorpus(@"C:\Users\Omid\Desktop\file(9)-tt.txt");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SlovakTimeTagger ptt = new SlovakTimeTagger();
            ptt.LoadCorpus(@"C:\Users\Omid\Desktop\slovak-text.txt");
            ptt.TagCorpus();
            ptt.SaveCorpus(@"C:\Users\Omid\Desktop\slovak-text-ttagged.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            INETagger.setCorpus(textBox1.Text);

            

            if(radioButton1.Checked)//slovak
            {

                slt.TagCorpus();
                spt.TagCorpus();
                stt.TagCorpus();


            }else//persian
            {
                plt.TagCorpus();
                ppt.TagCorpus();
                ptt.TagCorpus();

            }

            string temporaltext = "";
            temporaltext = INETagger.getCorpus();
            temporaltext = temporaltext.Replace("<[LOCATION:", "<font color=\"blue\">");
            temporaltext = temporaltext.Replace("<[PERSON:", "<font color=\"red\">");
            temporaltext = temporaltext.Replace("<[TEMPORALEXP:", "<font color=\"green\">");
            temporaltext = temporaltext.Replace("]>", "</font>");



            var webBrowser = new WebBrowser();
            webBrowser.CreateControl(); // only if needed
            webBrowser.DocumentText = temporaltext;
            while (webBrowser.DocumentText != temporaltext)
            Application.DoEvents();
            webBrowser.Document.ExecCommand("SelectAll", false, null);
            webBrowser.Document.ExecCommand("Copy", false, null);
            richTextBox1.Clear();
            richTextBox1.Paste();

        }
    }
}
