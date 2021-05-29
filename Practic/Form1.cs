using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DeepMorphy;
using System.IO;

namespace Practic
{
    public partial class Form1 : Form
    {
        MorphAnalyzer morph = new MorphAnalyzer(withLemmatization: true);
        double[] okras;
        string[] slovo;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            char[] separators = new char[] {' '};
            string inputText = richTextBox1.Text;
            inputText = Regex.Replace(inputText, "(?i)[^А-ЯЁA-Z]", " ");
            string[] words = inputText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int countPSTV = 0;
            int countNGTV = 0;
            int countNEUT;
            double okrasPSTV = 0;
            double okrasNGTV = 0;
            double okrasSum;

            richTextBox1.Text = "";
            foreach (var word in words)
            {
                var results = morph.Parse(word).ToArray();
                var morphInfo = results[0];
                bool isInDict = false;
                string lemma = morphInfo.BestTag.Lemma;
                
                for (int i = 0; i < slovo.Length; i++)
                {
                    if (slovo[i] == lemma)
                    {
                        isInDict = true;
                        double okrasCur = okras[i];
                        if (okrasCur > 0.5)
                        {
                            countPSTV++;
                            richTextBox1.AppendText(word + ' ');
                            richTextBox1.Select(richTextBox1.TextLength - word.Length - 1, word.Length);
                            richTextBox1.SelectionColor = Color.Green;
                        }
                        else if (okrasCur < -0.5)
                        {
                            countNGTV++;
                            richTextBox1.AppendText(word + ' ');
                            richTextBox1.Select(richTextBox1.TextLength - word.Length - 1, word.Length);
                            richTextBox1.SelectionColor = Color.Red;
                        }
                        else
                        {
                            richTextBox1.AppendText(word + ' ');
                            richTextBox1.Select(richTextBox1.TextLength - word.Length - 1, word.Length);
                            richTextBox1.SelectionColor = Color.Black;
                        }
                        if (okrasCur > 0) okrasPSTV += okrasCur;
                        if (okrasCur < 0) okrasNGTV += okrasCur;
                        break;
                    }
                }
                if (!isInDict)
                {
                    richTextBox1.AppendText(word + ' ');
                    richTextBox1.Select(richTextBox1.TextLength - word.Length - 1, word.Length);
                    richTextBox1.SelectionColor = Color.Black;
                }
            }
            countNEUT = words.Length - countNGTV - countPSTV;
            okrasSum = okrasNGTV + okrasPSTV;
     

            textBox1.Text = countPSTV.ToString();
            textBox2.Text = countNGTV.ToString();
            textBox3.Text = countNEUT.ToString();
            if (okrasSum > 0) textBox4.Text = "Полож";
            else textBox4.Text = "Отриц";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            string dictPath = "../../lemmatizedDict.txt";
            string[] strokiSlovar = File.ReadAllLines(dictPath);

            slovo = new string[strokiSlovar.Length];
            okras = new double[strokiSlovar.Length];

            for (int i = 0; i < strokiSlovar.Length; i++)
            {
                string[] str = strokiSlovar[i].Split(';');
                slovo[i] = str[0];
                okras[i] = double.Parse(str[1], CultureInfo.InvariantCulture);
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
