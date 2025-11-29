using System;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Data;

namespace PdfMerger
{
    public partial class Form1 : Form
    {
        private List<string> pdfFiles=new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void lstPdfFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select PDF files";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        if (!pdfFiles.Contains(file))
                        {
                            pdfFiles.Add(file);
                        }
                    }
                    RefreshListBox();
                    UpdateStatus();
                }

            }
        }

        private void RefreshListBox()
        {
            lstPdfFiles.Items.Clear();
            for(int i = 0; i < pdfFiles.Count; i++)
            {
                string fileName = System.IO.Path.GetFileName(pdfFiles[i]);
                lstPdfFiles.Items.Add($"{i + 1}. {fileName}");
            }
        }
        private void UpdateStatus()
        {
            if (pdfFiles.Count == 0) { lblStatus.Text = "Ready.Add PDF files to merge."; } else {
                lblStatus.Text = $"{pdfFiles.Count} file(s) added.";
            }
        }
    }
}
