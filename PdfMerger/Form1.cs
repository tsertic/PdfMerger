using System;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Data;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfMerger
{
    public partial class Form1 : Form
    {
        private List<string> pdfFiles = new List<string>();
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
            for (int i = 0; i < pdfFiles.Count; i++)
            {
                string fileName = System.IO.Path.GetFileName(pdfFiles[i]);
                lstPdfFiles.Items.Add($"{i + 1}. {fileName}");
            }
        }
        private void UpdateStatus()
        {
            if (pdfFiles.Count == 0) { lblStatus.Text = "Ready.Add PDF files to merge."; }
            else
            {
                lblStatus.Text = $"{pdfFiles.Count} file(s) added.";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstPdfFiles.SelectedIndices.Count > 0)
            {

                for (int i = lstPdfFiles.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    int index = lstPdfFiles.SelectedIndices[i];
                    pdfFiles.RemoveAt(index);
                }
                RefreshListBox();
                UpdateStatus();
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstPdfFiles.SelectedIndex > 0)
            {
                int index = lstPdfFiles.SelectedIndex;
                string temp = pdfFiles[index];
                pdfFiles[index] = pdfFiles[index - 1];
                pdfFiles[index - 1] = temp;

                RefreshListBox();
                lstPdfFiles.SelectedIndex = index - 1;  // Keep selection on moved item
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstPdfFiles.SelectedIndex >= 0 && lstPdfFiles.SelectedIndex < pdfFiles.Count - 1)
            {
                int index = lstPdfFiles.SelectedIndex;
                string temp = pdfFiles[index];
                pdfFiles[index] = pdfFiles[index + 1];
                pdfFiles[index + 1] = temp;

                RefreshListBox();
                lstPdfFiles.SelectedIndex = index + 1;  // Keep selection on moved item
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (pdfFiles.Count < 2)
            {
                MessageBox.Show("Please add at least 2 PDF files to merge.","Not enough files",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save merged PDF as";
                saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.FileName = "Merged_Document.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        lblStatus.Text = "Merging PDF files...";
                        Application.DoEvents(); //update UI

                        //create output document

                        using (PdfDocument outputDocument = new PdfDocument())
                        {
                            foreach (string file in pdfFiles)
                            {
                                using (PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import))
                                {
                                    for (int i = 0; i < inputDocument.PageCount; i++)
                                    {
                                        outputDocument.AddPage(inputDocument.Pages[i]);
                                    }
                                }
                            }
                            // Save the merged document
                            outputDocument.Save(saveFileDialog.FileName);

                        }

                        lblStatus.Text = "Merge complete!";
                        MessageBox.Show($"PDF files merged successfully!\n\nSaved to:\n{saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error occurred";
                        MessageBox.Show($"Error merging PDF files:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
