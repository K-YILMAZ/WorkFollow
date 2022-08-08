using Business.Abstract;
using Business.Concrete.Answer;
using Business.Concrete.DependencyResolvers.Ninject;
using Business.Concrete.Subject;
using Data.Abstract;
using Data.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WorkFollow.Content;
using WorkFollow.Models;

namespace WorkFollow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
      
        public IActionResult Index()
        {
            var a = SubjectUIHelper.GetPagenation(1);
            return View(a);
        }

        [HttpPost]
        public IActionResult Index(int CurrentPage)
        {
            return View(SubjectUIHelper.GetAll(CurrentPage));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SubjectAdds(IFormCollection keys)
        {
            if (SubjectUIHelper.Add(keys))
            {

            }
            return RedirectToAction("Index");


        }
        [HttpGet]
        public PartialViewResult GetSubjectPartial(long id)
        {
            id = id == 0 ? 11 : id;
            return PartialView("~/Views/Partial/SubjectsPartial.cshtml", SubjectUIHelper.GetAll(id));
        }

        public PartialViewResult GetAnswer(long id)
        {
            List<AnswerEntities> answerEntities = AnswerUIHelper.GetAll(id);
            if (AnswerUIHelper.GetAll(id).Count == 0)
            {
                answerEntities = new List<AnswerEntities> { new AnswerEntities { SubjectId = id } };
            }
            return PartialView("~/Views/Partial/AnswersPartial.cshtml", answerEntities);
        }


        [HttpPost]
        [AllowAnonymous]
        public PartialViewResult AnswersAdds(AnswerEntities answerEntities)
        {
            answerEntities.Date = DateTime.Now;
            AnswerUIHelper.Add(answerEntities);

            return GetAnswer(answerEntities.SubjectId);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
