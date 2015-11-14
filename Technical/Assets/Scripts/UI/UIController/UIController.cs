using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameObject gameStartPanel;
    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;
    public GameObject playObject;
    public GameObject overObject;
	// Use this for initialization

    void Awake()
    {
        GameData.Instance.LoadGameData();
    }

	void Start () {
        
        Init();
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public void Init()
    {
        gameStartPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        playObject.SetActive(false);
        overObject.SetActive(false);
    }
    public void Play()
    {
        gameStartPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        playObject.SetActive(true);
        GameController.Instance.isStopSpawnEnemy = false;
        GameController.Instance.GamePlay();
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
        gameStartPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        overObject.SetActive(false);
        gamePlayPanel.SetActive(true);
        GameController.Instance.GameReplay();
        playObject.SetActive(true);
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
