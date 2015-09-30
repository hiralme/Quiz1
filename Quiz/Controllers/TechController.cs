using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Quiz.Models;

namespace Quiz.Controllers
{
    [Authorize]
    public class TechController : ApiController
    {
        private TechContext db = new TechContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        //This method retrieves next quiz question from the database to be answered by the specified user
        private async Task<TechQuestion> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await this.db.TechAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => new { q.Count, QuestionId = q.QuestionId })
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();
            
            var questionsCount = await this.db.TechQuestions.CountAsync();

               var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            if (nextQuestionId != questionsCount)
            {
                return await this.db.TechQuestions.FindAsync(CancellationToken.None, nextQuestionId);
            }
            return null;
        }

        // This action method calls the NextQuestionAsync helper method defined in the previous step to retrieve 
        //the next question for the authenticated user.
        [ResponseType(typeof(TechQuestion))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;

            TechQuestion nextQuestion = await this.NextQuestionAsync(userId);
            
            if (nextQuestion == null)
            {
                var result = (from p in this.db.TechAnswers
                              join c in this.db.TechOptions on p.OptionId equals c.Id
                              where c.IsCorrect == true && p.UserId == userId
                              select p).Count();

                var questionsCount = await this.db.TechQuestions.CountAsync();

                TechQuestion EndQuiz = new TechQuestion();

                EndQuiz.Title = string.Format
                    ("Your score is {0} out of {1} !!!", result.ToString(), questionsCount.ToString());
                EndQuiz.Options = null;
                return this.Ok(EndQuiz);
            }           
            return this.Ok(nextQuestion);
        }

        // This method stores the specified answer in the database and returns a Boolean value indicating 
        //whether the answer is correct or not.
        private async Task<bool> StoreAsync(TechAnswer answer)
        {
            this.db.TechAnswers.Add(answer);

            await this.db.SaveChangesAsync();
            var selectedOption = await this.db.TechOptions.FirstOrDefaultAsync(o => o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            return selectedOption.IsCorrect;
        }

        // This action method associates the answer to the authenticated user and calls the StoreAsync helper method. 
        //And it sends a response with the Boolean value returned by the helper method.
        [ResponseType(typeof(TechAnswer))]
        public async Task<IHttpActionResult> Post(TechAnswer answer)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            answer.UserId = User.Identity.Name;

            var isCorrect = await this.StoreAsync(answer);
            return this.Ok<bool>(isCorrect);
        }

    }
}
