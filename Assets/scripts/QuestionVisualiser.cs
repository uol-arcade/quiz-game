using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionVisualiser : MonoBehaviour
{
    public Color chaseColor = Color.red;
    public Color playerColor = Color.white;

    public Transform playerTextMesh;
    public Transform chaserTextMesh;

    public static int questionAmount = 10;

    public GameObject questionPrefab;
    public GameObject finishLinePrefab;
    public GameObject timelinePrefab;

    public Transform rootObject;

    private List<GameObject> questionObjects = new List<GameObject>();
    
    public Vector3 offsetVector;    
    public Vector3 timelineRot;

    public Color emptyColor = Color.gray;
    public Color chaserOccupiedColor = Color.red;
    public Color playerOccupiedColor = Color.white;

    public enum QuestionState
    {
        ChaserOccupied, PlayerOccupied, Empty
    }

    private List<QuestionState> questionStates = new List<QuestionState>();

    private static int chaserPosition = 0;
    private static int playerPosition = 2;

    // Start is called before the first frame update
    void Start()
    {
        this.setupQuestionState();
        this.spawnQuestionObjects();
        this.spawnTimelineObject();
        this.spawnFinishLineObject();

        this.movePlayer(chaserTextMesh, chaserPosition);
        this.movePlayer(playerTextMesh, playerPosition);
    }

    public void setQuestionState(int index, QuestionState state)
    {
        switch(state)
        {
            case QuestionState.ChaserOccupied:  questionObjects[index].GetComponent<SpriteRenderer>().color = chaserOccupiedColor;
                break;
            
            case QuestionState.PlayerOccupied: questionObjects[index].GetComponent<SpriteRenderer>().color = playerOccupiedColor;
                break;

            case QuestionState.Empty: questionObjects[index].GetComponent<SpriteRenderer>().color = emptyColor;
                break;
        }

        questionStates[index] = state;
    }

    public void setupQuestionState()
    {
        for(var i = 0; i < questionAmount; i++)
            questionStates.Add(QuestionState.Empty);
    }

    public void movePlayer(Transform text, int questionNumber)
    {
        var questionObj = questionObjects[questionNumber];
        var pos = questionObj.transform.position;

        pos.x = text.transform.position.x;
        pos.z = text.transform.position.z;

        text.transform.position = pos;

        this.updateQuestionColors();
    }
    
    private void updateQuestionColors()
    {
        for (var i = 0; i < questionAmount; i++)
        {
            //Chaser position first
            if (i <= chaserPosition)
                questionObjects[i].GetComponent<SpriteRenderer>().color = chaserOccupiedColor;

            else if (i <= playerPosition)
                questionObjects[i].GetComponent<SpriteRenderer>().color = playerOccupiedColor;

            else
                questionObjects[i].GetComponent<SpriteRenderer>().color = emptyColor;
        }
    }

    private void spawnFinishLineObject()
    {
        var calcPos = rootObject.position + (offsetVector * (questionAmount - 1));

        var finishLineObj = GameObject.Instantiate(finishLinePrefab, calcPos, Quaternion.identity);
        finishLineObj.transform.SetParent(rootObject);

        finishLineObj.transform.Translate(-Vector3.up * finishLineObj.transform.localScale.y, Space.World);
    }

    private void spawnTimelineObject()
    {
        var halfwayPoint = rootObject.position + (offsetVector * questionAmount / 2);

        var timelineObj = GameObject.Instantiate(timelinePrefab, halfwayPoint, Quaternion.identity);
        timelineObj.transform.SetParent(rootObject);
        timelineObj.transform.rotation = Quaternion.Euler(timelineRot);

        timelineObj.transform.Translate(Vector3.up * timelineObj.transform.localScale.x / 2, Space.World);
        timelineObj.transform.Translate(Vector3.forward * 5, Space.World);

        var scale = timelineObj.transform.localScale;
        scale.x = offsetVector.magnitude * (questionAmount);

        timelineObj.transform.localScale = scale;
    }

    private void spawnQuestionObjects()
    {
        for(int i = 0; i < questionAmount; i++)
        {
            var calcPos = rootObject.position + offsetVector * i;
            var obj = GameObject.Instantiate(questionPrefab, calcPos, Quaternion.identity);
            obj.transform.SetParent(rootObject);

            questionObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
