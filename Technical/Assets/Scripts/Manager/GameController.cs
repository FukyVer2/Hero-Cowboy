﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController> {

	// Use this for initialization
    public Cowboy heroCowboy;
    public bool isStopSpawnEnemy;
    public UIController uiController;
    public float gold = 0;
    public int level = 0;
    public LevelInfo levelInfo;
    public GunController gunController;
    public UpGradePlayer upgradePlayer;
    public GameData gameData;
    void Awake()
    {
        gold = PlayerPrefs.GetFloat("Gold");
        
        //if (PlayerPrefs.GetInt("Level_Game") == 0)
        //{
        //    level = 0;
        //    PlayerPrefs.Save();
        //    PlayerPrefs.SetInt("Level_Game", level);
        //}
        //else
        //{
        //    level = PlayerPrefs.GetInt("Level_Game");
        //}
    }
    [ContextMenu("Reset Gold")]
    void ResetGold()
    {
        gold = 0;
        SaveGold();
    }
	void Start () {
        level = 0;
        AudioController.Instance.PlaySoundRepeat(AudioType.SOUND_BG_INGAME);
        
	}
	
	// Update is called once per frame
	void Update () {
	}
    void StopSpawnEnemy()
    {
        isStopSpawnEnemy = true;
    }
    public void GamePlay()
    {
        //load du lieu
        //load du lieu tu Resources:Player, Gun , Enemy;
        //LoadLevel();
        
        //load player
        LoadPlayer();

        //load thong tin Gun
        
        for (int i = 0; i < gunController.listGunConfig.Count; i++)
        {
            if (gunController.listGunConfig[i] != null)
            {               
                LoadGun(gunController.listGunConfig[i].gunObject);
            }
        }

        Level.Instance.InitLevel();
    }
    public void GameWin()
    {
        ResetTest();

        Invoke("DelayGameWin", 7.0f);
    }
    public void GameReplay()
    {
        Level.Instance.LevelUp(level);
        GamePlay();
        Level.Instance.InitLevel();
    }
    void DelayGameWin()
    {       
        StopSpawnEnemy();
        uiController.GameOver();
        upgradePlayer.Init();
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
    #region GOLD
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
    #endregion
    public void LevelUp()
    {
        level += 1;
        PlayerPrefs.SetInt("Level_Game", level);
        PlayerPrefs.Save();
    }

    [ContextMenu("Load Info")]
    #region LEVEL_INDEX
    public void LoadLevel()
    {
        //load thong tin player
        levelInfo.LoadLevelFromFile("Player/Player", LevelType.PLAYER);        

        //load thong tin Enemy
        levelInfo.LoadLevelFromFile("Enemy/Enemy", LevelType.ENEMY);

        //load thong tin Gun
        levelInfo.LoadLevelFromFile("Gun/Gun", LevelType.GUN);
    }
    [ContextMenu("Player Index")]
    public void LoadPlayer()
    {
        //PlayerIndex playerIndex = levelInfo.listPlayer[0].playerIndex;
        
        //float hp = playerIndex.hp;
        //int l = playerIndex.level;

        //heroCowboy.Init(hp, l);

        HeroInfo heroInfo = GameData.Instance.GetHeroInfoByLevel(heroCowboy.level);
        heroCowboy.Init(heroInfo.HP, heroInfo.Level);
    }
    public void LoadTower()
    {
        PlayerIndex playerIndex = levelInfo.listPlayer[1].playerIndex;

        int level = playerIndex.level;
        float hp = playerIndex.hp;
        float damge = playerIndex.damge;
        heroCowboy.Init(hp, 1);

    }
    public void LoadSupporter()
    { }
    public void LoadEnemy(Enemy enemy)
    {
        //EnemyIndex enemyIndex = new EnemyIndex();
        //Type type = enemy.typeEnemy;
        EnemyTypeConfig typeConfig = enemy.typeEnemyConfig;
        EnemyConfig enemyInfo = GameData.Instance.GetEnemyConfig(typeConfig);
        Debug.Log("Hp = " + enemyInfo.HP);
        //switch(type)
        //{
                
        //    case Type.ENEMY_RUN:
        //        enemyIndex = levelInfo.listEnemy[0].enemyIndex;
        //        break;
        //    case Type.ENEMY_TANK:
        //        enemyIndex = levelInfo.listEnemy[1].enemyIndex;
        //        break;
        //    case Type.ENEMY_FLY:
        //        enemyIndex = levelInfo.listEnemy[2].enemyIndex;
        //        break;
        //    case Type.ENEMY_TELE:
        //        enemyIndex = levelInfo.listEnemy[3].enemyIndex;
        //        break;
        //}
        //enemy.Init(enemyIndex.level, enemyIndex.speed, enemyIndex.hp, enemyIndex.damge);
        enemy.Init(1, enemyInfo.Vellocity, enemyInfo.HP, enemyInfo.Damage);
    }
    public void LoadGun(Gun gun)
    {
        //GunIndex gunIndex = new GunIndex();
        GunType type = gun.gunType;
        GunInfo gunInfo = GameData.Instance.GetGunInfoByLevel(type, gun.level);
        //switch(type)
        //{
        //    case GunType.SHOOT_GUN:
        //        gunIndex = levelInfo.listGun[0].gunIndex;
        //        break;
        //    case GunType.MACHINE_GUN:
        //        gunIndex = levelInfo.listGun[1].gunIndex;
        //        break;
        //}

        //gun.InitGun(gunIndex.level, gunIndex.numberBulletMax, gunIndex.numberBulletsOfCartridge, gunIndex.damge, gunIndex.ratioCrit, gunIndex.valueCrit);
        gun.InitGun(gunInfo.Level, gunInfo.MaxBullet, gunInfo.CountBullet, gunInfo.Damage, gunInfo.Ratico, gunInfo.Crit, gunInfo.CountDown, gunInfo.FireRate);
    }
    #endregion

    //load tat ca cac thong so cua 1 man choi
    //thong tin player
    //thong tin Sung
    //Enemy
    //Boss

}
