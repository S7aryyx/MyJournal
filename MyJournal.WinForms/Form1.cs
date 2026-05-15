using System.Data;
using MyJournalConsole.Database;
namespace MyJournal.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            DataTable dt = Student.getAllStudents();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        //Обновить
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DataTable dt = Student.getAllStudents();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        //Отчислить (На окне)
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        //Назначить оценку (На окне)
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        //Кнопка в GroupBox1
        private void button6_Click(object sender, EventArgs e)
        {
            var choicenRow = dataGridView1.CurrentRow;
            int choicen_id = Convert.ToInt32(choicenRow.Cells["id"].Value);
            int choicen_grade = Convert.ToInt32(textBox1.Text);

            Grades.setGradeToStudent(new Grades(choicen_id, choicen_grade));

            groupBox1.Visible = false;
        }

        //Кнопка в GroupBox2
        private void button5_Click(object sender, EventArgs e)
        {
            int student_id = Convert.ToInt32(textBox2.Text);
            Student.deleteStudent(student_id);

            //Обновление DataGrid'а , после удаления студента (по желанию)
            dataGridView1.DataSource = null;
            DataTable dt = Student.getAllStudents();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

            groupBox2.Visible = false;
        }
        //Выйти
        private void button4_Click(object sender, EventArgs e)
        {
           Form thisForm = Form.ActiveForm;
            thisForm.Close();
        }
    }
}
