using JobEasyWithGOC.Data;
using JobEasyWithGOC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoC.WebTemplate.Components.Core.Services;
using JobEasyWithGOC.Data.Interfaces;
using AutoMapper;
using JobEasyWithGOC.Data.DataModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JobEasyWithGOC.Controllers
{
    public class ApplicationController : ExtendedBaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IApplicationRepository _ApplicationRepository;
        private readonly    IMapper _mapper;
        public ApplicationController(ApplicationDbContext db, ModelAccessor modelAccessor, IMapper mapper, IApplicationRepository ApplicationRepository) : base(modelAccessor)
        {
            _db = db;
            _ApplicationRepository = ApplicationRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        { 

            IEnumerable<ApplicationViewModel> objApplicationList  = _mapper.Map<List<ApplicationViewModel>>(_db.Applications.Include(i => i.JobPost).Include(i => i.Company).Include(i => i.Applicant).ThenInclude(i => i.Country).Include(i => i.Applicant).ThenInclude(i => i.Province).ToList());
            

            return View(objApplicationList);
        }

        //GET
        public IActionResult Create()
        {

            var Application = new ApplicationViewModel();
            Application.JobPostList = _mapper.Map<List<JobPostViewModel>>(_db.JobPosts).Select(dc => new SelectListItem { Text = dc.JobTitle, Value = dc.JobTitle }).ToList();
            Application.CompanyList = _mapper.Map<List<CompanyViewModel>>(_db.Companys).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();
            Application.ApplicantList = _mapper.Map<List<ApplicantViewModel>>(_db.Applicants).Select(dc => new SelectListItem { Text = dc.FirstName, Value = dc.FirstName }).ToList();

            return View(Application);
            }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationViewModel application)
        {
            var obj = _mapper.Map<Application>(application);
            foreach (var a in _db.Applicants.ToList())
            {
                if (a.FirstName == obj.Applicant.FirstName)
                {
                    obj.Applicant = a;
                }
            }
            foreach (var c in _db.Companys.ToList())
            {
                if (c.Name == obj.Company.Name)
                {
                    obj.Company = c;
                }
            }
            foreach (var j in _db.JobPosts.ToList())
            {
                if (j.JobTitle == obj.JobPost.JobTitle)
                {
                    obj.JobPost = j;
                }
            }
            
           
                
                
                _ApplicationRepository.RegisterAsync(obj);
                TempData["success"] = "Application created successfully.";
                return RedirectToAction("Index");
      
        }

        
        //GET
        public IActionResult Edit(string id)
        {   
            
            if (id == null)
            {
                return NotFound();
            }
            var ApplicationformDb = _ApplicationRepository.GetApplicationAsync(Int16.Parse(id));


            if (ApplicationformDb == null)
            {
                return NotFound();
            }
            var Application = _mapper.Map<ApplicationViewModel>(ApplicationformDb.Result);

            Application.JobPostList = _mapper.Map<List<JobPostViewModel>>(_db.JobPosts).Select(dc => new SelectListItem { Text = dc.JobTitle, Value = dc.JobTitle }).ToList();
            Application.CompanyList = _mapper.Map<List<CompanyViewModel>>(_db.Companys).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();
            Application.ApplicantList = _mapper.Map<List<ApplicantViewModel>>(_db.Applicants).Select(dc => new SelectListItem { Text = dc.FirstName, Value = dc.FirstName }).ToList();
 

            return View(Application);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit
            (ApplicationViewModel application)
        {
            var obj = _mapper.Map<Application>(application);
            foreach (var a in _db.Applicants.ToList())
            {
                if (a.FirstName == obj.Applicant.FirstName)
                {
                    obj.Applicant = a;
                }
            }
            foreach (var c in _db.Companys.ToList())
            {
                if (c.Name == obj.Company.Name)
                {
                    obj.Company = c;
                }
            }
            foreach (var j in _db.JobPosts.ToList())
            {
                if (j.JobTitle == obj.JobPost.JobTitle)
                {
                    obj.JobPost = j;
                }
            }
            //if (ModelState.IsValid)
            //{
                var Application =_ApplicationRepository.EditApplicationAsync(_mapper.Map<Application>(obj));
                TempData["success"] = "Application updated successfully.";

                return RedirectToAction("Index");
            //}
            //return View(obj);
        }

        //GET
        public IActionResult Delete(string id)
        {


            if (id == null)
            {
                return NotFound();
            }
            var ApplicationformDb = _ApplicationRepository.GetApplicationAsync(Int16.Parse(id));
            if (ApplicationformDb == null)
            {
                return NotFound();
            }
            var Application = _mapper.Map<ApplicationViewModel>(ApplicationformDb.Result);
            Application.JobPostList = _mapper.Map<List<JobPostViewModel>>(_db.JobPosts).Select(dc => new SelectListItem { Text = dc.JobTitle, Value = dc.JobTitle }).ToList();
            Application.CompanyList = _mapper.Map<List<CompanyViewModel>>(_db.Companys).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();
            Application.ApplicantList = _mapper.Map<List<ApplicantViewModel>>(_db.Applicants).Select(dc => new SelectListItem { Text = dc.FirstName, Value = dc.FirstName }).ToList();

            return View(Application);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete
            (ApplicationViewModel obj)
        {

            //if (ModelState.IsValid)
            //{
                var Application = _ApplicationRepository.DeactivateApplicationAsync(_mapper.Map<Application>(obj).Id);
                TempData["success"] = "Application updated successfully.";

                return RedirectToAction("Index");
            //}
            //return View(obj);
        }

        public IActionResult Detail(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var ApplicationformDb = _ApplicationRepository.GetApplicationAsync(Int16.Parse(id));
            if (ApplicationformDb == null)
            {
                return NotFound();
            }
            var Application = _mapper.Map<ApplicationViewModel>(ApplicationformDb.Result);


            return View(Application);
        }

    }
}