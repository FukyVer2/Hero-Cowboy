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
    ENEMY_STUN = 5,
    COIN = 6,
    NUMBER_CRIT = 7,
    LEVELUP = 8

}
public enum EnemyType
{
    ENEMY_RUN = 0,
    ENEMY_TANK = 1,
    ENEMY_BOOM = 2,
    ENEMY_WEAK = 3,
    ENEMY_FLY = 4,
    BOSS_LV1 =5,
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

    public InsteadBullet insteadBullet;//thay dan

    public List<GameObject> listBoss;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //render number hit
    public void RenderNumber(ObjectType objectType, Vector3 pos, float damge)
    {
        Vector3 p = new Vector3(Random.Range(pos.x - 0.2f, pos.x + 0.5f), pos.y, 0);
        GameObject numberObj = PoolObject.Instance.SpawnObjectPos(listEffect[(int)objectType].prefabs, "Number", p);
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
            GameController.Instance.LoadEnemy(enemy);
            enemy.SetSpeed(isRight);
            if (!l.Contains(enemy))
                l.Add(enemy);
        }
    }
    public void RenderCoin(ObjectType objectType, Vector3 pos, int countCoin, bool isDie)
    {
        for (int i = 0; i < countCoin; i++)
        {
            //GameObject coinObject = Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity) as GameObject;
            GameObject coinObject = PoolObject.Instance.SpawnObjectPos(listEffect[(int)objectType].prefabs, "Effect", pos);
            Coin coin = coinObject.GetComponent<Coin>();
            if (coin != null)
            {
                Vector2 _force = Vector2.zero;
                if (isDie)
                {
                    _force = new Vector2(Random.Range(-200, 200), Random.Range(-100, 800));
                }
                else
                {
                    _force = new Vector2(Random.Range(-50, 50), Random.Range(100, 200));
                }
                coin.AddForce(_force);
                //listCoin.Add(coin);
            }
        }
    }
    public void RenderCoinUpGrade(ObjectType objectType, Vector3 pos, int countCoin)
    {
        for (int i = 0; i < countCoin; i++)
        {
            //GameObject coinObject = Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity) as GameObject;
            GameObject coinObject = PoolObject.Instance.SpawnObjectPos(listEffect[(int)objectType].prefabs, "Effect", pos);
            Coin coin = coinObject.GetComponent<Coin>();
            if (coin != null)
            {
                Vector2 _force = Vector2.zero;

                _force = new Vector2(Random.Range(-50, 50), Random.Range(100, 200));
                
                coin.AddForceUpGrade(_force);
                //listCoin.Add(coin);
            }
        }
    }
    public void RenderLevelUp(ObjectType objectType, Vector3 pos)
    {
        GameObject levelObj = PoolObject.Instance.SpawnObjectPos(listEffect[(int)objectType].prefabs, "Effect", pos);
        //numberObj.transform.position = pos;
        LevelUp level = levelObj.GetComponent<LevelUp>();
        level.Init();        
    }
    [ContextMenu("TestCoin")]
    void TestCoin()
    {
        RenderCoin(ObjectType.COIN, Vector3.zero, 10, false);

    }
}
