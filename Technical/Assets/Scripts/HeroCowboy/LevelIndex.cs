using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelIndex
{
    public float hpPlayer;
    public int levelPlayer;

    public int levelTower;
    public int levelSuporter;

    public float hpBoss;
    public float damgeBoss;

    public int numberBulletMaxShotGun;
    public int numberBulletsOfCartridgeShotGun;

    public int numberBulletMaxMachineGun;
    public int numberBulletsOfCartridgeMachineGun;


    public void SetLevelIndex()
    {

        //set Hp player
        hpPlayer = UpGradePlayer.Instance.GetHpPlayer();
        GameController.Instance.heroCowboy.Init(hpPlayer);

        //
    }

}
