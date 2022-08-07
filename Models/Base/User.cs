using System;
using System.ComponentModel.DataAnnotations;

namespace WorkFollow.Models.Base
{
    public abstract class User 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
