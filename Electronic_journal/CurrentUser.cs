using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Electronic_journal.TableDataTypes;
namespace Electronic_journal
{

    public class CurrentUser : User
    {
        public Permissions permissions = new Permissions();
        public string UserName { get; set; }
        public string UserID { get; set; }
        public bool isLogged { get; set; }
        public bool isStudent { get; set; }
        public object UserObjectID { get; set; }

        public Permissions GetPermissions { get => permissions; set => permissions = value; }
        public List<Group> InGroups = new List<Group>();
        public List<RUP_Record> InRUPS = new List<RUP_Record> { };

        public CurrentUser() => isLogged = false;
        public CurrentUser(string login, string password, string id, bool logged, Permissions perms)// staff
        {
            Login = login;
            Password = password;
            isLogged = logged;
            permissions = perms;

            UserID = id;
            UserObjectID = TablesData.Students.FirstOrDefault(x => x.Student_ID.GetID() == id);
        }
        public CurrentUser(string login, string password, string id, bool logged) //student
        {
            Login = login;
            Password = password;
            isLogged = logged;
            permissions = null;

            UserID = id;
            UserObjectID = TablesData.Students.FirstOrDefault(x => x.Student_ID.GetID() == id);
        }

        public static object GetUserObjectByID(bool isStud, string userId)
        {
            if (isStud)
                return TablesData.Students.FirstOrDefault(x => x.Student_ID.GetID() == userId);
            else
                return TablesData.Staffs.FirstOrDefault(x => x.StaffCard.GetID() == userId);
        }

        public void DoAuthorization(bool isStud)
        {
            isStudent = isStud;

            if (!isStud)
            {
                foreach (var rup in TablesData.Rups
                    .Where(x => x.RUP_ID.Teacher_ID.GetID() == Staff.ParseStaffIDString(UserID).GetID()))
                {
                    InRUPS.Add(rup);
                    foreach (var link in TablesData.Group_Rup
                        .Where(dictor => dictor.Value.RUP_ID.GetID() == rup.RUP_ID.GetID()))
                    {
                        InGroups.Add(TablesData.Groups.FirstOrDefault(x => x.GroupCard.GetID() == link.Key.GetID()));
                    }
                }
            }
            else
            {
                InGroups.Add(TablesData.Groups.FirstOrDefault(x => x.GroupCard.GetID() == (UserObjectID as Student).GetGroup.GetID()));
            }

            if (TablesData.isDebug)
                MessageBox.Show($"InRUPS: {InRUPS.Count}\nInGroups: {InGroups.Count}");
        }

    }
}
