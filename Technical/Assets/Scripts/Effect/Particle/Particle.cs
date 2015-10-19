using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ParticleType
{
    NONE = 0,
    ENEMY_DIE_1 = 1,
    ENEMY_DIE_2 = 2,
    ENEMY_HIT_1 = 3,
    ENEMY_HIT_2 = 4,
    ENEMY_HIT_CRIT = 5,
    PLAYER_DIE =6,
    PLAYER_LEVELUP =7,

}
[System.Serializable]
public class ParticleObject
{
    public ParticleType type;
    public GameObject particle;
}
public class Particle : MonoSingleton<Particle>
{

    public List<ParticleObject> listParticle;
    private ParticleType type = ParticleType.NONE;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EnemyDie(Vector3 pos)
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            PoolObject.Instance.SpawnObjectPos(listParticle[(int)ParticleType.ENEMY_DIE_1].particle, "Particle", pos);
        }
        else
        {
            PoolObject.Instance.SpawnObjectPos(listParticle[(int)ParticleType.ENEMY_DIE_2].particle, "Particle", pos);
        }
    }
    public void EnemyHit(Vector3 pos)
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            PoolObject.Instance.SpawnObjectPos(listParticle[(int)ParticleType.ENEMY_HIT_1].particle, "Particle", pos);
        }
        else
        {
            PoolObject.Instance.SpawnObjectPos(listParticle[(int)ParticleType.ENEMY_HIT_2].particle, "Particle", pos);
        }
    }
    public void EnemyHitCrit(Vector3 pos)
    {
        PoolObject.Instance.SpawnObjectPos(listParticle[(int)ParticleType.ENEMY_HIT_CRIT].particle, "Particle", pos);
    }
    public void PlayerLevelUp(Vector3 pos)
    {
        PoolObject.Instance.SpawnObjectPos(listParticle[(int)ParticleType.PLAYER_LEVELUP].particle, "Particle", pos);
    }
    public void PlayerDie(Vector3 pos)
    {
        PoolObject.Instance.SpawnObjectPos(listParticle[(int)ParticleType.PLAYER_LEVELUP].particle, "Particle", pos);
    }
}
