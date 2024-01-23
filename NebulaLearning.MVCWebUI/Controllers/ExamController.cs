﻿using NebulaLearning.Business.Net4x.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NebulaLearning.MVCWebUI.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        private IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        public ActionResult Index()
        {
            var model = new ExamListViewModel // generate new type-yeni tür oluşturdan hızlı yaplır
            {
                Exams = _examService.GetExamList()
            };
            return View(model);
            //return View(_examService.GetExamList()); DirtyCode
        }
    }
}