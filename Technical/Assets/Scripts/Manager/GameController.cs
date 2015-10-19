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
    public float gold = 0;

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
        PoolObject.Instance.DeActivePool("Coin");
        heroCowboy.health.HP(300);
        spaenEnemy.Reset();
        StopSpawnEnemy();
        uiController.GameOver();
    }
    public void ResetTest()
    {
        PoolObject.Instance.DeActivePool("Enemy");
        PoolObject.Instance.DeActivePool("Number");
        PoolObject.Instance.DeActivePool("Particle");
        PoolObject.Instance.DeActivePool("Bullet");
        spaenEnemy.Reset();
    }
    public void InsteadBullet(bool isActive)
    {
        ManagerObject.Instance.insteadBullet.Reset();
        //insteadBullet.gameObject.SetActive(isActive);
        ManagerObject.Instance.insteadBullet.transform.parent.gameObject.SetActive(isActive);
    }
    void SetText()
    {
        if (spaenEnemy != null && spaenEnemy.active == true)
        {
            string luot = spaenEnemy.GetSoLuot().ToString();
            txtLuot.text = luot + "/10";
        }
    }
    public float Gold()
    {
        return gold / 1000.0f;
    }
    public void AddGold(float _gold)
    {
        gold += _gold;
    }
    public void SaveGold()
    {
        PlayerPrefs.SetFloat("Gold", Gold());
        PlayerPrefs.Save();
    }
}
