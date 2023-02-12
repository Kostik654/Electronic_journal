using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal
{


    public class Student: User
    {
        private TableDataTypes.StudentID stud_id;
        private TableDataTypes.GroupID group_id;

        public TableDataTypes.StudentID GetCard { get => stud_id; set => stud_id = value; }
        public TableDataTypes.GroupID GetGroup { get => group_id; set => group_id = value; }

        //public string Login { get; set; }
        //public string Password { get; set; }

        public bool Sex;
        public bool IsCommercial;

        public static TableDataTypes.StudentID ParseStudentIDString(string studentid)
        {
            List<string> std = studentid.Split(DataWork.Separation).ToList();
            return new TableDataTypes.StudentID
            {
                Surname = std[0],
                Name = std[1],
                Patronymic = std[2],
                Date_birth = std[3],
                Date_in = std[4],
                Date_out = std[5]
            };
        }
        //public string Status { get => DataWork.Statuses[status_id]; set => status_id = DataWork.Statuses.IndexOf(value); }
        public TableDataTypes.StudentID Student_ID { get => stud_id; set => stud_id = value; }
        //public Student(string surname_, string name_, string patro_, string login, string pass, bool sex, bool comm, int status)
        //{
        //    Login = login;
        //    Password = pass;
        //    Sex = sex;
        //    IsCommercial = comm;
        //    status_id = status;
        //    stud_id = new TableDataTypes.StudentID
        //    {
        //        Surname = surname_,
        //        Name = name_,
        //        Patronymic = patro_
        //    };

        //}

        public Student(string studentID, string groupID, string login, string pass, bool sex, bool comm, int status)
        {
            Login = login;
            Password = pass;
            Sex = sex;
            IsCommercial = comm;
            status_id = status;
            stud_id = ParseStudentIDString(studentID);
            group_id = Group.ParseGroupIDString(groupID);
        }



    }
}
