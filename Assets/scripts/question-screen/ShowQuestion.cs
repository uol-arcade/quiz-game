using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    public TMPro.TMP_Text questionNumberText;
    public TMPro.TMP_Text questionTitleText;

    public TMPro.TMP_Text questionAnswerAText;
    public TMPro.TMP_Text questionAnswerBText;
    public TMPro.TMP_Text questionAnswerCText;
    public TMPro.TMP_Text questionAnswerDText;

    public TMPro.TMP_Text[] answerLabels;

    public Color playerColor;
    public Color chaserColor;

    // Start is called before the first frame update
    void Start()
    {
        questionNumberText.text = $"Question {5}";
        questionTitleText.text  = "Who was the xyz?";
        //---
        questionAnswerAText.text = "Angus";
        questionAnswerBText.text = "Bill";
        questionAnswerCText.text = "Charlie";
        questionAnswerDText.text = "Dave";
    }

    public void ShowAnswers(int chaserIndex, int playerIndex)
    {
        answerLabels[chaserIndex].color = chaserColor;
        answerLabels[playerIndex].color = playerColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
