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
    public class CompanyController : ExtendedBaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly ICompanyRepository _CompanyRepository;
        private readonly    IMapper _mapper;
        public CompanyController(ApplicationDbContext db, ModelAccessor modelAccessor, IMapper mapper, ICompanyRepository CompanyRepository) : base(modelAccessor)
        {
            _db = db;
            _CompanyRepository = CompanyRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<CompanyViewModel> objCompanyList  = _mapper.Map<List<CompanyViewModel>>(_db.Companys.ToList());
            

            return View(objCompanyList);
        }

        //GET
        public IActionResult Create()
        {


            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompanyViewModel obj)
        {
            
            if (ModelState.IsValid)
            {
                var company = _mapper.Map<Company>(obj);
                _CompanyRepository.RegisterAsync(company);
                TempData["success"] = "Company created successfully.";
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
            var CompanyformDb = _CompanyRepository.GetCompanyAsync(Int16.Parse(id));
            if (CompanyformDb == null)
            {
                return NotFound();
            }
            var Company = _mapper.Map<CompanyViewModel>(CompanyformDb.Result);

            return View(Company);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit
            (CompanyViewModel obj)
        {
          
            if (ModelState.IsValid)
            {
                var Company =_CompanyRepository.EditCompanyAsync(_mapper.Map<Company>(obj));
                TempData["success"] = "Company updated successfully.";

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
            var CompanyformDb = _CompanyRepository.GetCompanyAsync(Int16.Parse(id));
            if (CompanyformDb == null)
            {
                return NotFound();
            }
            var Company = _mapper.Map<CompanyViewModel>(CompanyformDb.Result);

            return View(Company);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(CompanyViewModel obj)
        {


            
                var Company = _CompanyRepository.DeactivateCompanyAsync(_mapper.Map<Company>(obj).Id);
                TempData["success"] = "Company updated successfully.";

                return RedirectToAction("Index");
          
        }


        public IActionResult Detail(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var CompanyformDb = _CompanyRepository.GetCompanyAsync(Int16.Parse(id));
            if (CompanyformDb == null)
            {
                return NotFound();
            }
            var Company = _mapper.Map<CompanyViewModel>(CompanyformDb.Result);

            return View(Company);
        }

    }
}