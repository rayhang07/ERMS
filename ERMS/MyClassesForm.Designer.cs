namespace ERMS
{
    partial class MyClassesForm
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
            CmbSelectSubject = new ComboBox();
            TxtSearch = new TextBox();
            BtnSearch = new Button();
            DgvMyClasses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgvMyClasses).BeginInit();
            SuspendLayout();
            // 
            // CmbSelectClass
            // 
            CmbSelectClass.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectClass.FormattingEnabled = true;
            CmbSelectClass.Location = new Point(5, 12);
            CmbSelectClass.Name = "CmbSelectClass";
            CmbSelectClass.Size = new Size(147, 38);
            CmbSelectClass.TabIndex = 0;
            CmbSelectClass.Text = "Select Class";
            CmbSelectClass.SelectedIndexChanged += CmbSelectClass_SelectedIndexChanged;
            // 
            // CmbSelectSubject
            // 
            CmbSelectSubject.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectSubject.FormattingEnabled = true;
            CmbSelectSubject.Location = new Point(167, 12);
            CmbSelectSubject.Name = "CmbSelectSubject";
            CmbSelectSubject.Size = new Size(163, 38);
            CmbSelectSubject.TabIndex = 1;
            CmbSelectSubject.Text = "Select Subject";
            CmbSelectSubject.SelectedIndexChanged += CmbSelectSubject_SelectedIndexChanged;
            // 
            // TxtSearch
            // 
            TxtSearch.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtSearch.ForeColor = Color.Black;
            TxtSearch.Location = new Point(363, 12);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Student";
            TxtSearch.Size = new Size(157, 35);
            TxtSearch.TabIndex = 2;
            // 
            // BtnSearch
            // 
            BtnSearch.BackColor = Color.FromArgb(128, 64, 0);
            BtnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSearch.ForeColor = Color.White;
            BtnSearch.Location = new Point(526, 12);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(79, 33);
            BtnSearch.TabIndex = 3;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = false;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // DgvMyClasses
            // 
            DgvMyClasses.Anchor = AnchorStyles.None;
            DgvMyClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            DgvMyClasses.BackgroundColor = Color.White;
            DgvMyClasses.ColumnHeadersHeight = 34;
            DgvMyClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DgvMyClasses.Location = new Point(12, 101);
            DgvMyClasses.Name = "DgvMyClasses";
            DgvMyClasses.RowHeadersWidth = 200;
            DgvMyClasses.Size = new Size(770, 665);
            DgvMyClasses.TabIndex = 4;
            // 
            // MyClassesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(794, 766);
            Controls.Add(DgvMyClasses);
            Controls.Add(BtnSearch);
            Controls.Add(TxtSearch);
            Controls.Add(CmbSelectSubject);
            Controls.Add(CmbSelectClass);
            Name = "MyClassesForm";
            Text = "MyClasses";
            Load += MyClassesForm_Load;
            ((System.ComponentModel.ISupportInitialize)DgvMyClasses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CmbSelectClass;
        private ComboBox CmbSelectSubject;
        private TextBox TxtSearch;
        private Button BtnSearch;
        private DataGridView DgvMyClasses;
    }
}