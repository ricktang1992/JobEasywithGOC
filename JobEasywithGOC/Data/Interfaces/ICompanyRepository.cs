using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.ViewModels;


namespace JobEasyWithGOC.Data.Interfaces
{
    public interface ICompanyRepository
    {
        Task<int> RegisterAsync(Company Company);
        Task<Company> GetCompanyAsync(int id);
        Task<int> EditCompanyAsync(Company Company);
        Task<int> DeactivateCompanyAsync(int id);
    }
}
