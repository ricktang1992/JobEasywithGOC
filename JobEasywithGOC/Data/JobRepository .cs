using System.Collections;
using JobEasyWithGOC.Data.DataModel;
using JobEasyWithGOC.Data.Interfaces;
using JobEasyWithGOC.ViewModels;
using AutoMapper;

namespace JobEasyWithGOC.Data
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly ApplicationDbContext _db;

        public JobPostRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> DeactivateJobPostAsync(int id)
        {
            var JobPost = _db.JobPosts.Find(id);
            JobPost.Isdeleted = 1;
            _db.SaveChanges();
            return id;
        }

        public async Task<int> EditJobPostAsync(JobPost JobPost)
        {
            _db.JobPosts.Update(JobPost);
            _db.SaveChanges();
            return JobPost.Id;
        }

        public async Task<JobPost> GetJobPostAsync(int id)
        {
            var JobPost = _db.JobPosts.Find(id);
            return JobPost;

        }

        public async Task<int> RegisterAsync(JobPost JobPost)
        {
            _db.JobPosts.Add(JobPost);
            _db.SaveChanges();
            return JobPost.Id;
        }
    }
}
