using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameObject gameStartPanel;
    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;
    public GameObject playObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Play()
    {
        gameStartPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        playObject.SetActive(true);
    }
    public void GameOver()
    {
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void GameRelay()
    {
        Application.LoadLevel(Application.loadedLevel);
        //gameOverPanel.SetActive(false);
        //gamePlayPanel.SetActive(true);
    }
    public void GameMenu()
    {
        gameStartPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    public void GamePause()
    { }
}
