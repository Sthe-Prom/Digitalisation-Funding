using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Digitalisation_Funding.Models;
using Digitalisation_Funding.Models.Repos;

namespace Digitalisation_Funding.Models.ViewModels
{
    public class FundingViewModel
    {
        public Funding Funding { get;set;}
        public ProjectMember ProjectMember { get; set; }
        public Cart Cart { get; set; }
        public IEnumerable<ProjectMember> ProjectMembers { get; set; }
        public IEnumerable<Funding> FundingList { get; set; }
    }
}