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
    public int level = 0;
    void Awake()
    {
        gold = PlayerPrefs.GetFloat("Gold");
    }
    [ContextMenu("Reset Gold")]
    void ResetGold()
    {
        gold = 0;
        SaveGold();
    }
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
        ResetTest();

        Invoke("DelayGameWin", 7.0f);
    }
    void DelayGameWin()
    {
        heroCowboy.health.HP(HeroCowboyConfigs.HP_PLAYER);
        StopSpawnEnemy();
        uiController.GameOver();
        UIGameOver.Instance.SetTextGold();
    }
    public void ResetTest()
    {
        PoolObject.Instance.DeActivePool("Enemy");
        PoolObject.Instance.DeActivePool("Number");
        PoolObject.Instance.DeActivePool("Particle");
        //PoolObject.Instance.DeActivePool("Bullet");
        //PoolObject.Instance.DeActivePool("Effect");
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
        PlayerPrefs.SetFloat("Gold", gold);
        PlayerPrefs.Save();
    }
    public void LevelUp()
    {
        level += 1;
    }
    public void GameReplay()
    {
        Level.Instance.LevelUp();
    }
}
