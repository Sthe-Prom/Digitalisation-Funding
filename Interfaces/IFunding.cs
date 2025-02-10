using Digitalisation_Funding.Models.Repos;
using System.Threading.Tasks;


namespace Digitalisation_Funding.Interfaces
{
    public interface IFunding
    {
        IQueryable<Funding> FundingList { get; }

        Task SaveFunding(Funding Funding);

        Task<Funding> FundingDetail(int FundingID);
    }
}