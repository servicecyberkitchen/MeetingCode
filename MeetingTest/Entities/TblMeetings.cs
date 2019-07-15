using System;
using System.Collections.Generic;

namespace MeetingTestApi.Entities
{
    public partial class TblMeetings
    {
        public int IdMeeting { get; set; }
        public int IdDay { get; set; }
        public int IdTimeslot { get; set; }

        public virtual TblDays IdDayNavigation { get; set; }
        public virtual TblTimeslots IdTimeslotNavigation { get; set; }
    }
}
