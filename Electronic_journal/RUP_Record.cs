using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Electronic_journal.TableDataTypes;

namespace Electronic_journal
{
    public class RUP_Record
    {
        private int attest_id;
        private int work_type_id;
        private RUP_ID rup_id;

        public int HoursAll, LessonsAll, IndHours, TheoHours, LabHours, CourseworkHours, EduIndHourse, ConsHours, SemNumber, WeeksNumber;
        public int subj_name_id;

        public Attestation AttestationGetSet
        {
            get => TablesData.Attestations[attest_id];
            set => attest_id = TablesData.Attestations.IndexOf(value);
        }
        public WorkType WorkTypeGetSet
        {
            get => TablesData.WorkTypes[work_type_id];
            set => work_type_id = TablesData.WorkTypes.IndexOf(value);
        }
        public TableDataTypes.RUP_ID RUP_ID
        {
            get => rup_id;
            set => rup_id = value;
        }
        public static RUP_ID ParseRUP_IDString(string rupid)
        {
            List<string> std = rupid.Split(DataWork.Separation).ToList();
            //MessageBox.Show(std[3]);
            return new TableDataTypes.RUP_ID
            {
                Sem_Date = std[0],
                Name = std[1],
                GroupName = std[2],
                Teacher_ID = Staff.ParseStaffIDString(
                $"{std[3]}{DataWork.Separation}" +
                $"{std[4]}{DataWork.Separation}" +
                $"{std[5]}{DataWork.Separation}" +
                $"{std[6]}")
            };
        }
        public RUP_Record(string id, int attestid, int workid,
            int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8, int h9, int h10, int subj_nameid)
        {
            rup_id = ParseRUP_IDString(id);
            attest_id = attestid;
            work_type_id = workid;
            HoursAll = h1;
            LessonsAll = h2;
            IndHours = h3;
            TheoHours = h4;
            LabHours = h5;
            CourseworkHours = h6;
            EduIndHourse = h7;
            ConsHours = h8;
            SemNumber = h9;
            WeeksNumber = h10;
            subj_name_id = subj_nameid;
        }
    }
}
