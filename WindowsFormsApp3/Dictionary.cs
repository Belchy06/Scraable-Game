using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public static class Dictionary
    {
        public static List<string> words = new List<string>();

        public static void loadDictionary()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            

            string fullPath;
            string fileName;
            string filePath;

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fullPath = openFileDialog1.FileName;
                fileName = openFileDialog1.SafeFileName;
                filePath = fullPath.Replace(fileName, "");
                //frmSettings.filePath = filePath;

                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (StreamReader sr = new StreamReader(myStream))
                        {
                            // Insert code to read the stream here. 
                            words.Add(sr.ReadLine());
                        }
                        foreach (string word in words)
                        {
                            Console.Out.WriteLine(word);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }
    }
}
