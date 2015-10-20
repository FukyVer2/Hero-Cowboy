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
public class Level : MonoSingleton<Level> {

    public Alternate[] luot;
    public List<Enemy> listEnemy;
    public int soluot = 0;
    public List<SpawnEnemy> listSpawn;
    public StageSpawn stage = StageSpawn.NONE;

	// Use this for initialization
	void Start () {
        stage = StageSpawn.ENEMY;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RemoveListEnemy(Enemy enemy)
    {
        if(listEnemy.Contains(enemy))
        {
            listEnemy.Remove(enemy);

            if (listEnemy.Count <= 0  )
            {
                if (soluot < luot.Length - 1)
                {
                    soluot++;
                    UpdateSpawn();
                }
                else
                {
                    Debug.Log("Win Cmnr");
                    stage = StageSpawn.BOSS;
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

    }
}
