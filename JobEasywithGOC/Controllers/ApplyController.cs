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
    public class ApplyController : ExtendedBaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IApplicationRepository _ApplicationRepository;       
        private readonly IMapper _mapper;
        public ApplyController(ApplicationDbContext db, ModelAccessor modelAccessor, IMapper mapper, IApplicationRepository ApplicationRepository) : base(modelAccessor)
        {
            _db = db;
            _ApplicationRepository = ApplicationRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicantViewModel> objApplicantList = _mapper.Map<List<ApplicantViewModel>>(_db.Applicants.ToList());


            return View(objApplicantList);
        }

    }
}