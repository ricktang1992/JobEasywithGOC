using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.Data.Interfaces;
using JobEasyWithGOC.ViewModels;
using AutoMapper;

namespace JobEasyWithGOC.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;


        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<int> DeactivateCompanyAsync(int id)
        {
            var Company = _db.Companys.Find(id);
            Company.Isdeleted = 1;
            _db.SaveChanges();
            return id;
        }

        public async Task<int> EditCompanyAsync(Company Company)
        {

            _db.Companys.Update(Company);
            _db.SaveChanges();
            return Company.Id;
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            var Company = _db.Companys.Find(id);
            return Company;

        }

        public async Task<int> RegisterAsync(Company Company)
        {

            _db.Companys.Add(Company);
            _db.SaveChanges();
            return Company.Id;
        }
    }
}
