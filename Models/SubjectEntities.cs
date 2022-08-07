using System;
using System.ComponentModel.DataAnnotations;
using WorkFollow.Models.Base;

namespace WorkFollow.Models
{
    public class SubjectEntities : User
    {
        public string Title { get; set; }
        public string Content { get; set; }
     
    }   
}
