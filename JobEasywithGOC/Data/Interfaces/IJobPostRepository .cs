using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;

namespace JobEasyWithGOC.Data.Interfaces
{
    public interface IJobPostRepository
    {
        Task<int> RegisterAsync(JobPost JobPost);
        Task<JobPost> GetJobPostAsync(int id);
        Task<int> EditJobPostAsync(JobPost JobPost);
        Task<int> DeactivateJobPostAsync(int id);
    }
}
