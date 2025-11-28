namespace PdfMerger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstPdfFiles = new ListBox();
            btnAdd = new Button();
            btnRemove = new Button();
            btnMoveUp = new Button();
            btnMoveDown = new Button();
            SuspendLayout();
            // 
            // lstPdfFiles
            // 
            lstPdfFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstPdfFiles.FormattingEnabled = true;
            lstPdfFiles.Location = new Point(101, 12);
            lstPdfFiles.Name = "lstPdfFiles";
            lstPdfFiles.SelectionMode = SelectionMode.MultiExtended;
            lstPdfFiles.Size = new Size(440, 244);
            lstPdfFiles.TabIndex = 0;
            lstPdfFiles.SelectedIndexChanged += lstPdfFiles_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(101, 262);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+ Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(201, 262);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 29);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "- Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Location = new Point(347, 262);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(94, 29);
            btnMoveUp.TabIndex = 3;
            btnMoveUp.Text = "▲ Up";
            btnMoveUp.UseVisualStyleBackColor = true;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Location = new Point(447, 262);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(94, 29);
            btnMoveDown.TabIndex = 4;
            btnMoveDown.Text = "▼ Down";
            btnMoveDown.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 403);
            Controls.Add(btnMoveDown);
            Controls.Add(btnMoveUp);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(lstPdfFiles);
            MinimumSize = new Size(400, 350);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PDF Merger";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstPdfFiles;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnMoveUp;
        private Button btnMoveDown;
    }
}
