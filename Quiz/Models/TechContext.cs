using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
   public class TechContext : DbContext
    {
        public TechContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<TechQuestion> TechQuestions { get; set; }
        public DbSet<TechOption> TechOptions { get; set; }
        public DbSet<TechAnswer> TechAnswers { get; set; }
    }

   public class TechDatabaseInitializer : CreateDatabaseIfNotExists<TechContext>
   {
       protected override void Seed(TechContext context)
       {
           base.Seed(context);

           var questions = new List<TechQuestion>();

           questions.Add(new TechQuestion
           {
               Title = "What does HTML stand for?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "Hyperlinks and Text Markup Language", IsCorrect= false },
                    new TechOption { Title= "Hyper Text Markup Language", IsCorrect= true },
                    new TechOption { Title= "Home Tool Markup Language", IsCorrect= false },
                    new TechOption { Title= "Home Text Markup Language", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "Who is making the Web standards?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "Microsoft", IsCorrect= false },
                    new TechOption { Title= "Google", IsCorrect= false },
                    new TechOption { Title= "The World Wide Web Consortium", IsCorrect= true },
                    new TechOption { Title= "Mozilla", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "What does HTML stand for?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "Standard Query Language", IsCorrect= true },
                    new TechOption { Title= "Standard Question Language", IsCorrect= false },
                    new TechOption { Title= "Start Question League", IsCorrect= false },
                    new TechOption { Title= "Start Question Language", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "Which is not actually a Thing.js?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "Mustache.js", IsCorrect= false },
                    new TechOption { Title= "Hammer.js", IsCorrect= false },
                    new TechOption { Title= "Horseradish.js", IsCorrect= true },
                    new TechOption { Title= "Uglify.js", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "In what year was the first Voice Over IP (VOIP) call made?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "1973", IsCorrect= true },
                    new TechOption { Title= "1982", IsCorrect= false },
                    new TechOption { Title= "1991", IsCorrect= false },
                    new TechOption { Title= "1994", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "\"Chicago\" was codename for what Microsoft product?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "Visual Basic", IsCorrect= false },
                    new TechOption { Title= "Microsoft Surface", IsCorrect= false },
                    new TechOption { Title= "Windows 95", IsCorrect= true },
                    new TechOption { Title= "Xbox", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "How many loop constructs are there in C#?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "2", IsCorrect= false },
                    new TechOption { Title= "3", IsCorrect= false },
                    new TechOption { Title= "4", IsCorrect= true },
                    new TechOption { Title= "5", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "What was the first CodePlex.com project?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "EntLib", IsCorrect= false },
                    new TechOption { Title= "IronPython", IsCorrect= true },
                    new TechOption { Title= "Ajax Toolkit", IsCorrect= false },
                    new TechOption { Title= "JSON.Net", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "Last name of the employee who wears Microsoft badge 00001",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "McDonald", IsCorrect= true },
                    new TechOption { Title= "Gates", IsCorrect= false },
                    new TechOption { Title= "Ballmer", IsCorrect= false },
                    new TechOption { Title= "Allen", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "When did Scott Hanselman join Microsoft?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "2007", IsCorrect= true },
                    new TechOption { Title= "2000", IsCorrect= false },
                    new TechOption { Title= "2005", IsCorrect= false },
                    new TechOption { Title= "2009", IsCorrect= false }
                }).ToList()
           });

           questions.Add(new TechQuestion
           {
               Title = "How big is a nibble?",
               Options = (new TechOption[]
                {
                    new TechOption { Title= "4 bits", IsCorrect= true },
                    new TechOption { Title= "8 bits", IsCorrect= false },
                    new TechOption { Title= "16 bits", IsCorrect= false },
                    new TechOption { Title= "2 bits", IsCorrect= false }
                }).ToList()
           });

           
           questions.ForEach(a => context.TechQuestions.Add(a));

           context.SaveChanges();
       }
   }
}