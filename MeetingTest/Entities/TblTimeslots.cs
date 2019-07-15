using System;
using System.Collections.Generic;

namespace MeetingTestApi.Entities
{
    public partial class TblTimeslots
    {
        public TblTimeslots()
        {
            TblMeetings = new HashSet<TblMeetings>();
        }

        public int IdTimeslot { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public virtual ICollection<TblMeetings> TblMeetings { get; set; }
    }
}
