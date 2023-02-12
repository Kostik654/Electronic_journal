using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_journal
{
    public class Permissions
    {
        public int ID { get; set; } = -1;
        public bool ViewZones { get; set; } = true;
        public bool ViewAll { get; set; } = false;
        public bool EditZones { get; set; } = false;
        public bool EditAll { get; set; } = false;
        public bool Admin { get; set; } = false;
        public List<int> PermittedZones { get; set; } = null;
        public static List<int> GetPermissions(string perms)
        {
            try
            {
                return perms.Split(DataWork.Separation).Select(int.Parse).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while getting the permissions: {ex}\nValue: {perms}");
                return new List<int> { };
            }
        }
        public Permissions(string perms, int id, bool rule1, bool rule2, bool rule3, bool rule4, bool rule5)
        {
            PermittedZones = GetPermissions(perms);
            ID = id;
            ViewZones = rule1;
            ViewAll = rule2;
            EditZones = rule3;
            EditAll = rule4;
            Admin = rule5;
        }
        public Permissions() { }

    }
}
