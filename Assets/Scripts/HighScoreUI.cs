using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        List<PersistenceManager.Score> scores = PersistenceManager.data.highScores;
        string textToPrint = "";
        for (int i = 0; i < scores.Count; i++)
        {
            textToPrint += scores[i].name + ": " + scores[i].score + "\n";
        }
        // Add a Text component to the GameObject
        Text label = this.gameObject.AddComponent<Text>();

        // Set the text properties
        label.text = textToPrint;
        label.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        label.fontSize = 24;
        label.color = Color.black;

        // Set the RectTransform properties
        RectTransform rectTransform = label.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(200, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
