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
    public void DespawnObject(Transform transf, string nameSpawnPool)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        objectPool.transform.localPosition = Vector3.zero;
        objectPool.Despawn(transf);
    }
    public void DespawnObjectTime(Transform transf, string nameSpawnPool, float time)
    {
        SpawnPool objectPool = PoolManager.Pools[nameSpawnPool];
        objectPool.transform.localPosition = Vector3.zero;
        objectPool.Despawn(transf, time);
    }
}
