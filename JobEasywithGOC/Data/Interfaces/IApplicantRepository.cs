using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;

namespace JobEasyWithGOC.Data.Interfaces
{
    public interface IApplicantRepository
    {
        Task<int> RegisterAsync(Applicant applicant);
        Task<Applicant> GetApplicantAsync(int id);
        Task<int> EditApplicantAsync(Applicant applicant);
        Task<int> DeactivateApplicantAsync(int id);
    }
}
