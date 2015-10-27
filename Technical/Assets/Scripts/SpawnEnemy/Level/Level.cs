using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum StageSpawn
{
    NONE = 0,
    ENEMY = 1,
    BOSS = 2,
    WIN = 3
}
[System.Serializable]
public class Luot
{
    public Alternate[] luot = new Alternate[10];
    public GameObject boss;
}
public class Level : MonoSingleton<Level> {

    public List<Luot> listLevel;
    public List<Enemy> listEnemy;
    public int soluot = 0;
    public List<SpawnEnemy> listSpawn;
    public StageSpawn stage = StageSpawn.NONE;
    public int level;
	// Use this for initialization
	void Start () {
        stage = StageSpawn.ENEMY;
        UIGamePlay.Instance.SetLuot(soluot.ToString() + "/10");
        level = GameController.Instance.level;
	}

    public void RemoveListEnemy(Enemy enemy)
    {
        if(listEnemy.Contains(enemy))
        {
            listEnemy.Remove(enemy);

            if (listEnemy.Count <= 0  )
            {
                if (soluot < listLevel[level].luot.Length - 1)
                {
                    soluot++;
                    UIGamePlay.Instance.SetLuot(soluot.ToString() + "/10");
                    UpdateSpawn();
                }
                else
                {
                    stage = StageSpawn.BOSS;
                    UIGamePlay.Instance.SetLuot("BOSS");
                    Invoke("Boss", 2.0f);
                }
            }          
        }        
    }
    void UpdateSpawn()
    {
        for (int i = 0; i < listSpawn.Count; i++)
        {
            listSpawn[i].Reset();
        }
    }
    void Boss()
    {
        Instantiate(listLevel[level].boss, new Vector3(-3.5f, 0.5f, 0), Quaternion.identity);
    }
    
    public void SetStage()
    {
        stage = StageSpawn.WIN;
        Win();
        //Invoke("Win", 7.0f);
    }
    void Win()
    {
        GameController.Instance.GameWin();
        if (level < listLevel.Count - 1)
            GameController.Instance.LevelUp();
    }
    public void LevelUp()
    {
        level = GameController.Instance.level; 
        stage = StageSpawn.NONE;
        soluot = 0;
        UpdateSpawn();
        for (int i = 0; i < listSpawn.Count; i++)
        {
            listSpawn[i].SetLevel(level);
        }
        listEnemy.Clear();
        UIGamePlay.Instance.SetLuot(soluot.ToString() + "/10");
    }
}
