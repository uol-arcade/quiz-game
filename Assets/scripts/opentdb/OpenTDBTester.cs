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
        public TMPro.TMP_Text questionText;
        public TMPro.TMP_Text[] answerTexts;

        private List<Question> questions;

        public void Start()
        {
            var session = new Session();
            questions = session.GetQuestions(10, session.categories[0].id, "easy", Question.QuestionType.MultipleChoice);

            LoadRandomQuestion(ref questions);
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
                LoadRandomQuestion(ref questions);
        }

        public void LoadRandomQuestion(ref List<Question> questions)
        {
            var randomQuestion = questions[Random.Range(0, questions.Count)];
            questionText.text = randomQuestion.question;

            var answers = randomQuestion.GetRandomisedAnswers();

            for(var i = 0; i < answerTexts.Length; i++)
            {
                answerTexts[i].color = Color.white;
                answerTexts[i].text = answers[i];

                if(answers[i] == randomQuestion.correct_answer)
                    answerTexts[i].color = Color.yellow;
            }

        }
    }
}