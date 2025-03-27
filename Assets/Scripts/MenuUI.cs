using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClicked()
    {
        TMP_InputField textInput = GameObject.Find("Canvas/Name Input").GetComponent<TMP_InputField>();
        Debug.Log(GameObject.Find("Canvas/Name Input").GetComponent<TMP_InputField>());
        PersistenceManager.Instance.playerName = textInput.text;
        SceneManager.LoadScene(1);
    }

    public void SeeHighScoreClicked()
    {
        SceneManager.LoadScene(2);
    }
}
