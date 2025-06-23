using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Model
{
    internal class Timetable
    {
        public int TimetableID { get; set; }
        public int RoomID { get; set; }
        public int SubjectID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
