using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectLayer;
using System.Data;
/// <summary>
/// Summary description for StudentDAL
/// </summary>
/// 

namespace DataLayer
{
    public class StudentDAL
    {
        
        public StudentDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
 
        ///////////////////////////////////////////////////////////////
        //                       INSERT FUNCTION
       //////////////////////////////////////////////////////////////
       /* public static void insertStudent(StudentBO objStudent)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                Student students = new Student
                {
                    Name = objStudent.Name,
                    Age = Convert.ToInt32(objStudent.Age),
                    AddDate=Convert.ToDateTime(objStudent.AddDate),
                    Height = objStudent.Height

                };

                context.Students.InsertOnSubmit(students);
                context.SubmitChanges();
            

            }
    
        }
        ///////////////////////////////////////////////////////////////
        //                       UPDATE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void updateStudent(StudentBO objStudent,int StudentId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                Student students = context.Students.Single(s => s.Id == StudentId);
                students. Name = objStudent.Name;
                students.Age = Convert.ToInt32(objStudent.Age);
                students.AddDate = Convert.ToDateTime(objStudent.AddDate);
                students.Height = objStudent.Height;
                context.SubmitChanges();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       DELETE FUNCTION
        //////////////////////////////////////////////////////////////
        public static void deleteStudent(int StudentId)
          {
              using (DataClassesDataContext context = new DataClassesDataContext())
              {
                  Student students = context.Students.Single(s => s.Id == StudentId);
                  context.Students.DeleteOnSubmit(students);
              }  
          }
        ///////////////////////////////////////////////////////////////
        //                       SELECT All DATA 
        //////////////////////////////////////////////////////////////
        public static IList<Student> getAllStudentList()
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
                var students = from c in context.Students
                               select c;
                  return students.ToList();
            }

        }
        ///////////////////////////////////////////////////////////////
        //                       SELECT BY PARAMETER
        //////////////////////////////////////////////////////////////
        public static StudentBO getStudentByStudentId(int StudentId)
        {
            using (DataClassesDataContext context = new DataClassesDataContext())
            {
               var  students = from c in context.Students
                              where c.Id == StudentId
                              select c;
                StudentBO objStudent = new StudentBO();
                objStudent.Id = students.FirstOrDefault().Id;
                objStudent.Name = students.FirstOrDefault().Name;
                objStudent.Age = Convert.ToInt32(students.FirstOrDefault().Age);
                objStudent.Height = Convert.ToSingle(students.FirstOrDefault().Height);
                objStudent.AddDate = Convert.ToDateTime(students.FirstOrDefault().AddDate);
                return objStudent;
            }
           
        }

        */

    }
}