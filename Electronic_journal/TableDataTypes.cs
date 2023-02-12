using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal
{
    public static class TableDataTypes
    {

        public struct Subject
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public struct TeacherTheme
        {
            public int Theme_ID { get; set; }
            public StaffID Teacher_ID { get; set; }
            public RUP_ID Rup_ID { get; set; }
            public string Date { get; set; }
            public string Description { get; set; }
            public bool Was_Change { get; set; }
            public bool Was_Done { get; set; }
            public bool Is_Checked { get; set; }
        }
        public struct Consultation
        {
            public GroupID Con_Group_ID { get; set; }
            public StaffID Teacher_ID { get; set; }
            public RUP_ID Rup_ID { get; set; }
            public string Date { get; set;  }
            public Int16 Hours { get; set; }

        }
        public struct Grade_Record
        {
            public StudentID Student_ID { get; set; }
            public StaffID Teacher_ID { get; set; }
            public RUP_ID Rup_ID { get; set; }
            public string Date { get; set; }
            public int Theme_ID { get; set; }
            public sbyte Grade { get; set; }
            public bool Was_Stud { get; set; }

        }
        public struct RUP_ID
        {
            public StaffID Teacher_ID { get; set; }
            public string Name { get; set; }
            public string GroupName { get; set; }
            public string Sem_Date { get; set; }
            public string GetID () 
                => $"{Sem_Date}{DataWork.Separation}{Name}{DataWork.Separation}{GroupName}" +
                $"{DataWork.Separation}{Teacher_ID.GetID()}";
        }

        public struct Direction
        {
            public int ID { get; set; }
            public int DepartmentID { get; set; }
            public string Name { get; set; }
            public string Full_Name { get; set; }
            public string DirectionNumber { get; set; }
            public string DirectionComment { get; set; }
        }
        public struct Attestation
        {
            public int ID { get; set; }
            public string @Type { get; set; }
            public string Name { get; set; }
        }
        public struct Building
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Post_index { get; set; }
            public string Area { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
        }
        public struct Department
        {
            public int ID { get; set; }
            public int BuildingID { get; set; }
            public int DepartmentNumber { get; set; }
            public string Name { get; set; }
        }
        public struct WorkType
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Int16 Weight { get; set; }
        }
        public struct Status
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public struct Post
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int PermissionLvlID { get; set; }
        }
        public struct GroupID
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public string GetID () => $"{Name}{DataWork.Separation}{Date}";
        }
        public struct StudentID
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            public string Date_birth { get; set; }
            public string Date_in { get; set; }
            public string Date_out { get; set; }
            public string GetID () => $"{Surname}{DataWork.Separation}{Name}{DataWork.Separation}{Patronymic}" +
                $"{DataWork.Separation}{Date_birth}{DataWork.Separation}{Date_in}{DataWork.Separation}{Date_out}";
        }
        public struct StaffID
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            public string Date_birth { get; set; }
            public string GetID () => $"{Surname}{DataWork.Separation}{Name}{DataWork.Separation}" +
                $"{Patronymic}{DataWork.Separation}{Date_birth}";
        }

        public struct PCK
        {
            public int ID { get; set; }
            public int PCK_Department_ID { get; set; }
            public string PCK_Full_Name { get; set; }
        }

    }
}
