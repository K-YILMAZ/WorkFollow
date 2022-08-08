using Business.Abstract;
using Business.Concrete.Answer;
using Business.Concrete.Subject;
using Data.Abstract;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WorkFollow.Models;

namespace WorkFollow.Content
{
    public static class AnswerUIHelper
    {
        public static List<AnswerEntities> GetAll(long SubjectId)
        {
            var data = AnswerHelper.GetAll("Select * From Answers Where SubjectId=" + SubjectId);
            var convertData = System.Text.Json.JsonSerializer.Serialize(data);
            return JsonConvert.DeserializeObject<List<AnswerEntities>>(convertData);
        }

        public static bool Add(AnswerEntities answerEntities)
        {
                var data = System.Text.Json.JsonSerializer.Serialize(answerEntities);

                return AnswerHelper.Add(data);
        }
    }
}
