using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AutoMEd
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;

        }


  

        private void timer1_Tick(object sender, EventArgs e)
        {
            LabelDateTime.Text = DateTime.Now.ToString();
            labelDT.Text = DateTime.Now.ToString();
            string DateBreak = DateTime.Now.ToString("HH:mm:ss");

        }


        private void TextBoxAddStuLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonLoginOldUser_Click(object sender, EventArgs e)
        {
            if (TextboxLoginCMSID.Text == "")
            {
                MessageBox.Show("XYZ");      
            }
            AddMarks.SelectedIndex = 1;
        }
        private void CreateNewUser_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 2;
        }

        private void ButtonBackLogin_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 0;
        }

        private void SubmitButtonLogin_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void BackButtonAddStu_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 0;
        }

        private void SubmitButtonAddStu_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 4;
        }

        private void buttonAddCareer_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 5;
        }

        private void buttonAddHabit_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 6;
        }

        private void buttonAddActivity_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 7;
        }

        private void buttonGrades_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 8;
        }

        private void buttonSearchDetail_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 9;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 0;
        }

        private void MAinMenuButtonAddCourse_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void AddQuizMarksButton_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 10;
        }

        private void AddAssiMarksButton_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 11;
        }

        private void AddExamMarks_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 12;
        }

        private void MainMenuButtonCareerPlanner_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void MainMenuButtonHabit_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void MainMenuButtonPersonalActivity_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void MainMenuButtonGradesGPA_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void SearchStudentBioDataButton_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 13;
        }

        private void SearchStudentCareerbutton_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 14;
        }

        private void SearchStudentHabitsAndActivitiesbutton_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 15;
        }

        private void MainMenuButtonSearchDetails_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

        private void BackbuttonAddQuiz_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 4;
        }

        private void BackbuttonAddAssi_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 4;
        }

        private void BacktextBoxAddExam_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 4;
        }

        private void BackbuttonBioData_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 9;
        }

        private void BackbuttonSearchStudentCareer_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 9;
        }

        private void BackbuttonSearchStudentHabit_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 9;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}




