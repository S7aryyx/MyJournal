using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJournalConsole.Database
{
    public class Grades
    {
        private Student _student { get; set; }
        private int Grade { get; set; }

        public Grades(int student_id, int n_Grade)
        {
            this._student = Student.getStudentById(student_id);
            this.Grade = n_Grade;
        }

        public static void setGradeToStudent(Grades choicenStudent)
        {
            string connectionString = "Host=46.191.235.28;Port=5432;Username=postgres;Password=1111;Database=P_511_Students";
            string sql = "INSERT INTO \"ahmetov_prepod\".\"StudentGrades\"(student_id , grade) " +
                "VALUES (@student_id , @grade)";

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand(sql, conn))
                    {
                        Student student = choicenStudent._student;
                        command.Parameters.AddWithValue("student_id", student.getId());
                        command.Parameters.AddWithValue("grade", choicenStudent.Grade);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}



    //public class Grades
    //{
    //    private int Student_id;
    //    private int Grade;

    //    public Grades(int n_Student_id , int n_Grade)
    //    {
    //        this.Student_id = n_Student_id;
    //        this.Grade = n_Grade;
    //    }
    //    public void setGradeForStudent()
    //    {
    //    }


    //}

