using UnityEngine;
using System.Collections;
using PathologicalGames;
using System.Collections.Generic;

public class PoolObject : MonoSingleton<PoolObject>
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public GameObject SpawnObject(GameObject obj, string nameSpawnPool)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        //Transform gemObj = gemPool.Spawn(listGem[index]);
        Transform newObj = objectPool.Spawn(obj);
        return newObj.gameObject;
    }
    //Spawn tai vi tri pos
    public GameObject SpawnObjectPos(GameObject obj, string nameSpawnPool, Vector3 pos)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        //Transform gemObj = gemPool.Spawn(listGem[index]);
        Transform newObj = objectPool.Spawn(obj, pos, Quaternion.identity);
        return newObj.gameObject;
    }

    //Despawn Object binh thuong
    public void DespawnObject(Transform transf, string nameSpawnPool)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        objectPool.transform.localPosition = Vector3.zero;
        objectPool.Despawn(transf);
    }
    public void DespawnEnemy(Transform transf, string nameSpawnPool, ref List<Enemy> l)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        objectPool.transform.localPosition = Vector3.zero;
        Enemy enemy = objectPool.gameObject.GetComponent<Enemy>();
        if(enemy == null)
        {
            Debug.Log("khong co Enemy");
        }
        //Debug.Log("Enemy = " + enemy);
        //if(l.Contains(enemy))
        //{
        //    l.Remove(enemy);
        //}
        l.Remove(enemy);
        objectPool.Despawn(transf);
    }
    //Despawn Object sau 1 khoang thoi gian
    public void DespawnObjectTime(Transform transf, string nameSpawnPool, float time)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        objectPool.transform.localPosition = Vector3.zero;
        objectPool.Despawn(transf, time);
    }
    public void DeActivePool(string nameSpawnPool)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        objectPool.DespawnAll();
    }
}
