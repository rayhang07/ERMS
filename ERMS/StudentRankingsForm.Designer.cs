namespace ERMS
{
    partial class StudentRankingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CmbSelectClass = new ComboBox();
            DgvRankings = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgvRankings).BeginInit();
            SuspendLayout();
            // 
            // CmbSelectClass
            // 
            CmbSelectClass.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectClass.FormattingEnabled = true;
            CmbSelectClass.Location = new Point(5, 12);
            CmbSelectClass.Name = "CmbSelectClass";
            CmbSelectClass.Size = new Size(135, 38);
            CmbSelectClass.TabIndex = 1;
            CmbSelectClass.Text = "Table";
            CmbSelectClass.SelectedIndexChanged += CmbSelectClass_SelectedIndexChanged;
            // 
            // DgvRankings
            // 
            DgvRankings.Anchor = AnchorStyles.Top;
            DgvRankings.BackgroundColor = Color.White;
            DgvRankings.ColumnHeadersHeight = 40;
            DgvRankings.Location = new Point(5, 189);
            DgvRankings.Name = "DgvRankings";
            DgvRankings.Size = new Size(784, 575);
            DgvRankings.TabIndex = 2;
            // 
            // StudentRankingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 766);
            Controls.Add(DgvRankings);
            Controls.Add(CmbSelectClass);
            Name = "StudentRankingsForm";
            Text = "StudentRankings";
            ((System.ComponentModel.ISupportInitialize)DgvRankings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CmbSelectClass;
        private DataGridView DgvRankings;
    }
}