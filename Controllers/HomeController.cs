using Business.Abstract;
using Business.Concrete.Answer;
using Business.Concrete.Subject;
using Data.Abstract;
using Data.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ISubjectService _subjectService = new SubjectManager(new SubjectDal());
        private IAnswerService _answerService = new AnswerManager(new AnswerDal());
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var a = SubjectUIHelper.GetPagenation(_subjectService, 1);
            return View(a);
        }

        [HttpPost]
        public IActionResult Index(int CurrentPage)
        {
            return View(SubjectUIHelper.GetAll(_subjectService, CurrentPage));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SubjectAdds(IFormCollection keys)
        {
            if (SubjectUIHelper.Add(keys, _subjectService))
            {

            }
            return RedirectToAction("Index");


        }
        [HttpGet]
        public PartialViewResult GetSubjectPartial(long id)
        {
            id = id == 0 ? 11 : id;
            return PartialView("~/Views/Partial/SubjectsPartial.cshtml", SubjectUIHelper.GetAll(_subjectService, id));
        }

        public PartialViewResult GetAnswer(long id)
        {
            List<AnswerEntities> answerEntities = AnswerUIHelper.GetAll(_answerService, id);
            if (AnswerUIHelper.GetAll(_answerService, id).Count == 0)
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
            AnswerUIHelper.Add(answerEntities, _answerService);

            return GetAnswer(answerEntities.SubjectId);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
