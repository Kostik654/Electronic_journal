using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_journal
{
    public class Staff: User
    {
        private TableDataTypes.StaffID staffid;
        //private int status_id;
        public TableDataTypes.StaffID StaffCard { get => staffid; set => staffid = value; }
        //public string Status { get => DataWork.Statuses[status_id]; set => status_id = DataWork.Statuses.IndexOf(value); }

        public int PostID;
        public int DepartmentID;
        public int StatusID;
        public int PCK_ID = -1;
        //public string Login { get; set; }
        //public string Password { get; set; }
        public static TableDataTypes.StaffID ParseStaffIDString(string staffid)
        {
            //MessageBox.Show(staffid);
            List<string> std = staffid.Split(DataWork.Separation).ToList();
            
 
            return new TableDataTypes.StaffID
            {
                Surname = std[0],
                Name = std[1],
                Patronymic = std[2],
                Date_birth = std[3]
            };
        }
        //public Staff(string surname_, string name, string patro, string date, int status, string login, string password) 
        //{
        //    status_id = status;
        //    Login = login;
        //    Password = password;
        //    staffid = new TableDataTypes.StaffID
        //    {
        //        Surname = surname_,
        //        Name = name,
        //        Patronymic = patro,
        //        Date_birth = date
        //    };
        
        //}


        public Staff(string staff_id, int status, string login, string password, int postid, int depid, int pck_id)
        {
            status_id = status;
            Login = login;
            Password = password;
            PostID = postid;
            DepartmentID = depid;
            PCK_ID= pck_id;
            staffid = ParseStaffIDString(staff_id);
        }


    }
}
