using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class TechAnswer
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("TechOption"), Column(Order = 1)]
        public int OptionId { get; set; }

        [ForeignKey("TechOption"), Column(Order = 0)]
        public int QuestionId { get; set; }

        [JsonIgnore]
        public virtual TechOption TechOption { get; set; }
    }
}