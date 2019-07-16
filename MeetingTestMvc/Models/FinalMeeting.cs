using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingTestMvc.Models
{
    public class FinalMeeting
    {
        public int IdMeeting { get; set; }
    
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
