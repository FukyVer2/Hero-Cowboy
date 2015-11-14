using UnityEngine;
using System.Collections;
public enum Type
{
    NONE = 0,
    ENEMY_RUN = 1,
    ENEMY_TANK = 2,
    ENEMY_FLY = 3,
    ENEMY_TELE = 4,
    BOSS_LV1 = 5
}

public enum EnemyTypeConfig
{
    NONE = 0,
    ENEMY_RUN_1 = 11,
    ENEMY_RUN_2 = 12,
    ENEMY_RUN_3 = 13,
    ENEMY_TANK_1 = 21,
    ENEMY_TANK_2 = 22,
    ENEMY_TANK_3 = 23,
    ENEMY_TELE_1 = 31,
    ENEMY_TELE_2 = 32,
    ENEMY_TELE_3 = 33,
    ENEMY_FLY_1 = 41,
    ENEMY_FLY_2 = 42,
    ENEMY_FLY_3 = 43
}

public class Enemy : BaseGameObject
{
    //di chuyen
    public float speed;
    public float timeDelayAttack;
    public Type typeEnemy = Type.NONE;
    public EnemyTypeConfig typeEnemyConfig = EnemyTypeConfig.NONE;
    public int level;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void Init(int _level, float _speed, float _hp, float _damge)
    {
        this.level = _level;
        this.speed = _speed;
        this.hp = _hp;
        this.damge = _damge;

        animator = GetComponent<Animator>();
        health.Reset();
        health.SetHpDefault(hp);
    }
    public virtual void Hit(float _damge, bool isCrit)
    {
        hp -= _damge;
        //TestPlayer.Instance.RenderNumber(_damge);
        if (!isCrit)
        {
            ManagerObject.Instance.RenderNumber(ObjectType.NUMBER, posNumberHit.position, _damge);
        }
        if (isCrit)
        {
            ManagerObject.Instance.RenderNumber(ObjectType.NUMBER_CRIT, posNumberHit.position, _damge);
        }
        Delay();
        health.HP(hp);
        if (hp <= 0)
        {
            Die();
        }
    }
    private Color c = Color.red;
    private float timeDelayStun = 0.2f;
    void Delay()
    {
        if (status != 1)
        {
            int rand = Random.Range(0, 100);
            if (rand > 10 && rand < 30)
            {
                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                sprite.color = c;
                pause = true;
                animator.speed = 0;
                Invoke("AllowDelay", timeDelayStun);
            }
        }
    }
    void AllowDelay()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
        pause = false;
        animator.speed = 1;
    }
    public virtual void SetSpeed(int isRight)
    {
        speed = Mathf.Abs(speed);
        if (isRight == 1)
        {
            speed *= -1;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    public virtual void Move()
    {
        status = 0;
    }
    //chuyen sang trang thai danh
    public virtual void Attack()
    {
        speed = 0;
        status = 1;
    }
    public void Damge()
    {
        //player Mat mau o day
        //TestPlayer.Instance.Hit(damge);
        //TestPlayer.Instance.RenderNumber(damge);
        GameController.Instance.heroCowboy.Hit(damge);

    }
    public virtual void Die()
    {
        Particle.Instance.EnemyDie(transform.position);
        //render ra Coin
        ManagerObject.Instance.RenderCoin(ObjectType.COIN, transform.position, 4, false);
        //kiem tra xe co Respawn ENmey lan tiep theo k     

        //remove Enemy ra khoi List Spawn
        Enemy e = gameObject.GetComponent<Enemy>();
        Level.Instance.RemoveListEnemy(e);

        PoolObject.Instance.DespawnObject(transform, "Enemy");


        //PoolObject.Instance.DespawnEnemy(transform, "Enemy", ref SpawnEnemy.Instance.listEnemy);
    }
    //xet va cham voi Enemy
    //khi toi gan Player no se dung lai
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Attack();
        }
        if (col.tag == "Bullet")
        {

            Bullet bullet = col.GetComponentInChildren<Bullet>();
            if (bullet != null)
            {
                if (bullet.bulletOfObject == BulletOfObjectType.PLAYER)
                {
                    bullet.KillEnemies();
                    //Hit(bullet.damge);                    
                }
            }
        }
    }

}
