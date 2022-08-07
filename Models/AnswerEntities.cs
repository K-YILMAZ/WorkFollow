using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkFollow.Models.Base;

namespace WorkFollow.Models
{
    public class AnswerEntities :User
    {

        public string Content { get; set; }
        public long SubjectId { get; set; }
    }
}
