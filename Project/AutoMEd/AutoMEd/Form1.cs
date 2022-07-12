using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AutoMEd
{

    public partial class Form1 : Form
    {
        int cms = 0;
        int courseID = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open");
            }
            GridFill_All_Courses();
            GridView_AllActivities();
            GridView_AllHabits();
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
            cms = Int32.Parse(TextboxLoginCMSID.Text);
            AddMarks.SelectedIndex = 3;//
        }

        private void BackButtonAddStu_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 0;
        }
        String X = "female";
        private void SubmitButtonAddStu_Click(object sender, EventArgs e)
        {
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("StudentAddOrEdit", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", TextBoxAddStuCMSID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_firstname", TextBoxAddStuFirstName.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_lastname", TextBoxAddStuLastName.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_bday", TextBoxAddStuBirthDate.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_sex", X);
                mySqlCmd.Parameters.AddWithValue("_semesternum", TextBoxAddStuSemNo.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_numcourses", TextBoxAddStuNoOfCourses.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_city", TextBoxAddStuCity.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_department", TextBoxAddStuDepartment.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Your account has been created successfully!");
            }
            AddMarks.SelectedIndex = 3;


        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            GridFill_Student_Courses();
            AddMarks.SelectedIndex = 4;
        }

        private void buttonAddCareer_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 5;
        }

        private void buttonAddHabit_Click(object sender, EventArgs e)
        {
            GridView_StudentHabbits();
            AddMarks.SelectedIndex = 6;
        }

        private void buttonAddActivity_Click(object sender, EventArgs e)
        {
            GridView_StudentActivities();
            AddMarks.SelectedIndex = 7;
        }

        private void buttonGrades_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 8;
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
            courseID = Int32.Parse(textBox4.Text);
            if (courseID == 0)
            {
                MessageBox.Show("Please Enter Course ID!");
            }
            else
            {
                GridFill_Attempt_Quiz();
            }
            AddMarks.SelectedIndex = 9;
        }

        private void AddAssiMarksButton_Click(object sender, EventArgs e)
        {
            courseID = Int32.Parse(textBox4.Text);
            if (courseID == 0)
            {
                MessageBox.Show("Please Enter Course ID!");
            }
            else
            {
                GridFill_Attempt_Assignment();
            }
            AddMarks.SelectedIndex = 10;
        }
        void GridFill_Attempt_Assignment()
        {
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewAttemptsAssignment", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("cms_id", cms);
                sqlDa.SelectCommand.Parameters.AddWithValue("_course_ID", courseID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewAttempAssignment.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }


        private void AddExamMarks_Click(object sender, EventArgs e)
        {
            courseID = Int32.Parse(textBox4.Text);
            if (courseID == 0)
            {
                MessageBox.Show("Please Enter Course ID!");
            }
            else
            {
                GridFill_Attempt_Exam();
            }
            AddMarks.SelectedIndex = 11;
        }
        void GridFill_Attempt_Exam()
        {
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewAttemptsExam", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("cms_id", cms);
                sqlDa.SelectCommand.Parameters.AddWithValue("_course_ID", courseID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewAttemptsExam.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
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

      

        private void BackbuttonSearchStudentCareer_Click(object sender, EventArgs e)
        {
            AddMarks.SelectedIndex = 3;
        }

     

        private void submitButtonAddCourse_Click(object sender, EventArgs e)
        {
            //////////////////////////////
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("CourseAddOrEdit", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_courseID", Int32.Parse(CourseIDtextBoxAddcourse.Text));
                mySqlCmd.Parameters.AddWithValue("_credithrs", Int32.Parse(CourseIDtextBoxAddcourse.Text));
                mySqlCmd.Parameters.AddWithValue("_coursename", TextBoxAddStuCMSID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_instrName", TextBoxAddStuCMSID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_instrEmail", TextBoxAddStuCMSID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_OfficeLoc", TextBoxAddStuCMSID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_mblNum", Int32.Parse(InstructorMobileNotextBoxAddcourse.Text));
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Your course has been added successfully!");
                GridFill_All_Courses();
            }
        }
        void GridFill_Student_Courses()
        {
            // dataGridView_StudentCourses
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewTakes", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("cms_id", cms);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView_StudentCourses.DataSource = dtbl;
                //dataGridView_StudentHabbit.Columns[0].Visible = false;
            }

        }
        void GridFill_All_Courses()
        {
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter ("ViewCourse", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewAllCourses.DataSource = dtbl;
            }

        }

        private void SubmitbuttonAddQuiz_Click(object sender, EventArgs e)
        {
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("QuizAttempt", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_courseID", textBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_QID", Int32.Parse(QuizIDtextBoxQuiz.Text));
                mySqlCmd.Parameters.AddWithValue("_status", StatustextBoxQuiz.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_obtainedmarks", Int32.Parse(ObtainedMarkstextBoxQuiz.Text));

                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Quiz Info updated successfully!");
            }

            GridFill_Attempt_Quiz();

        }
        void GridFill_Attempt_Quiz()
        {
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewAttemptsQuiz", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("cms_id", cms);
                sqlDa.SelectCommand.Parameters.AddWithValue("_course_ID", courseID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewQuizzes.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }

        }
        
        void GridView_AllHabits()
        {
            //
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewHabit", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewAllHabts.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }
        void GridView_StudentHabbits()
        {
            //
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewTracksHabit", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("cms_id", cms);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView_StudentHabbit.DataSource = dtbl;
                //dataGridView_StudentHabbit.Columns[0].Visible = false;
            }
        }
        void GridView_AllActivities()
        {
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewPersonalActivity", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridViewAllActivities.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }
        void GridView_StudentActivities()
        {
            //
            //
            string conns = null;
            MySqlConnection cnn;

            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewPerformsActivity", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("cms_id", cms);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView_StudentActivity.DataSource = dtbl;
                //dataGridView_StudentHabbit.Columns[0].Visible = false;
            }
        }


        private void SubmitButtonPersonalActivity_Click(object sender, EventArgs e)
        {
            int Pid; string name = "none";
            if (textBoxPersonalActivityID.Text.Length == 0)
            {
                Pid = Int32.Parse(textBox8.Text); //change name
            }
            else
            {
                Pid = Int32.Parse(textBoxPersonalActivityID.Text);
                name = textBoxActivityName.Text.Trim();
            }
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("AddorEditPersonalAct", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_ActivityID", textBox8.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_ActName", textBoxActivityName.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_AStatus", status.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("ATimePeriod", textBoxPersonalActivityTime.Text.Trim());

                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Activity added or updated successfully!");
            }
            //insert
            GridView_AllActivities();
            GridView_StudentActivities();

        }

        private void SubmitButtonHabit_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Course();
            GridFill_Student_Courses();

        }
        void Add_Course()
        {
            string conns = null;
            MySqlConnection cnn; conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;"; cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("Takes_Course", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_course_ID", Int32.Parse(student_course.Text));
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Courses has been added to your list.");
            }
        }

        private void submitButtonCareerPlanner_Click(object sender, EventArgs e)
        {
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("CareerAddOrEdit", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_plannerID", textBoxPlannerID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_JobId", textBoxJobID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_JStatus", textBox6.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_JComp", textBoxJobCompany.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_JDeadline", Deadline.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_JExp", textBoxJobTimePeriod.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_ProjId", textBoxProjectID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_PStatus", textBox5.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_PComp", textBoxProjectCompany.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_PTimePeriod", textBoxProjectTimePeriod.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Ptitle", title.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_IID", textBoxInternshipID.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_IStatus", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_IComp", textBoxInternshipCompany.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_ITimePeriod", textBoxInternshipTimePeriod.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Career planner added successfully!");
            }
        }

        private void SubmitbuttonAddAssi_Click(object sender, EventArgs e)
        {
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("AssignmentAttempt", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_courseID", textBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_AID", Int32.Parse(AssiIDtextBoxAddAssi.Text));
                mySqlCmd.Parameters.AddWithValue("_status", StatustextBoxAddAssi.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_obtainedmarks", Int32.Parse(ObtainedMarkstextBoxAddAssi.Text));

                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Assignment Info updated successfully!");
            }

            GridFill_Attempt_Assignment();
        }

        private void SubmitbuttonAddExam_Click(object sender, EventArgs e)
        {
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("ExamAttempt", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_courseID", textBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_EID", Int32.Parse(ExamIDtextBoxAddExam.Text));
                mySqlCmd.Parameters.AddWithValue("_status", StatustextBoxAddExam.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_obtainedmarks", Int32.Parse(ObtainedMarkstextBoxAddExam.Text));

                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Exam Info updated successfully!");
            }
            GridFill_Attempt_Exam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            courseID = Int32.Parse(textBox4.Text);
            if (courseID == 0)
            {
                MessageBox.Show("Please Enter Course ID!");
            }
            else
            {
                //GridFill_Attempt_Quiz();
            }
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("CourseResult", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_cid", textBox4.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Course Grade Calculated Successfully! You May View In Grades Tab!");
            }
        }
        void GridFill_ViewCoursesof1student()
        { 

            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("viewCourses_1Student", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_cms", cms);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                gridallcourses.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }
        void GridFill_Internships()
        {
            int planner_id = Int32.Parse(textBoxPlannerID.Text);
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";



            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewInternships", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_planner_ID", planner_id);
                //sqlDa.SelectCommand.Parameters.AddWithValue("_courseID", courseID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Internships.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }
        void GridFill_JobApplication()
        {
            int planner_id = Int32.Parse(textBoxPlannerID.Text);
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";

            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewJobs", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_planner_ID", planner_id);
                //sqlDa.SelectCommand.Parameters.AddWithValue("_courseID", courseID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Job.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }



        void GridFill_Projects()
        {
            int planner_id = Int32.Parse(textBoxPlannerID.Text);
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";



            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewProjects", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_planner_ID", planner_id);
                //sqlDa.SelectCommand.Parameters.AddWithValue("_courseID", courseID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Project.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }
        private void SearchButtonGradesGPA_Click(object sender, EventArgs e)
        {
            GridFill_ViewCoursesof1student();
        }

        private void SearchbuttonSearchStudentCareer_Click(object sender, EventArgs e)
        {
            GridFill_Projects();
            GridFill_JobApplication();
            GridFill_Internships();
        }
        void GridFill_GPA()
        {
            string conns = null;
            MySqlConnection cnn;
            conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;";
            cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("GPA", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_cms", cms);
                //sqlDa.SelectCommand.Parameters.AddWithValue("_courseID", courseID);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                Result.DataSource = dtbl;
                //dataGridViewQuizzes.Columns[0].Visible = false;
            }
        }
        private void CalculateGPAbutton_Click(object sender, EventArgs e)
        {
            string conns = null;
            MySqlConnection cnn; conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;"; cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("Calculate_GPA", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Your Result has been generated successfully!");
            }

            GridFill_GPA();
        }

        private void SubmitButtonHabit_Click_1(object sender, EventArgs e)
        {

            int hid; string name = "none";
            if (textBoxHabitID.Text.Length == 0)
            {
                hid = Int32.Parse(textBox7.Text); //change name
            }
            else
            {
                hid = Int32.Parse(textBoxHabitID.Text);
                name = textBoxHabitName.Text.Trim();
            }
            //..............................................
            string conns = null;
            MySqlConnection cnn; conns = "server=localhost;database=student_management_system;uid=root;pwd=bisma425;"; cnn = new MySqlConnection(conns);
            using (MySqlConnection mysqlCon = new MySqlConnection(conns))
            {
                mysqlCon.Open();
                //.. ..
                MySqlCommand mySqlCmd = new MySqlCommand("AddorEditHabit", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_cms", cms);
                mySqlCmd.Parameters.AddWithValue("_habitID", hid);
                mySqlCmd.Parameters.AddWithValue("_habitName", name);
                mySqlCmd.Parameters.AddWithValue("_Duration", textBoxHabitDuration.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Allocated_Time", textBoxHabitTimeAllocated.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Time_Remaining", textBoxHabitTimeRemaining.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Habit added or updated successfully!");
            }
            //insert values
            GridView_StudentHabbits();
            GridView_AllHabits();
        }
    }
}




