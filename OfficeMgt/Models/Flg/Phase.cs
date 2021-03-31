using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeMgt.Models.Flg
{
    public class Phase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PhaseName { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }

        public Phase()
        {
            MissionType x = new MissionType();
            ICollection<Mission> z = x.Missions;
        }


    }
}
