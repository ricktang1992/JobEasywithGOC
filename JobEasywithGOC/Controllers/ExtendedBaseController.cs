using GoC.WebTemplate.Components.Configs;
using GoC.WebTemplate.Components.Core.Services;
using GoC.WebTemplate.Components.Entities;
using GoC.WebTemplate.CoreMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace JobEasyWithGOC.Controllers
{
    public class ExtendedBaseController : WebTemplateBaseController
    {
        //private readonly ILogger<ExtendedBaseController> _logger;

        public ExtendedBaseController(ModelAccessor modelAccessor)
            : base(modelAccessor)
        {
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));

            //Set a the common title for everypage here
            if (WebTemplateModel.TwoLetterCultureLanguage == "en")
            {
                WebTemplateModel.HeaderTitle = "Job Finding Website";
            }
            else
            {
                WebTemplateModel.HeaderTitle = "Job Finding Website (fr)";
            }
            //Metatags
            WebTemplateModel.HTMLHeaderElements.Add("<meta charset='UTF-8'>");
            WebTemplateModel.HTMLHeaderElements.Add("<meta http-equiv='default-style' content='sample'>");

            //Date Modifiied
            WebTemplateModel.DateModified = new DateTime(2020, 04, 21);

            //Version Identifier
            WebTemplateModel.VersionIdentifier = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            //Screen Identifier
            //WebTemplateModel.ScreenIdentifier = "BASE-SETTING-SAMPLE";

            //Contact Links
            //WebTemplateModel.ContactLinks.Add(new GoC.WebTemplate.Components.Entities.Link { Text="Contact", Href = "http://travel.gc.ca/" });

            //WebTemplateModel.Settings.Environment = "PROD_SSL";

            //WebTemplateModel.HTMLHeaderElements.Add("<link rel='stylesheet' type='text/css' href='/css/site.css'>");
            WebTemplateModel.HTMLHeaderElements.Add("<link rel='stylesheet' href='https://use.fontawesome.com/releases/v5.8.1/css/all.css' integrity='sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf' crossorigin='anonymous'>");
            WebTemplateModel.ApplicationTitle.Text = "Job Easy";
            WebTemplateModel.ApplicationTitle.Href = "../Home";


            //custom intranet title
            //WebTemplateModel.IntranetTitle = new IntranetTitle
            //{
            //    Href = "http://mytc",
            //    BoldText = "HR",
            //    Acronym = "Human Resource",
            //    Text = " CMS"
            //};

            WebTemplateModel.Settings.ShowPreContent = false;
            //WebTemplateModel.HTMLBodyElements.Add("<script src='/js/site.js'></script>");

        }

    }
}