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

namespace JobEasyWithGOC.Controllers
{
    public class ApplicantController : ExtendedBaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IApplicantRepository _ApplicantRepository;
        private readonly    IMapper _mapper;
        public ApplicantController(ApplicationDbContext db, ModelAccessor modelAccessor, IMapper mapper, IApplicantRepository ApplicantRepository) : base(modelAccessor)
        {
            _db = db;
            _ApplicantRepository = ApplicantRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicantViewModel> objApplicantList  = _mapper.Map<List<ApplicantViewModel>>(_db.Applicants.ToList());
            

            return View(objApplicantList);
        }

        //GET
        public IActionResult Create()
        {

            var applicant = new ApplicantViewModel();
            applicant.Countrylist = _mapper.Map<List<CountryViewModel>>(_db.Countries).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Id.ToString()}).ToList();
            applicant.Provincelist = _mapper.Map<List<ProvinceViewModel>>(_db.Provinces).Select(dc => new SelectListItem{ Text = dc.Name, Value = dc.Id.ToString() }).ToList();
            return View(applicant);
            }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicantViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var Applicant = _mapper.Map<Applicant>(obj);
                foreach (var c in _db.Countries.ToList())
                {
                    if (c.Name == Applicant.Country.Name)
                    {
                        Applicant.Country = c;
                    }
                }
                foreach (var p in _db.Provinces.ToList())
                {
                    if (p.Name == Applicant.Province.Name)
                    {
                        Applicant.Province = p;
                    }
                }


                _ApplicantRepository.RegisterAsync(Applicant);
                TempData["success"] = "Applicant created successfully.";
                return RedirectToAction("Index");
            }
            obj.Countrylist = _db.Countries.Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name}).ToList();
            obj.Provincelist = _db.Provinces.Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();
            return View(obj);
        }

        
        //GET
        public IActionResult Edit(string id)
        {   
            
            if (id == null)
            {
                return NotFound();
            }
            var ApplicantformDb = _ApplicantRepository.GetApplicantAsync(Int16.Parse(id));
            if (ApplicantformDb == null)
            {
                return NotFound();
            }
            var Applicant = _mapper.Map<ApplicantViewModel>(ApplicantformDb.Result);
            Applicant.Countrylist = _mapper.Map<List<CountryViewModel>>(_db.Countries).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();
            Applicant.Provincelist = _mapper.Map<List<ProvinceViewModel>>(_db.Provinces).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();

            return View(Applicant);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit
            (ApplicantViewModel obj)
        {
          
            if (ModelState.IsValid)
            {
                var Applicant =_ApplicantRepository.EditApplicantAsync(_mapper.Map<Applicant>(obj));
                TempData["success"] = "Applicant updated successfully.";

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
            var ApplicantformDb = _ApplicantRepository.GetApplicantAsync(Int16.Parse(id));
            if (ApplicantformDb == null)
            {
                return NotFound();
            }
            var Applicant = _mapper.Map<ApplicantViewModel>(ApplicantformDb.Result);
            Applicant.Countrylist = _mapper.Map<List<CountryViewModel>>(_db.Countries).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();
            Applicant.Provincelist = _mapper.Map<List<ProvinceViewModel>>(_db.Provinces).Select(dc => new SelectListItem { Text = dc.Name, Value = dc.Name }).ToList();

            return View(Applicant);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete
            (ApplicantViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var Applicant = _ApplicantRepository.DeactivateApplicantAsync(_mapper.Map<Applicant>(obj).Id);
                TempData["success"] = "Applicant updated successfully.";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Detail(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var ApplicantformDb = _ApplicantRepository.GetApplicantAsync(Int16.Parse(id));
            if (ApplicantformDb == null)
            {
                return NotFound();
            }
            var Applicant = _mapper.Map<ApplicantViewModel>(ApplicantformDb.Result);

            return View(Applicant);
        }
        //GET
        public IActionResult Apply(string id)
        {

            
            var ApplicantformDb = _ApplicantRepository.GetApplicantAsync(Int16.Parse(id));
            if (ApplicantformDb == null)
            {
                return NotFound();
            }
            var Applicant = _mapper.Map<ApplicantViewModel>(ApplicantformDb.Result);
            Applicant.JobPostList = _mapper.Map<List<JobPostViewModel>>(_db.JobPosts.ToList());

            return View(Applicant);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply
            (ApplicantViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var Applicant = _ApplicantRepository.DeactivateApplicantAsync(_mapper.Map<Applicant>(obj).Id);
                TempData["success"] = "Applicant updated successfully.";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }

}