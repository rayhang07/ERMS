using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERMS
{
    public partial class StudentRankingsForm : Form
    {
        private UserRegistrationService userRegistrationService;
        public StudentRankingsForm()
        {
            string dbPath = Path.Combine(Application.StartupPath, "Database", "ERMS.accdb");
            userRegistrationService = new UserRegistrationService(dbPath);

            InitializeComponent();


            // Ensure DataGridView columns fill the whole table width
            DgvRankings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int colCount = DgvRankings.Columns.Count;
            foreach (DataGridViewColumn col in DgvRankings.Columns)
            {
                col.FillWeight = 100f / colCount;
            }

            // Set column widths
            DgvRankings.EnableHeadersVisualStyles = false;

            // Set header styles
            DgvRankings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(128, 64, 0);

            // Set header text color
            DgvRankings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Set default cell styles
            DgvRankings.DefaultCellStyle.BackColor = Color.White;
            DgvRankings.DefaultCellStyle.ForeColor = Color.Black;
            DgvRankings.ColumnHeadersDefaultCellStyle.Font =
            new Font(DgvRankings.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // Add selection options to ComboBox
            CmbSelectClass.Items.Add("Class");
            CmbSelectClass.Items.Add("Student");

            // Selects Class by default
            CmbSelectClass.SelectedIndex = 0; 
        }


        

        private void CmbSelectClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSelectClass.SelectedItem == null) return;

            string selected = CmbSelectClass.SelectedItem.ToString();

            // Loads class table if class is selected
            if (selected == "Class")
                LoadClassRankings();

            // Loads student table if student is selected
            else if (selected == "Student")
                LoadStudentRankings();

           
        }

        private void LoadClassRankings()
        {
         
            DataTable dt = RankingService.GetClassRankings();
            DgvRankings.DataSource = dt;
        }

        private void LoadStudentRankings()
        {

            DataTable dt = RankingService.GetStudentRankings();
            DgvRankings.DataSource = dt;

        }

        
    }
}
