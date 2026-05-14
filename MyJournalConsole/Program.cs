using MyJournalConsole.Database;
using System;
using System.Data;

namespace MyJournalConsole
{
    class Program
    {
        static bool isExit = false;
        //в 10 кейсе , ставим isExit = true;
        static void Main()
        {
            while (!isExit) //Пока isExit = false. Программа будет активна
            {
                Console.WriteLine("-=== Добро пожаловать в журнал ===-");
                Console.WriteLine("\n\n\n-= МЕНЮ =-\n");
                Console.WriteLine("1.Посмотреть всех студентов."); //DONE
                Console.WriteLine("2.Раздел выставления оценок."); 
                //<2.Сначала уточнить АйДи , потом оценку , далее - процесс
                //вставки в таблицу StudentGrades , полученных от пользователя значений.>


                Console.WriteLine("3.Удалить студента по ID");
                Console.WriteLine("10.Выйти из программы.");
                int.TryParse(Console.ReadLine(), out int userChoice);
                
                switch (userChoice)
                {
                    case 0:
                        Console.WriteLine("Ввод неверный, попробуйте снова.");
                        break;
                    case 1:
                        Console.Clear();
                        ShowAllStudents();
                        break;
                    case 2:
                        Console.WriteLine("-== Раздел выставления оценок ==-");
                        break;
                    case 3:
                        Console.WriteLine("-== Панель ОТЧИСЛЕНИЯ студентов ==-");
                        break;
                    case 10:
                        Console.WriteLine("Гудбай Тёмный друн");
                        isExit = true;
                        break;     
                   }
            }
            

        }

        static void ShowAllStudents()
        {
            try
            {
                Console.WriteLine("-== Список всех студентов ==-");

                DataTable myStudents = Student.getAllStudents();

                if (myStudents == null || myStudents.Rows.Count <= 0)
                {
                    Console.WriteLine("dt ПУСТОЙ");
                    return;
                }

                foreach (DataRow row in myStudents.Rows)
                {
                    Console.WriteLine($"{row["id"]} | {row["name"]} | {row["surname"]} | {row["patronimyc"]} |" +
                        $" {row["gender_type"]} | {row["birth_date"]}");
                }

                Console.WriteLine("Нажмите клавишу , чтобы выйти обратно.");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка : {ex.Message}");
            }
        }
    }
}