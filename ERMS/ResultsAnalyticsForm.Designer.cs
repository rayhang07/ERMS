namespace ERMS
{
    partial class ResultsAnalyticsForm
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
            CmbSelectAssessment = new ComboBox();
            CmbSelectSubject = new ComboBox();
            BtnSearch = new Button();
            TxtSearch = new TextBox();
            DgvResultsAnalytics = new DataGridView();
            ChtGradeDistribution = new OxyPlot.WindowsForms.PlotView();
            ChtPassFail = new OxyPlot.WindowsForms.PlotView();
            ChtStudentProgression = new OxyPlot.WindowsForms.PlotView();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DgvResultsAnalytics).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // CmbSelectClass
            // 
            CmbSelectClass.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectClass.FormattingEnabled = true;
            CmbSelectClass.Location = new Point(5, 12);
            CmbSelectClass.Name = "CmbSelectClass";
            CmbSelectClass.Size = new Size(135, 38);
            CmbSelectClass.TabIndex = 0;
            CmbSelectClass.Text = "Select Class";
            CmbSelectClass.SelectedIndexChanged += CmbSelectClass_SelectedIndexChanged;
            // 
            // CmbSelectAssessment
            // 
            CmbSelectAssessment.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectAssessment.FormattingEnabled = true;
            CmbSelectAssessment.Location = new Point(314, 12);
            CmbSelectAssessment.Name = "CmbSelectAssessment";
            CmbSelectAssessment.Size = new Size(201, 38);
            CmbSelectAssessment.TabIndex = 1;
            CmbSelectAssessment.Text = "Select Assessment";
            CmbSelectAssessment.SelectedIndexChanged += CmbSelectAssessment_SelectedIndexChanged;
            // 
            // CmbSelectSubject
            // 
            CmbSelectSubject.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectSubject.FormattingEnabled = true;
            CmbSelectSubject.Location = new Point(146, 12);
            CmbSelectSubject.Name = "CmbSelectSubject";
            CmbSelectSubject.Size = new Size(162, 38);
            CmbSelectSubject.TabIndex = 2;
            CmbSelectSubject.Text = "Select Subject";
            CmbSelectSubject.SelectedIndexChanged += CmbSelectSubject_SelectedIndexChanged;
            // 
            // BtnSearch
            // 
            BtnSearch.BackColor = Color.FromArgb(128, 64, 0);
            BtnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSearch.ForeColor = Color.White;
            BtnSearch.Location = new Point(705, 15);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(79, 33);
            BtnSearch.TabIndex = 4;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = false;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // TxtSearch
            // 
            TxtSearch.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtSearch.ForeColor = Color.Black;
            TxtSearch.Location = new Point(542, 15);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Student";
            TxtSearch.Size = new Size(157, 35);
            TxtSearch.TabIndex = 5;
            // 
            // DgvResultsAnalytics
            // 
            DgvResultsAnalytics.BackgroundColor = Color.White;
            DgvResultsAnalytics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvResultsAnalytics.Dock = DockStyle.Fill;
            DgvResultsAnalytics.Location = new Point(0, 0);
            DgvResultsAnalytics.Name = "DgvResultsAnalytics";
            DgvResultsAnalytics.Size = new Size(797, 266);
            DgvResultsAnalytics.TabIndex = 6;
            // 
            // ChtGradeDistribution
            // 
            ChtGradeDistribution.Anchor = AnchorStyles.Top;
            ChtGradeDistribution.Location = new Point(545, 39);
            ChtGradeDistribution.Name = "ChtGradeDistribution";
            ChtGradeDistribution.PanCursor = Cursors.Hand;
            ChtGradeDistribution.Size = new Size(239, 277);
            ChtGradeDistribution.TabIndex = 7;
            ChtGradeDistribution.Text = "plotView1";
            ChtGradeDistribution.ZoomHorizontalCursor = Cursors.SizeWE;
            ChtGradeDistribution.ZoomRectangleCursor = Cursors.SizeNWSE;
            ChtGradeDistribution.ZoomVerticalCursor = Cursors.SizeNS;
            ChtGradeDistribution.Click += ChtGradeDistribution_Click;
            // 
            // ChtPassFail
            // 
            ChtPassFail.Anchor = AnchorStyles.Top;
            ChtPassFail.Location = new Point(317, 39);
            ChtPassFail.Name = "ChtPassFail";
            ChtPassFail.PanCursor = Cursors.Hand;
            ChtPassFail.Size = new Size(222, 299);
            ChtPassFail.TabIndex = 8;
            ChtPassFail.Text = "plotView1";
            ChtPassFail.ZoomHorizontalCursor = Cursors.SizeWE;
            ChtPassFail.ZoomRectangleCursor = Cursors.SizeNWSE;
            ChtPassFail.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // ChtStudentProgression
            // 
            ChtStudentProgression.Anchor = AnchorStyles.Top;
            ChtStudentProgression.Location = new Point(5, 39);
            ChtStudentProgression.Name = "ChtStudentProgression";
            ChtStudentProgression.PanCursor = Cursors.Hand;
            ChtStudentProgression.Size = new Size(322, 321);
            ChtStudentProgression.TabIndex = 9;
            ChtStudentProgression.Text = "plotView1";
            ChtStudentProgression.ZoomHorizontalCursor = Cursors.SizeWE;
            ChtStudentProgression.ZoomRectangleCursor = Cursors.SizeNWSE;
            ChtStudentProgression.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(ChtPassFail);
            panel1.Controls.Add(ChtStudentProgression);
            panel1.Controls.Add(ChtGradeDistribution);
            panel1.Location = new Point(-2, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(797, 378);
            panel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel2.Controls.Add(DgvResultsAnalytics);
            panel2.Location = new Point(-2, 476);
            panel2.Name = "panel2";
            panel2.Size = new Size(797, 266);
            panel2.TabIndex = 10;
            // 
            // ResultsAnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 766);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(TxtSearch);
            Controls.Add(BtnSearch);
            Controls.Add(CmbSelectSubject);
            Controls.Add(CmbSelectAssessment);
            Controls.Add(CmbSelectClass);
            Name = "ResultsAnalyticsForm";
            Text = "ResultsAnalyticsForm";
            Load += ResultsAnalyticsForm_Load;
            ((System.ComponentModel.ISupportInitialize)DgvResultsAnalytics).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CmbSelectClass;
        private ComboBox CmbSelectAssessment;
        private ComboBox CmbSelectSubject;
        private Button BtnSearch;
        private TextBox TxtSearch;
        private DataGridView DgvResultsAnalytics;
        private OxyPlot.WindowsForms.PlotView ChtGradeDistribution;
        private OxyPlot.WindowsForms.PlotView ChtPassFail;
        private OxyPlot.WindowsForms.PlotView ChtStudentProgression;
        private Panel panel1;
        private Panel panel2;
    }
}