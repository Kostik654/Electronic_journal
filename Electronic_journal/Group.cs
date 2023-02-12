using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal
{

    public class Group
    {
        private TableDataTypes.GroupID groupid;
        private TableDataTypes.StaffID tutorid;

        public int DirectionID;
        public bool IsCommercial;
        public TableDataTypes.StaffID TutorCard { get => tutorid; set => tutorid = value; }
        public TableDataTypes.GroupID GroupCard { get => groupid; set => groupid = value; }
        public string GetDirection 
        { get => DataWork.Directions[DirectionID]; set => DirectionID = DataWork.Directions.IndexOf(value); }
        public static TableDataTypes.GroupID ParseGroupIDString(string groupid)
        {
            List<string> std = groupid.Split(DataWork.Separation).ToList();
            return new TableDataTypes.GroupID
            {
                Name= std[0],
                Date= std[1]
            };
        }
        public Group(string gr_id, string tutid, int directionID, bool iscom)
        {
            groupid = ParseGroupIDString(gr_id);
            tutorid = Staff.ParseStaffIDString(tutid);
            IsCommercial = iscom;
            DirectionID = directionID;
            
        }

    }
}
