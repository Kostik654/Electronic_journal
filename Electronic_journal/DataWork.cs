using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_journal
{
    public static class DataWork
    {
        public static string Host = "127.0.0.1";
        public static string grades_db = $"tkuik_{TablesData.buildingN}_grades";
        public static string secretady_db = $"tkuik_{TablesData.buildingN}_secretary";
        public static string global_db = "tkuik_global";
        public static string Conn_String_grades
        {
            get { return $"Datasource = {Host};username=root;password=root;database={grades_db};SslMode=none"; }
        }
        public static string Conn_String_secretary
        {
            get { return $"Datasource = {Host};username=root;password=root;database={secretady_db};SslMode=none"; }
        }
        public static string Conn_String_global
        {
            get { return $"Datasource = {Host};username=root;password=root;database={global_db};SslMode=none"; }
        }
        public static Char Separation = '-';
        public static List<String> Statuses = new List<string>();
        public static List<String> Directions = new List<string>();
        public static CurrentUser USER = new CurrentUser();

        public static class Connections
        {
            public static MySqlConnection Grades = new MySqlConnection(Conn_String_grades);
            public static MySqlConnection Secretary = new MySqlConnection(Conn_String_secretary);
            public static MySqlConnection Global = new MySqlConnection(Conn_String_global);
            public static void OpenAll()//unsafe
            {
                Grades.Open();
                Secretary.Open();
                Global.Open();
            }
            public static bool CheckConnections()
            {
                if (Grades.State == ConnectionState.Open &&
                    Secretary.State == ConnectionState.Open &&
                    Global.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        public static bool CheckConnection(MySqlConnection connection) => connection.State == ConnectionState.Open;
        public static void Connect(ref MySqlConnection connection, string Conn_String)
        {
            try
            {
                connection = new MySqlConnection(Conn_String);
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connected");
                }
                else
                {
                    MessageBox.Show("Server is Closed");
                    Environment.Exit(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }

        }
        public static void Connect()
        {
            try
            {
                Connections.OpenAll();

                if (Connections.CheckConnections())
                {
                    MessageBox.Show("Connected");
                }
                else
                {
                    MessageBox.Show("Server is Closed");
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }
        public static DataTable MakeRequest(string command_, MySqlConnection connection)
        {
            if (!CheckConnection(connection))
                Connect();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(command_, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public static bool CheckSetUserData(string login, string password, string table_name, out DataTable table)
        {

            if (table_name == "students")
            {
                table = MakeRequest($"SELECT * FROM `{TablesData.buildingN}_{table_name}` WHERE " +
                    $"`{TablesData.buildingN}_{table_name}`.`stud_login` = '{login}' " +
                    $"AND `{TablesData.buildingN}_{table_name}`.`stud_pass` = '{password}';", Connections.Secretary);

                if (table.Rows.Count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            else //staff
            {
                if (table_name == "staff")
                {
                    table = MakeRequest($"SELECT * FROM `{table_name}` WHERE " +
                       $"`{table_name}`.`staff_login` = '{login}' AND `{table_name}`.`staff_pass` = '{password}';", Connections.Global);

                    if (table.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    table = null;
                    return false;
                }
            }

        }

    }
}