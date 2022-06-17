using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.Data.Interfaces;
using JobEasyWithGOC.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace JobEasyWithGOC.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _db;


        public ApplicationRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<int> DeactivateApplicationAsync(int id)
        {
            var application = _db.Applications.Find(id);
            application.Isdeleted = 1;
            _db.SaveChanges();
            return id;
        }

        public async Task<int> EditApplicationAsync(Application application)
        {

            _db.Applications.Update(application);
            _db.SaveChanges();
            return application.Id;
        }

        public async Task<Application> GetApplicationAsync(int id)
        {
            var application = _db.Applications.Include(i => i.JobPost).Include(i => i.Company).Include(i => i.Applicant).ThenInclude(i => i.Country).Include(i => i.Applicant).ThenInclude(i => i.Province).FirstOrDefault(Application => Application.Id == id); ;
            return application;

        }

        public async Task<int> RegisterAsync(Application application)
        {

            _db.Applications.Add(application);
            _db.SaveChanges();
            return application.Id;
        }
    }
}

