using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class TechOption
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Key, Column(Order = 0), ForeignKey("TechQuestion")]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual TechQuestion TechQuestion { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }
    }
}