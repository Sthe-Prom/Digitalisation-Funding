using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digitalisation_Funding.Models.Repos
{
    public class ProjectMember
    {
        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        /* Relationship
           FKs  
           -->> Funding Table       
        */ 

        [Required(ErrorMessage = "No Application id")]
        public int ApplicationId { get; set; }

        /* Ref Nav Properties */
        [ForeignKey("ApplicationId")]
        public virtual Funding Funding { get; set; }
    }
}