using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebLab13.Models;

namespace WebLab13.Controllers
{
    public class QuizController : Controller
    {
        private static List<QuizQuestion> _questions = new List<QuizQuestion>
    {
        new QuizQuestion { Id = 1, Question = "1 - 6 =", CorrectAnswer = -5 },
        new QuizQuestion { Id = 2, Question = "8 + 6 =", CorrectAnswer = 14 },
        new QuizQuestion { Id = 3, Question = "5 - 7 =", CorrectAnswer = -2 },
        new QuizQuestion { Id = 4, Question = "5 - 2 =", CorrectAnswer = 3 }
    };

        [HttpGet("Mockups/Quiz")]
        public IActionResult Quiz(int questionId = 1)
        {
            if (questionId <= _questions.Count)
            {
                var question = _questions[questionId - 1];
                return View("Question", question);
            }
            else
            {
                return Result();
            }
        }

        [HttpPost("Mockups/Quiz")]
        public IActionResult Quiz(int questionId, int userAnswer, bool finish = false)
        {

            if (userAnswer < int.MinValue || userAnswer > int.MaxValue)
            {
                ModelState.AddModelError("UserAnswer", "Please enter a valid number.");
                var question = _questions[questionId - 1];
                return View("Question", question); 
            }

            var questionToUpdate = _questions[questionId - 1];
            questionToUpdate.UserAnswer = userAnswer;

            if (finish) 
            {
                return Result();
            }
            else if (questionId < _questions.Count)
            {
                return RedirectToAction("Quiz", new { questionId = questionId + 1 });
            }
            else
            {
                return Result();
            }
        }

        public IActionResult Result()
        {
            int rightAnswers = 0;

            foreach (var question in _questions)
            {
                if (question.UserAnswer == question.CorrectAnswer)
                {
                    rightAnswers++;
                }
            }

            ViewBag.RightAnswers = rightAnswers;
            return View("Result", _questions);
        }

        public IActionResult Index()
        {
            return Result();
        }
    }
}