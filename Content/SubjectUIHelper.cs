using Business.Abstract;
using Business.Concrete.Subject;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WorkFollow.Models;

namespace WorkFollow.Content
{
    public static class SubjectUIHelper
    {
        public static List<SubjectEntities> GetAll(ISubjectService subjectService, long pageIndex)
        {
            var data = subjectService.GetAll("Select * From Subjects order by Id desc Offset " + (5 * (pageIndex - 1)) + " Rows fetch next " + 5 + " rows only Select Count(*) as totalcount from Subjects");

            var convertData = System.Text.Json.JsonSerializer.Serialize(data);
            return JsonConvert.DeserializeObject<List<SubjectEntities>>(convertData);
        }

        public static Pagenation GetPagenation(ISubjectService subjectService, int pageIndex)
        {
            long dataCount = subjectService.GetAllCount("Select Count(*) from Subjects");
            return new Models.Pagenation
            {
                CurrentIndex = pageIndex,
                PageCount = Convert.ToInt32(dataCount) / 5

            };
        }

        public static bool Add(IFormCollection keys, ISubjectService subjectService)
        {
            SubjectEntities subjectEntities = new SubjectEntities
            {
                Content = keys["Content"],
                Date = DateTime.Now,
                Email = keys["Email"],
                Name = keys["Name"],
                Surname = keys["Surname"],
                Title = keys["Title"]
            };
            return SubjectHelper.Add(System.Text.Json.JsonSerializer.Serialize(subjectEntities), subjectService);
        }
    }
}
