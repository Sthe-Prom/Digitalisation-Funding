using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using Digitalisation_Funding.Models.Repos;
using Digitalisation_Funding.Extensions;

namespace Digitalisation_Funding.Services.HttpServices
{
    public class Cart
    {
        //Private Field
        private List<ProjectMember> MemberCollection = new List<ProjectMember>();

        //Methods

        /*ADD Product*/
        public virtual void AddItem(ProjectMember pm)
        {
            MemberCollection.Add(new ProjectMember
            {
                FirstName = pm.FirstName,
                LastName = pm.LastName
            });
            
            
        }

        //Public Property
        public virtual IEnumerable<ProjectMember> Members => MemberCollection;
        //List of images the cart currently holds, for this session.

        /*REMOVE Image*/
        public virtual void RemoveMember(ProjectMember pm) =>
            MemberCollection.RemoveAll(m => m.FirstName == pm.FirstName);    
        
        /*CLEAR Images*/
        public virtual void Clear() => MemberCollection.Clear();

    }
}