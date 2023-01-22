using APBD_CW3.Models;
using System.Collections.Generic;

namespace APBD_CW3.DAL
{
    public interface IDbService
    {
       public IEnumerable<Student> GetStudents();
       public Student GetStudent(string indexNumber);
       public void AddStudent(Student student);
       public void UpdateStudent(Student student);
       public void DeleteStudent(string indexNumber);
    }
}
