using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ObjectType
{  
    NUMBER = 0,
    ENEMY_DIE = 1,
    ENEMY_HIT = 2,
    ENEMY_HIT_2 = 3,
    ENEMY_HIT_3 = 4,
    ENEMY_STUN = 5
}
public enum EnemyType
{
    ENEMY_RUN = 0,
    ENEMY_TANK = 1,
    ENEMY_BOOM = 2,
    ENEMY_WEAK = 3,
    ENEMY_FLY = 4
}
[System.Serializable]
public class EnemyObject
{
    public EnemyType typeEnemy;
    public GameObject prefabs;
}
[System.Serializable]
public class Effect
{
    public ObjectType objectType;
    public GameObject prefabs;
}
public class ManagerObject : MonoSingleton<ManagerObject> {

    public List<EnemyObject> listEnemy;
    public List<Effect> listEffect;
    public InsteadBullet insteadBullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //render number hit
    public void RenderNumber(ObjectType objectType,Vector3 pos, float damge)
    {
        GameObject numberObj = PoolObject.Instance.SpawnObjectPos(listEffect[(int)objectType].prefabs, "Number", pos);
        //numberObj.transform.position = pos;
        Number number = numberObj.GetComponent<Number>();
        number.Init();
        number.Calculogic(damge);
    }
    //render Particle
    public void RenderParticalEnemy(ObjectType objectType, Vector3 pos)
    {
        GameObject p = PoolObject.Instance.SpawnObjectPos(listEffect[(int)objectType].prefabs, "Particle", pos);
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
        //GameObject enemyObj = PoolObject.Instance.SpawnObjectPos(listEnemy[(int)objectType], "Enemy", p);
        GameObject enemyObj = PoolObject.Instance.SpawnObjectPos(listEnemy[(int)objectType].prefabs, "Enemy", p);
        //enemyObj.transform.position = RandomPosition(pos, 0.5f);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.SetHP();
            enemy.SetSpeed(isRight);
            enemy.Init();
            if (!l.Contains(enemy))
                l.Add(enemy);
        }
    }    
}
