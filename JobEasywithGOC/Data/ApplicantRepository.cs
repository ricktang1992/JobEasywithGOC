using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.Data.Interfaces;
using JobEasyWithGOC.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace JobEasyWithGOC.Data
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDbContext _db;


        public ApplicantRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }

        public async Task<int> DeactivateApplicantAsync(int id)
        {
            var applicant = _db.Applicants.Find(id);
            applicant.Isdeleted = 1;
            _db.SaveChanges();
            return id;
        }

        public async Task<int> EditApplicantAsync(Applicant applicant)
        {
            
            _db.Applicants.Update(applicant);
            _db.SaveChanges();
            return applicant.Id;
        }

        public async Task<Applicant> GetApplicantAsync(int id)
        {
            var applicant = _db.Applicants.Include(i => i.Country).Include(i => i.Province).FirstOrDefault(Applicant => Applicant.Id == id);

            return applicant;

        }

        public async Task<int> RegisterAsync(Applicant applicant)
        {
           
            _db.Applicants.
                Add(applicant);
            _db.SaveChanges();
            return applicant.Id;
        }
    }
}
