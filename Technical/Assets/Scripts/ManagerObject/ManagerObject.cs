using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ObjectType
{
    PLAYER = 0,
    ENEMY_RUN = 1,
    ENEMY_TANK = 2,
    NUMBER = 3,
    BULLET_PLAYER_1 = 4,
    BULLET_ENEMY_1 = 5
}

public class ManagerObject : MonoSingleton<ManagerObject> {

    public List<GameObject> listPrefabs;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RenderNumber(ObjectType objectType,Vector3 pos, float damge)
    {
        GameObject numberObj = PoolObject.Instance.SpawnObject(listPrefabs[(int)objectType], "Number");
        numberObj.transform.position = pos;
        Number number = numberObj.GetComponent<Number>();
        number.Init();
        number.Calculogic(damge);
    }
    Vector3 RandomPosition(Vector3 pos, float x)
    {
        Vector3 p = new Vector3(Random.Range(pos.x - x, pos.x + x), pos.y, pos.z);

        return p;
    }
    //render Enemy
    public void RenderEnemy(ObjectType objectType, Vector3 pos, string strPrefabs, int isRight)
    {
        GameObject enemyObj = PoolObject.Instance.SpawnObject(listPrefabs[(int)objectType], "EnemyRun");
        enemyObj.transform.position = RandomPosition(pos, 0.5f);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.SetSpeed(isRight);        
    }
}
