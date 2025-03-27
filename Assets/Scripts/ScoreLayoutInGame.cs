using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLayoutInGame : MonoBehaviour
{
    public Text highScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        List<PersistenceManager.Score> scores = PersistenceManager.data.highScores;
        if(scores.Count > 0)
        {
            highScoreText.text = "Best Score => " + scores[0].name + " : " + scores[0].score;
        }
        else
        {
            highScoreText.text = "No previous high score";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
