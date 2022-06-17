using JobEasyWithGOC.Data;
using JobEasyWithGOC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoC.WebTemplate.Components.Core.Services;
using JobEasyWithGOC.Data.Interfaces;
using AutoMapper;
using JobEasyWithGOC.Data.DataModel;

namespace JobEasyWithGOC.Controllers
{
    public class JobController : ExtendedBaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IJobPostRepository _jobPostRepository;
        private readonly    IMapper _mapper;
        public JobController(ApplicationDbContext db, ModelAccessor modelAccessor, IMapper mapper, IJobPostRepository jobPostRepository) : base(modelAccessor)
        {
            _db = db;
            _jobPostRepository = jobPostRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<JobPostViewModel> objJobPostList  = _mapper.Map<List<JobPostViewModel>>(_db.JobPosts.ToList());
            

            return View(objJobPostList);
        }

        //GET
        public IActionResult Create()
        {


            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobPostViewModel obj)
        {
            
            if (ModelState.IsValid)
            {
                var jobpost = _mapper.Map<JobPost>(obj);
                _jobPostRepository.RegisterAsync(jobpost);
                TempData["success"] = "JobPost created successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        
        //GET
        public IActionResult Edit(string id)
        {   
            
            if (id == null)
            {
                return NotFound();
            }
            var JobPostformDb = _jobPostRepository.GetJobPostAsync(Int16.Parse(id));
            if (JobPostformDb == null)
            {
                return NotFound();
            }
            var jobpost = _mapper.Map<JobPostViewModel>(JobPostformDb.Result);

            return View(jobpost);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit
            (JobPostViewModel obj)
        {
          
            if (ModelState.IsValid)
            {
                var jobpost =_jobPostRepository.EditJobPostAsync(_mapper.Map<JobPost>(obj));
                TempData["success"] = "JobPost updated successfully.";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var JobPostformDb = _jobPostRepository.GetJobPostAsync(Int16.Parse(id));
            if (JobPostformDb == null)
            {
                return NotFound();
            }
            var jobpost = _mapper.Map<JobPostViewModel>(JobPostformDb.Result);

            return View(jobpost);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(JobPostViewModel obj)
        {


            
                var jobpost = _jobPostRepository.DeactivateJobPostAsync(_mapper.Map<JobPost>(obj).Id);
                TempData["success"] = "JobPost updated successfully.";

                return RedirectToAction("Index");
          
        }


        public IActionResult Detail(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var JobPostformDb = _jobPostRepository.GetJobPostAsync(Int16.Parse(id));
            if (JobPostformDb == null)
            {
                return NotFound();
            }
            var jobpost = _mapper.Map<JobPostViewModel>(JobPostformDb.Result);

            return View(jobpost);
        }

    }
}