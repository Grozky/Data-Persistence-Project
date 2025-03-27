using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public static GameData data;

    public string playerName;

    private static string saveFile;

    public static int nHighScores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            nHighScores = 3;
            data = new GameData();
            data.highScores = new List<Score>();
            saveFile = Application.persistentDataPath + "/gamedata.json";
            LoadHighScores();
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    private void SaveHighScores()
    {
        Debug.Log("Saving at " + saveFile);
        Debug.Log("List: " + data.highScores);
        string jsonString = JsonUtility.ToJson(data);
        Debug.Log("String: " + jsonString);
        File.WriteAllText(saveFile, jsonString);
    }

    private void LoadHighScores()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);

            Debug.Log(fileContents);

            data = JsonUtility.FromJson<GameData>(fileContents);

            
            Debug.Log(JsonUtility.FromJson<List<Score>>(fileContents));
        }
        else
        {
            data.highScores = new List<Score>();
        }
    }

    public void UpdateHighscore(int score)
    {
        int i = data.highScores.Count - 1;

        if (i == -1)    // If the highScores list is empty
        {
            Score toAdd = new Score();
            toAdd.score = score;
            toAdd.name = playerName;
            data.highScores.Add(toAdd);
            SaveHighScores();
            return;
        }

        while (i >= 0 && data.highScores[i].score < score)
        {
            i--;
        }

        i++;
        if (i >= 0 && i < data.highScores.Count)
        {
            Score toAdd = new Score();
            toAdd.score = score;
            toAdd.name = playerName;
            data.highScores.Insert(i, toAdd);
            if (data.highScores.Count > nHighScores)
            {
                data.highScores.RemoveAt(data.highScores.Count - 1);
            }
            SaveHighScores();
        }
    }

    [System.Serializable]
    public class Score{
        public string name;
        public int score;
    }

    [System.Serializable]
    public class GameData{
        public List<Score> highScores;
    }
}
