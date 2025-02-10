using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digitalisation_Funding.Models.Repos
{
    public class Funding
    {
        [Key]
        public int ApplicationId { get; set; }

        //Personal Details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; }

        //Project Details
        public string ProjectTitle { get; set; }        
        public string Beneficiaries { get; set; }
        public string ProjectScope { get; set; }
        public string ProjectObjectives { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }

        //Funding Details
        public bool OtherFunding { get; set; }
        public decimal ProjectCosts { get; set; }
        public string BudgetBreakdown { get; set; }
        public string BudgetBreakdownFile { get; set; }
        public string AdditionalAttachment { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
      

    }
}

