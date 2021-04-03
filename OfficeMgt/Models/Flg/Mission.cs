using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMgt.Models.Flg
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }   
        
        [Required]
        [Column(TypeName ="nvarchar(20)")]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName ="bigint")]
        public long Duration { get; set; }  
        
        [Required]
        [Column(TypeName ="nvarchar(20)")]
        public string Aircraft { get; set; }    
        
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string Syllabus { get; set; }

        
        [Required]
        public int MissionTypeId { get; set; }
        public int PhaseId { get; set; }

        // Trg/ Ops/ VVIP/ Ferry/ Med Evac/
        public MissionType Type { get; set; }   

        
        public  Phase Phase { get; set; }   



    }

   
}


