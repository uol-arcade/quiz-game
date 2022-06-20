using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenTDB
{
    public class Session
    {
        public SessionToken sessionToken;
        public Config config = Config.DefaultConfig;
        public Category[] categories;

        public Session()
        {
            this.sessionToken = new SessionToken(ref config);
            this.categories = Category.GetCategories(ref config);
        }

        public List<Question> GetQuestions(int amount, int categoryID, string difficulty)
            => Question.GetQuestions(ref this.sessionToken, ref config, amount, categoryID, difficulty);

        public List<Question> GetQuestions(int amount, int categoryID, string difficulty, Question.QuestionType questionType)
        {
            if (questionType == Question.QuestionType.MultipleChoice)
                return Question.GetQuestions(ref this.sessionToken, ref config, amount, categoryID, difficulty, "&type=multiple");
            
            else
                return Question.GetQuestions(ref this.sessionToken, ref config, amount, categoryID, difficulty, "&type=boolean");
        }

    }
}