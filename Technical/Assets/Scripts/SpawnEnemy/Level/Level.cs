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
    public Alternate[] luot;
    public GameObject boss;
}
public class Level : MonoSingleton<Level> {

    public Luot listLuot;
    public List<Enemy> listEnemy;
    public int soluot = 0;
    public List<SpawnEnemy> listSpawn;
    public StageSpawn stage = StageSpawn.NONE;

	// Use this for initialization
	void Start () {
        stage = StageSpawn.ENEMY;
        UIGamePlay.Instance.SetLuot(soluot.ToString() + "/10");
	}

    public void RemoveListEnemy(Enemy enemy)
    {
        if(listEnemy.Contains(enemy))
        {
            listEnemy.Remove(enemy);

            if (listEnemy.Count <= 0  )
            {
                if (soluot < listLuot.luot.Length - 1)
                {
                    soluot++;
                    UIGamePlay.Instance.SetLuot(soluot.ToString() + "/10");
                    UpdateSpawn();
                }
                else
                {
                    Debug.Log("Boss Ra nao");
                    stage = StageSpawn.BOSS;
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
        Instantiate(listLuot.boss, new Vector3(-3.5f, 0.5f, 0), Quaternion.identity);
    }
    
    public void SetStage()
    {
        stage = StageSpawn.WIN;
    }
}
