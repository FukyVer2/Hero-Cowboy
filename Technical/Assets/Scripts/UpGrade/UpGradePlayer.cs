using UnityEngine;
using System.Collections;

public class UpGradePlayer : MonoSingleton<UpGradePlayer> 
{
    private float hpPlayer = HeroCowboyConfigs.HP_PLAYER;
    private int levelPlayer = PlayerPrefs.GetInt("LevelPlayer");
    private float trongSoHp = 1;

    public void UpdateLevel()
    {
        this.levelPlayer += 1;
        SetHp();
        SaveLevel();
    }
    public int GetLevel()
    {
        int level = PlayerPrefs.GetInt("LevelPlayer");
        return level;
    }
    public float GetHpPlayer()
    {
        float hp = PlayerPrefs.GetInt("HpPlayer");
        return hp;
    }
    void SaveLevel()
    {
        PlayerPrefs.SetInt("LevelPlayer", levelPlayer);
        PlayerPrefs.Save();
        Debug.Log("hp = " + hpPlayer);
        Debug.Log("Level = " + PlayerPrefs.GetInt("LevelPlayer"));
    }
    void SetHp()
    {
        this.hpPlayer = this.hpPlayer + (this.levelPlayer * this.hpPlayer) * trongSoHp / 100.0f;
        PlayerPrefs.SetInt("HpPlayer", levelPlayer);
        PlayerPrefs.Save();
    }
}
