using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;

namespace JobEasyWithGOC.Data.Interfaces
{
    public interface IApplicationRepository
    {
        Task<int> RegisterAsync(Application Application);
        Task<Application> GetApplicationAsync(int id);
        Task<int> EditApplicationAsync(Application Application);
        Task<int> DeactivateApplicationAsync(int id);
    }
}
