using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace NamedEntityTagger
{
    public partial class Form1 : Form
    {

        bool firstdialogpassed = false;
        string fileprefix = "";

        Hashtable ht = new Hashtable();


        public Form1()
        {
            InitializeComponent();

            InitializeOpenFileDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MessageBox.Show("the corpus please.");

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        string text = File.ReadAllText(file);

                        text = " " + text.Replace("\n", "\n ");
               
                        ht.Add(file, text);

                        comboBox1.Items.Add((string)file);
                    }
                    catch (IOException)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("DialogResult is not OK!");
            }


            comboBox1.SelectedIndex = 0;


        }



        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Browser";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("tag please!!");
                    return;
            }

            Hashtable taggedht = new Hashtable();
            progressBar1.Maximum = ht.Count;
            progressBar1.Value = 0;



            List<string> words = new List<string>();


            string wordsfiletext = "";
            MessageBox.Show("word list file please");
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        wordsfiletext += File.ReadAllText(file) + "\r\n";

                    }
                    catch (IOException)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("DialogResult is not OK!");
            }


            string[] lines = wordsfiletext.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                words.Add(line.Trim());
            }



            foreach (DictionaryEntry it in ht)
            {
                string filetext = (string)it.Value;

                foreach (string item in words)
                {
                    filetext = filetext.Replace(" " + item + " ", " <[" + textBox1.Text + ":" + item + "]> ");
                }

                taggedht.Add(it.Key, filetext);

                progressBar1.Value++;
            }

            ht = taggedht;
            textBox2.Text = (string)ht[comboBox1.SelectedItem.ToString()];

            textBox1.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = ht.Count;
            progressBar1.Value = 0;

            foreach (DictionaryEntry item in ht)
            {

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "Save processed corpus File";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
                string name = ((string)item.Key);
                name = name.Substring(name.LastIndexOf('\\') + 1, name.LastIndexOf('.') - name.LastIndexOf('\\') - 1);
                saveFileDialog1.FileName = name;
                if (!firstdialogpassed)
                {
                    saveFileDialog1.ShowDialog();
                    firstdialogpassed = true;
                    fileprefix = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.LastIndexOf('\\') + 1);
                }
                else
                {
                    saveFileDialog1.FileName = fileprefix + saveFileDialog1.FileName + ".txt";
                }

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.TextWriter fs = new StreamWriter((System.IO.FileStream)saveFileDialog1.OpenFile(), Encoding.Unicode);

                    fs.Write((string)item.Value);


                    fs.Close();
                }
                progressBar1.Value++;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = (string)ht[comboBox1.SelectedItem.ToString()];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("tag please!!");
                return;
            }

            Hashtable taggedht = new Hashtable();
            progressBar1.Maximum = ht.Count;
            progressBar1.Value = 0;



            List<string> patterns = new List<string>();


            string wordsfiletext = "";
            MessageBox.Show("pattern file please");
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        wordsfiletext += File.ReadAllText(file) + "\r\n";

                    }
                    catch (IOException)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("DialogResult is not OK!");
            }


            string[] lines = wordsfiletext.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            {
                patterns.Add(line.Trim());
            }



            foreach (DictionaryEntry it in ht)
            {
                string filetext = (string)it.Value;

                List<string> results = new List<string>();

                foreach (string p in patterns)
                {
                    try
                    {

                        foreach (Match match in Regex.Matches(filetext, p, RegexOptions.IgnoreCase))
                        {
                            if (filetext.Contains(" اين "+ match.Value + " ")||
                                filetext.Contains(" آن " + match.Value + " ") ||
                                filetext.Contains(" همين " + match.Value + " ") ||
                                filetext.Contains(" همان " + match.Value + " ") ||
                                filetext.Contains(" تعدادي " + match.Value + " ") 
                                )
                            {
                                continue;
                            }


                          
                           
                                results.Add(match.Value);
                           
                        }
                    }
                    catch (Exception edd)
                    {
                        MessageBox.Show(edd.Message);
                    }
                }

                foreach (string item in results)
                {

                    
                        filetext = filetext.Replace(item , " <[" + textBox1.Text + ":" + item.Trim() + "]> ");
                  
                }

                taggedht.Add(it.Key, filetext);

                progressBar1.Value++;
            }

            ht = taggedht;
            textBox2.Text = (string)ht[comboBox1.SelectedItem.ToString()];

            textBox1.Text = "";
        }

    
    }
}
