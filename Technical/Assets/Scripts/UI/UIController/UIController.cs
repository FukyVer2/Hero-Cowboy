using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameObject gameStartPanel;
    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;
    public GameObject playObject;
    public GameObject overObject;
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
        GameController.Instance.isStopSpawnEnemy = false;
    }
    public void GameOver()
    {
        
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        playObject.SetActive(false);
        overObject.SetActive(true);
    }
    public void GameRelay()
    {
        gameStartPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        overObject.SetActive(false);
        //Application.LoadLevel(Application.loadedLevel);
       
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
