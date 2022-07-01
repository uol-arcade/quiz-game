using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionCountdown : MonoBehaviour
{
    public int countdownStart = 10;
    private float startTime = default;

    public TMPro.TMP_Text countdownText;

    public Color startColor;
    public Color endColor;
    public Color highlightColor;

    private bool ended = false;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        ended = false;
    }

    private void onCountdownEnd()
    {
        Debug.Log("countdown ended");
        countdownText.text = " ";

        GetComponent<ShowQuestion>().ShowAnswers(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        var delta = Time.time - startTime;
        var deltaOffset = countdownStart - delta;

        if(!ended && deltaOffset <= 0.0f)
        {
            ended = true;
            onCountdownEnd();
            return;
        }

        if(deltaOffset <= 0.0f)
            return;

        if(Mathf.RoundToInt((deltaOffset % 1) * 10) == 1)
            countdownText.color = highlightColor;
        else
            countdownText.color = Color.Lerp(startColor, endColor, Mathf.InverseLerp(countdownStart, 0, deltaOffset));

        countdownText.text = $"{deltaOffset:f1}";
    }
}
