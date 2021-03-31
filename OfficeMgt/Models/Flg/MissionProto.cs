using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeMgt.Models.Flg
{
    public class MissionProto
    {
     
        public int Id { get; set; }
        
        public string MissionName { get; set; }
        
        public string MissionDuration { get; set; }
        
        public string MissionAircraft { get; set; }
        
        public string Syllabus { get; set; }

        public Phase Phase { get; set; }

        public MissionType Type { get; set; }


    }
}
