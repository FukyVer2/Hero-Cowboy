using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController> {

	// Use this for initialization
    public Cowboy heroCowboy;
    public bool isStopSpawnEnemy;
    public UIController uiController;
    public Text txtLuot;
    public SpawnEnemy spaenEnemy;

	void Start () {
        AudioController.Instance.PlaySoundRepeat(AudioType.SOUND_BG_INGAME);
	}
	
	// Update is called once per frame
	void Update () {
        SetText();
	}
    void StopSpawnEnemy()
    {
        isStopSpawnEnemy = true;
    }
    public void GameWin()
    {
        PoolObject.Instance.DeActivePool("Enemy");
        PoolObject.Instance.DeActivePool("Number");
        PoolObject.Instance.DeActivePool("Particle");
        PoolObject.Instance.DeActivePool("Bullet");
        spaenEnemy.Reset();
        StopSpawnEnemy();
        uiController.GameOver();
    }
    void SetText()
    {
        if (spaenEnemy != null && spaenEnemy.active == true)
        {
            string luot = spaenEnemy.GetSoLuot().ToString();
            txtLuot.text = luot + "/10";
        }
    }
}
