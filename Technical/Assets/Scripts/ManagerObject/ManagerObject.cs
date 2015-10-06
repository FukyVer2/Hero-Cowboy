using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ObjectType
{
    PLAYER = 0,    
    NUMBER = 1,
    BULLET_PLAYER_1 = 2,
    BULLET_ENEMY_1 = 3,
    ENEMY_DIE = 4,
    ENEMY_HIT = 5
}
public enum EnemyType
{
    ENEMY_RUN = 0,
    ENEMY_TANK = 1,
}

public class ManagerObject : MonoSingleton<ManagerObject> {

    public List<GameObject> listPrefabs;
    public List<GameObject> listEnemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //render number hit
    public void RenderNumber(ObjectType objectType,Vector3 pos, float damge)
    {
        GameObject numberObj = PoolObject.Instance.SpawnObjectPos(listPrefabs[(int)objectType], "Number",pos);
        //numberObj.transform.position = pos;
        Number number = numberObj.GetComponent<Number>();
        number.Init();
        number.Calculogic(damge);
    }
    //render Particle
    public void RenderParticalEnemy(ObjectType objectType, Vector3 pos)
    {
        GameObject p = PoolObject.Instance.SpawnObjectPos(listPrefabs[(int)objectType], "Particle", pos);
        //Particle particle = p.GetComponent<Particle>();
        //particle.Init();
    }
    Vector3 RandomPosition(Vector3 pos, float x)
    {
        Vector3 p = new Vector3(Random.Range(pos.x - x, pos.x + x), pos.y, pos.z);
        return p;
    }
    //render Enemy
    public void RenderEnemy(EnemyType objectType, Vector3 pos, string strPrefabs, int isRight, ref List<Enemy> l)
    {
        Vector3 p = RandomPosition(pos, 0.5f);
        GameObject enemyObj = PoolObject.Instance.SpawnObjectPos(listEnemy[(int)objectType], "Enemy", p);
        //enemyObj.transform.position = RandomPosition(pos, 0.5f);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.SetSpeed(isRight);
        if (!l.Contains(enemy))
            l.Add(enemy);
    }    
}
