using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OpenTDB
{
    [AddComponentMenu("OpenTDB/Tester")]
    public class OpenTDBTester : MonoBehaviour
    {
        public void Start()
        {
            var session = new Session();

            var questions = session.GetQuestions(10, session.categories[0].id, "easy", Question.QuestionType.Binary);

            foreach(var question in questions)
                Debug.Log(question.question);
        }
    }
}