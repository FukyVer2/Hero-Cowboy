using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController> {

	// Use this for initialization
    public Cowboy heroCowboy;
    public bool isStopSpawnEnemy;
    public UIController uiController;
    public SpawnEnemy spaenEnemy;
    public float gold = 0;

	void Start () {
        AudioController.Instance.PlaySoundRepeat(AudioType.SOUND_BG_INGAME);
	}
	
	// Update is called once per frame
	void Update () {
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
        PoolObject.Instance.DeActivePool("Coin");
        heroCowboy.health.HP(300);
        StopSpawnEnemy();
        uiController.GameOver();
    }
    public void ResetTest()
    {
        PoolObject.Instance.DeActivePool("Enemy");
        PoolObject.Instance.DeActivePool("Number");
        PoolObject.Instance.DeActivePool("Particle");
        PoolObject.Instance.DeActivePool("Bullet");
    }
    public void InsteadBullet(bool isActive)
    {
        ManagerObject.Instance.insteadBullet.Reset();
        //insteadBullet.gameObject.SetActive(isActive);
        ManagerObject.Instance.insteadBullet.transform.parent.gameObject.SetActive(isActive);
    }

    public float Gold()
    {
        return gold / 100.0f;
    }
    public void AddGold(float _gold)
    {
        gold += _gold;
        SaveGold();
    }
    public void SaveGold()
    {
        PlayerPrefs.SetFloat("Gold", Gold());
        PlayerPrefs.Save();
    }
}
