using System;
using System.Collections.Generic;

namespace MeetingTestApi.Entities
{
    public partial class TblDays
    {
        public TblDays()
        {
            TblMeetings = new HashSet<TblMeetings>();
        }

        public int IdDay { get; set; }
        public DateTime Day { get; set; }

        public virtual ICollection<TblMeetings> TblMeetings { get; set; }
    }
}
