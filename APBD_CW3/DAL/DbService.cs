using APBD_CW3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APBD_CW3.DAL
{
    public class DbService : IDbService
    {
        public static List<Student> Students = new();
        


        public static void ReadFromFile()
        {
            using (StreamReader reader = new("data.csv"))
            {
                string line;


                while ((line = reader.ReadLine()) != null)
                {
                    var records = line.Split(',');

                    if (records.Length < 9)
                    {
                        throw new Exception("Niekompletny rekord w bazie!");
                    }
                    else
                    {
                        Students.Add(new Student
                        {
                            Name = records[0],
                            LastName = records[1],
                            IndexNumber = records[2],
                            BirthDate = records[3],
                            Studies = records[4],
                            Mode = records[5],
                            Email = records[6],
                            FathersName = records[7],
                            MothersName = records[8],
                        });
                    }

                }
            }
        }

        public static void WriteToFile()
        {

            using (FileStream stream = new FileStream("data.csv", FileMode.OpenOrCreate))
            {

                using (StreamWriter streamWriter = new StreamWriter(stream, Encoding.UTF8))
                {

                    foreach (Student student in Students)
                    {
                        streamWriter.WriteLine(student);
                    }
                }

            }
        }


        public void AddStudent(Student student)
        {
            ReadFromFile();

            if (student == null) { 
            throw new ArgumentNullException();
        }
            else
            {
                Students.Add(
                    new Student
                    {                       
                        Name = student.Name,
                        LastName = student.LastName,
                        IndexNumber = student.IndexNumber,
                        BirthDate = student.BirthDate,
                        Studies = student.Studies,
                        Mode = student.Mode,
                        Email = student.Email,
                        FathersName = student.FathersName,
                        MothersName = student.MothersName
                    });
                WriteToFile();
            }
        }

        public void DeleteStudent(string indexNumber)
        {
            ReadFromFile();
            var student = Students.Find(s=>s.IndexNumber == indexNumber);
            if (student == null)
            {
                ArgumentNullException argumentNullException = new ArgumentNullException("Nie ma takiego studenta!");
                throw argumentNullException;
            }
            else
            {
                Students.Remove(student);
                WriteToFile();
            }
        }



        public Student GetStudent(string indexNumber)
        {
            ReadFromFile();
            var student = Students.Find(s => s.IndexNumber == indexNumber);
            if (student == null)
            {
                ArgumentNullException argumentNullException = new ArgumentNullException("Nie ma takiego studenta!");
                throw argumentNullException;
            }
            else
            return student;
            
        }

        public IEnumerable<Student> GetStudents()
        {
            ReadFromFile();
            return Students;
        }

        public void UpdateStudent(Student s)
        {
            ReadFromFile();
            Student student = Students.Find(e=>e.IndexNumber == s.IndexNumber);

            if(student == null)
            {
                throw new ArgumentNullException("Nie ma takiego studenta!");
            }
            else
            {
                student.IndexNumber = s.IndexNumber;
                student.Name = s.Name;
                student.LastName = s.LastName;
                student.BirthDate = s.BirthDate;
                student.Studies = s.Studies;
                student.Mode = s.Mode;
                student.Email = s.Email;
                student.FathersName = s.FathersName;
                student.MothersName = s.MothersName;
                WriteToFile();
            }
        }
    }
}
