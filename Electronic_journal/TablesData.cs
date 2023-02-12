using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Electronic_journal.TableDataTypes;

namespace Electronic_journal
{
    public static class TablesData
    {
        public static bool isDebug = false;
        public static string buildingN = "building1";

        public static List<Student> Students = new List<Student>();//gotovo     // ВЫГРУЗКА
        public static List<Staff> Staffs = new List<Staff>();//gotovo     // ВЫГРУЗКА
        public static List<Group> Groups = new List<Group>();//gotovo     // ВЫГРУЗКА
        public static List<Permissions> PermissionsTable = new List<Permissions>();//готово     // ВЫГРУЗКА
        public static List<RUP_Record> Rups = new List<RUP_Record>();//gotovo     // ВЫГРУЗКА

        public static List<Consultation> Consultations = new List<Consultation>();//gotovo     // ВЫГРУЗКА

        public static List<WorkType> WorkTypes = new List<WorkType>();     //gotovo     // ВЫГРУЗКА
        public static List<Status> Statuses = new List<Status>();     // gotovo     // ВЫГРУЗКА
        public static List<Post> Posts = new List<Post>();     // gotovo    // ВЫГРУЗКА
        public static List<Department> Departments = new List<Department>();   //gotovo    // ВЫГРУЗКА
        public static List<Building> Buildings = new List<Building>();     // gotovo    // ВЫГРУЗКА
        public static List<Attestation> Attestations = new List<Attestation>();     // gotovo   // ВЫГРУЗКА
        public static List<Direction> Directions = new List<Direction>();//gotovo     // ВЫГРУЗКА
        public static List<TeacherTheme> teacherThemes = new List<TeacherTheme>();//gotovo     // ВЫГРУЗКА
        public static List<PCK> pCKs = new List<PCK>();     // gotovo    // ВЫГРУЗКА

        public static List<Subject> Subjects = new List<Subject>();     // gotovo    // ВЫГРУЗКА

        public static Dictionary<GroupID, List<Grade_Record>> GroupGrades = new Dictionary<GroupID, List<Grade_Record>>();//gotovo     // ВЫГРУЗКА
        public static Dictionary<GroupID, RUP_Record> Group_Rup = new Dictionary<GroupID, RUP_Record>();//gotovo     // ВЫГРУЗКА

        public static List<Grade_Record> Grades_cache = new List<Grade_Record>();

        public static void ResetLoadedTables()
        {
            Students = new List<Student>();
            Staffs = new List<Staff>();
            Groups = new List<Group>();
            PermissionsTable = new List<Permissions>();
            Rups = new List<RUP_Record>();

            Consultations = new List<Consultation>();

            WorkTypes = new List<WorkType>();
            Statuses = new List<Status>();
            Posts = new List<Post>();
            Departments = new List<Department>();
            Buildings = new List<Building>();
            Attestations = new List<Attestation>();
            Directions = new List<Direction>();
            teacherThemes = new List<TeacherTheme>();
            Subjects = new List<Subject>();
            pCKs = new List<PCK>();

            GroupGrades = new Dictionary<GroupID, List<Grade_Record>>();
            Group_Rup = new Dictionary<GroupID, RUP_Record>();


        }

        public static DataTable LoadSubjects()
        {
            DataTable table = new DataTable();

            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_subjects`", DataWork.Connections.Secretary);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Subjects.Add(new Subject()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    Name = (string)table.Rows[i].ItemArray[1]
                });
            }
            if (isDebug)
                MessageBox.Show("Subjs: " + Subjects.Count);
            return table;
        }
        public static DataTable LoadPCK()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `PCK`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                pCKs.Add(new PCK()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    PCK_Department_ID = Convert.ToInt32(table.Rows[i].ItemArray[1]),
                    PCK_Full_Name = (string)table.Rows[i].ItemArray[2]
                });
            }
            if (isDebug)
                MessageBox.Show("PCKs: " + pCKs.Count);
            return table;
        }
        public static DataTable LoadAttestations()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `attestations_list`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Attestations.Add(new Attestation()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    Type = (string)table.Rows[i].ItemArray[1],
                    Name = (string)table.Rows[i].ItemArray[2]
                });
            }
            if (isDebug)
                MessageBox.Show("Attests: " + Attestations.Count);
            return table;
        }
        public static DataTable LoadBuildings()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `buildings`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Buildings.Add(new Building()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    Name = (string)table.Rows[i].ItemArray[1],
                    Phone = (string)table.Rows[i].ItemArray[2],
                    Email = (string)table.Rows[i].ItemArray[3],
                    Post_index = (string)table.Rows[i].ItemArray[4],
                    Area = (string)table.Rows[i].ItemArray[5],
                    City = (string)table.Rows[i].ItemArray[6],
                    Street = (string)table.Rows[i].ItemArray[7]
                });
            }
            if (isDebug)
                MessageBox.Show("Builds: " + Buildings.Count);
            return table;
        }
        public static DataTable LoadDeparments()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `departments`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Departments.Add(new Department()

                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    DepartmentNumber = Convert.ToInt32(table.Rows[i].ItemArray[1]),
                    Name = (string)table.Rows[i].ItemArray[2]
                });
            }
            if (isDebug)
                MessageBox.Show("Deps: " + Departments.Count);
            return table;
        }
        public static DataTable LoadPosts()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `posts`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Posts.Add(new Post()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    PermissionLvlID = Convert.ToInt32(table.Rows[i].ItemArray[1]),
                    Name = (string)table.Rows[i].ItemArray[2]
                });
            }
            if (isDebug)
                MessageBox.Show("Posts: " + Posts.Count);
            return table;
        }
        public static DataTable LoadStatuses()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `statuses`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Statuses.Add(new Status()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    Name = (string)table.Rows[i].ItemArray[1]
                });
            }
            if (isDebug)
                MessageBox.Show("Stats: " + Statuses.Count);
            return table;
        }
        public static DataTable LoadWorkTypes()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `work_types`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                WorkTypes.Add(new WorkType()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    Name = (string)table.Rows[i].ItemArray[1],
                    Weight = Convert.ToInt16(table.Rows[i].ItemArray[2])
                });
            }
            if (isDebug)
                MessageBox.Show("W_types: " + WorkTypes.Count);
            return table;
        }
        public static DataTable LoadPermissions()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `permissions`", DataWork.Connections.Global);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                PermissionsTable.Add(new Permissions()
                {
                    ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
                    ViewZones = Convert.ToBoolean(table.Rows[i].ItemArray[1]),
                    ViewAll = Convert.ToBoolean(table.Rows[i].ItemArray[2]),
                    EditZones = Convert.ToBoolean(table.Rows[i].ItemArray[3]),
                    EditAll = Convert.ToBoolean(table.Rows[i].ItemArray[4]),
                    Admin = Convert.ToBoolean(table.Rows[i].ItemArray[5]),

                    PermittedZones = Convert.IsDBNull(table.Rows[i].ItemArray[6]) ?
                    null : Permissions.GetPermissions((string)table.Rows[i].ItemArray[6])

                });
            }
            if (isDebug)
                MessageBox.Show("Permissions: " + PermissionsTable.Count);
            return table;
        }
        public static DataTable LoadStudents()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_students`", DataWork.Connections.Secretary);
            //Students.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Students.Add(new Student(
                    (string)table.Rows[i].ItemArray[0], (string)table.Rows[i].ItemArray[1],
                    (string)table.Rows[i].ItemArray[3], (string)table.Rows[i].ItemArray[4],
                    Convert.ToBoolean(table.Rows[i].ItemArray[5]), Convert.ToBoolean(table.Rows[i].ItemArray[6]),
                    (int)table.Rows[i].ItemArray[2]));
            }
            if (isDebug)
                MessageBox.Show("Students: " + Students.Count);
            return table;
        }
        public static DataTable LoadStaff()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest("SELECT * FROM `staff`", DataWork.Connections.Global);
            //Staffs.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Staffs.Add(new Staff(
                    (string)table.Rows[i].ItemArray[0], (int)table.Rows[i].ItemArray[3],
                    (string)table.Rows[i].ItemArray[5], (string)table.Rows[i].ItemArray[6],
                    (int)table.Rows[i].ItemArray[1], (int)table.Rows[i].ItemArray[2],
                    Convert.IsDBNull(table.Rows[i].ItemArray[4]) ? -1 : (int)table.Rows[i].ItemArray[4])
                    );
            }//Convert.IsDBNull(table.Rows[i].ItemArray[4]) ? 0 : (int)table.Rows[i].ItemArray[4]
            if (isDebug)
                MessageBox.Show("Staff: " + Staffs.Count);
            return table;
        }
        public static DataTable LoadGroups()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_group`", DataWork.Connections.Secretary);
            //Groups.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Groups.Add(new Group(
                    (string)table.Rows[i].ItemArray[0], (string)table.Rows[i].ItemArray[1],
                    (int)table.Rows[i].ItemArray[2], Convert.ToBoolean(table.Rows[i].ItemArray[3])));
            }
            if (isDebug)
                MessageBox.Show("Groups: " + Groups.Count);
            return table;
        }
        public static DataTable LoadGroupsGrades()
        {
            DataTable table = new DataTable();

            for (int j = 0; j < Groups.Count; j++)
            {
                if (isDebug)
                    MessageBox.Show($"GroupID to Grade: {Groups[j].GroupCard.GetID()}");

                table = DataWork.MakeRequest($"SELECT * FROM `{Groups[j].GroupCard.GetID()}`", DataWork.Connections.Grades);
                List<Grade_Record> grade_Records = new List<Grade_Record>();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    grade_Records.Add(new Grade_Record()
                    {
                        Student_ID = Student.ParseStudentIDString((string)table.Rows[i].ItemArray[0]),
                        Teacher_ID = Staff.ParseStaffIDString((string)table.Rows[i].ItemArray[1]),
                        Rup_ID = RUP_Record.ParseRUP_IDString((string)table.Rows[i].ItemArray[2]),
                        Theme_ID = (int)table.Rows[i].ItemArray[3],
                        Grade = Convert.ToSByte(table.Rows[i].ItemArray[4]),
                        Was_Stud = Convert.ToBoolean(table.Rows[i].ItemArray[5])
                    });
                }

                GroupGrades.Add(Groups[j].GroupCard, grade_Records);

            }
            if (isDebug)
                MessageBox.Show("Grade Groups: " + GroupGrades.Count);

            return table;
        }
        public static DataTable LoadGrades(string groupid, string rupid, DateTime fromdate, DateTime todate)
        {
            DataTable table = new DataTable();
            Grades_cache.Clear();
            table = DataWork.MakeRequest
                ($"SELECT * FROM `{groupid}` WHERE `gr_rup_id` = '{rupid}' " +
                $"AND `gr_date` >= '{fromdate.ToString("yyyy-MM-dd")}' " +
                $"AND `gr_date` <= '{todate.ToString("yyyy-MM-dd")}'", DataWork.Connections.Grades);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Grades_cache.Add(new Grade_Record()
                {
                    Student_ID = Student.ParseStudentIDString((string)table.Rows[i].ItemArray[0]),
                    Teacher_ID = Staff.ParseStaffIDString((string)table.Rows[i].ItemArray[1]),
                    Rup_ID = RUP_Record.ParseRUP_IDString((string)table.Rows[i].ItemArray[2]),
                    Theme_ID = (int)table.Rows[i].ItemArray[3],
                    Grade = Convert.ToSByte(table.Rows[i].ItemArray[4]),
                    Was_Stud = Convert.ToBoolean(table.Rows[i].ItemArray[5]),
                    Date = Convert.ToString(table.Rows[i].ItemArray[6])
                });
            }
            if (isDebug)
                MessageBox.Show("Grades: " + Grades_cache.Count);
            return table;
        }
        public static DataTable LoadConsultations()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_cons_list`", DataWork.Connections.Secretary);
            for (int i = 0; i < table.Rows.Count; i++)
            {

                if (isDebug)
                {

                    MessageBox.Show($"" +
                        $"{(string)table.Rows[i].ItemArray[0]}\n" +
                        $"{(string)table.Rows[i].ItemArray[1]}\n" +
                        $"{(string)table.Rows[i].ItemArray[2]}\n" +
                        $"{(string)table.Rows[i].ItemArray[3]}\n" +
                        $"{Convert.ToInt16(table.Rows[i].ItemArray[4])}");
                }

                Consultations.Add(new Consultation()
                {
                    Con_Group_ID = Group.ParseGroupIDString((string)table.Rows[i].ItemArray[0]),
                    Rup_ID = RUP_Record.ParseRUP_IDString((string)table.Rows[i].ItemArray[1]),
                    Teacher_ID = Staff.ParseStaffIDString((string)table.Rows[i].ItemArray[2]),
                    Date = (string)table.Rows[i].ItemArray[3],
                    Hours = Convert.ToInt16(table.Rows[i].ItemArray[4])
                });
            }
            if (isDebug)
                MessageBox.Show("Cons: " + Consultations.Count);
            return table;
        }
        public static DataTable LoadDirections()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_directions`", DataWork.Connections.Secretary);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Directions.Add(new Direction()
                {
                    ID = (int)table.Rows[i].ItemArray[0],
                    DepartmentID = (int)table.Rows[i].ItemArray[1],
                    Name = (string)table.Rows[i].ItemArray[2],
                    Full_Name = (string)table.Rows[i].ItemArray[3],
                    DirectionNumber = (string)table.Rows[i].ItemArray[4],
                    DirectionComment = Convert.IsDBNull(table.Rows[i].ItemArray[5]) ? string.Empty : (string)table.Rows[i].ItemArray[5]
                });
            }
            if (isDebug)
                MessageBox.Show("Dirs: " + Directions.Count);
            return table;
        }
        public static DataTable LoadRUPS()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_rup_list`", DataWork.Connections.Secretary);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Rups.Add(new RUP_Record(
                    (string)table.Rows[i].ItemArray[0],
                    Convert.ToInt16(table.Rows[i].ItemArray[1]),
                    Convert.ToInt16(table.Rows[i].ItemArray[2]),
                    Convert.ToInt16(table.Rows[i].ItemArray[3]),
                    Convert.ToInt16(table.Rows[i].ItemArray[4]),
                    Convert.ToInt16(table.Rows[i].ItemArray[5]),
                    Convert.ToInt16(table.Rows[i].ItemArray[6]),
                    Convert.ToInt16(table.Rows[i].ItemArray[7]),
                    Convert.ToInt16(table.Rows[i].ItemArray[8]),
                    Convert.ToInt16(table.Rows[i].ItemArray[9]),
                    Convert.ToInt16(table.Rows[i].ItemArray[10]),
                    Convert.ToInt16(table.Rows[i].ItemArray[11]),
                    Convert.ToInt16(table.Rows[i].ItemArray[12]),
                    Convert.ToInt16(table.Rows[i].ItemArray[13])
                    ));
            }
            if (isDebug)
            {
                MessageBox.Show($"Rups: {Rups.Count}\nFirstID:\n{Rups[0].RUP_ID.GetID()}");
            }
            return table;
        }
        public static DataTable LoadGroupRUP()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_groups_rups`", DataWork.Connections.Secretary);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                try
                {
                    Group_Rup.Add(
                        Group.ParseGroupIDString((string)table.Rows[i].ItemArray[0]),
                        Rups.Where(x => x.RUP_ID.GetID() == (string)table.Rows[i].ItemArray[1]).First()
                        );
                }
                catch
                {
                    if (isDebug)
                    {
                        MessageBox.Show($"LINK[{i}]:\n{(string)table.Rows[i].ItemArray[0]}" +
                            $"\n{(string)table.Rows[i].ItemArray[1]}");
                    }
                }
            }
            if (isDebug)
                MessageBox.Show("RupGroups: " + Group_Rup.Count);
            return table;
        }
        public static DataTable LoadTeachersThemes()
        {
            DataTable table = new DataTable();
            table = DataWork.MakeRequest($"SELECT * FROM `{TablesData.buildingN}_teachers_themes`", DataWork.Connections.Secretary);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                teacherThemes.Add(new TeacherTheme()
                {
                    Theme_ID = (int)table.Rows[i].ItemArray[0],
                    Teacher_ID = Staff.ParseStaffIDString((string)table.Rows[i].ItemArray[1]),
                    Rup_ID = RUP_Record.ParseRUP_IDString((string)table.Rows[i].ItemArray[2]),
                    Date = (string)table.Rows[i].ItemArray[3],
                    Description = (string)table.Rows[i].ItemArray[4],
                    Was_Change = Convert.ToBoolean(table.Rows[i].ItemArray[5]),
                    Was_Done = Convert.ToBoolean(table.Rows[i].ItemArray[6]),
                    Is_Checked = Convert.ToBoolean(table.Rows[i].ItemArray[7])
                });
            }
            if (isDebug)
                MessageBox.Show("Themes: " + teacherThemes.Count);

            if (isDebug)
                MessageBox.Show("SUCCESSFULL LOADING");
            return table;
        }
        
        public static async void LoadAllTables(DataTable table, string login, string password, bool isStud)
        {
            await Task.Run(() =>
            {
                ResetLoadedTables();

                LoadSubjects();
                LoadPCK();
                LoadAttestations();
                LoadBuildings();
                LoadDeparments();
                LoadPosts();
                LoadStatuses();
                LoadWorkTypes();
                LoadPermissions();
                LoadStudents();
                LoadStaff();
                LoadGroups();
                                                //LoadGroupGrades();
                LoadConsultations();
                LoadDirections();
                LoadRUPS();
                LoadGroupRUP();
                LoadTeachersThemes();

                AutorizeForm.Main.Invoke(new Action(() =>   
                {
                    AutorizeForm.Main.enter_button.Enabled = true;      //разблокировка кнопки авторизации
                    Form1.Main.panel1.Controls.Clear();                 //удаление формы авторизации
                }));


                if (!isStud)//// добавление нового пользователя
                {
                    /////// и обновление его прав, если это персонал
                    int postID = Convert.ToUInt16(table.Rows[0][1]);
                    TableDataTypes.Post post = TablesData.Posts.Where(x => x.ID == postID).First();

                    Permissions perms = TablesData.PermissionsTable.Where(
                        x => x.ID == post.PermissionLvlID).First();

                    DataWork.USER = new CurrentUser(login, password, table.Rows[0][0].ToString(), true, perms);
                    DataWork.USER.DoAuthorization(false);

                    if (TablesData.isDebug)
                        MessageBox.Show($"User Added: {DataWork.USER.Login}");

                }
                else//студент
                {
                    DataWork.USER = new CurrentUser(login, password, table.Rows[0][0].ToString(), true);
                    DataWork.USER.DoAuthorization(true);
                }

                
                // LoadGrades(Groups[0].GroupCard.GetID(), Rups[0].RUP_ID.GetID(), DateTime.Now, DateTime.Now);
            });
        }
        public static async void UploadAllTables()
        {
            await Task.Run(() =>
            {


            }
            );
        }

    }
}








//table = DataWork.MakeRequest("SELECT * FROM `posts`", DataWork.Connections.Global);
//for (int i = 0; i < table.Rows.Count; i++)
//{
//    Posts.Add(new Post()
//    {
//        ID = Convert.ToInt32(table.Rows[i].ItemArray[0]),
//        PermissionLvlID = Convert.ToInt16(table.Rows[i].ItemArray[1]),
//        Name = (string)table.Rows[i].ItemArray[2]
//    });
//}
//if (isDebug)
//    MessageBox.Show("Posts: " + Posts.Count);