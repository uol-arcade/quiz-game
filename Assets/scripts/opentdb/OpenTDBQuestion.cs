using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using System.Net;

namespace OpenTDB
{
    [System.Serializable]
    public class Question
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public string[] incorrect_answers; 

        public enum QuestionType
        {
            MultipleChoice, Binary
        }

        public QuestionType questionType
        {
            get { return (incorrect_answers.Length == 1) ? (QuestionType.Binary) : (QuestionType.MultipleChoice); }
            set { ; }
        }

        public string[] GetRandomisedAnswers()
        {
            var answers = new List<string>() { correct_answer };

            foreach(var answer in incorrect_answers)
                answers.Add(answer);

            answers = answers.OrderBy(x => Random.value).ToList();

            return answers.ToArray();
        }        

        public static List<Question> GetQuestions(ref SessionToken token, ref Config config, int amount, int categoryID, string difficulty, string appendStr="")
        {
            string _amount     = Utils.Keypair("amount", amount);
            string _category   = Utils.Keypair("category", categoryID);
            string _difficulty = Utils.Keypair("difficulty", difficulty);
            string _token      = Utils.Keypair("token", token.token);

            var parameters = Utils.GetParamString(config.apiEndpointQuestions, _amount, _category, _difficulty, _token);
            var requestUrl = $"{config.apiBaseURL}{parameters}";
            Debug.Log($"Session.GetQuestions() => {requestUrl}");

            var response = Utils.SendAndGetJson<ResponseQuestion>(requestUrl + appendStr);
            Utils.CheckResponseCode(response.response_code);

            for(int i = 0; i < response.results.Count(); i++)
            {
                response.results[i].question = WebUtility.HtmlDecode(response.results[i].question);
                response.results[i].correct_answer = WebUtility.HtmlDecode(response.results[i].correct_answer);
                response.results[i].incorrect_answers = response.results[i].incorrect_answers.Select(x => WebUtility.HtmlDecode(x)).ToArray();
            }

            return response.results.ToList();
        }
    }
}