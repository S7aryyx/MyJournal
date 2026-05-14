using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//В проекте - создайте папку Database
//И в папке - классы
//Student.cs

namespace MyJournalConsole.Database
{
    public class Student
    {
        private int id;
        private string name { get; set; }
        private string surname { get; set; }
        private string patronimyc { get; set; }
        private string gender { get; set; }
        private DateTime birth_date { get; set; }

        public Student(int n_id , string n_name , 
            string n_surname , string n_patronimyc , 
            string n_gender , DateTime n_birthDate)
        {
            this.id = n_id;
            this.name = n_name;
            this.surname = n_surname;
            this.patronimyc = n_patronimyc;
            this.gender = n_gender;
            this.birth_date = n_birthDate;
        }
        public int getId() { return id; }

        public static DataTable getAllStudents()
        {
            DataTable dt = new DataTable();

            string connectionString = "Host=46.191.235.28;Port=5432;Username=postgres;Password=1111;Database=P_511_Students";
            string sql = "SELECT \"Students\".id,\"Students\".name,\"Students\".surname,\"Students\".patronimyc,\"genders\".gender_type,\"Students\".birth_date\r\nFROM \"ahmetov_prepod\".\"Students\" INNER JOIN ahmetov_prepod.\"genders\" on \"Students\".gender_id = \"genders\".id;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
               
            }   
                return dt;
        }
        public static Student getStudentById(int f_id)
        {
            Student student = null;
            DataTable dt = new DataTable();

            try
            {
                string connectionString = "Host=46.191.235.28;Port=5432;Username=postgres;Password=1111;Database=P_511_Students";
                string sql = "SELECT \"Students\".id,\"Students\".name,\"Students\".surname,\"Students\".patronimyc,\"genders\".gender_type,\"Students\".birth_date FROM \"ahmetov_prepod\".\"Students\" INNER JOIN ahmetov_prepod.\"genders\" on \"Students\".gender_id = \"genders\".id WHERE \"Students\".id = @f_id;";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("f_id", f_id);
                        using (var reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                            foreach (DataRow row in dt.Rows)
                            {
                                student.id = Convert.ToInt32(row["id"]);
                                student.name = row["name"].ToString();
                                student.surname = row["surname"].ToString();
                                student.patronimyc = row["patronimyc"].ToString();
                                student.gender = row["gender_type"].ToString();
                                student.birth_date = Convert.ToDateTime(row["birth_date"]);
                            }
                        }
                    }
                }
            }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            return student;
        }   
        }
    }
