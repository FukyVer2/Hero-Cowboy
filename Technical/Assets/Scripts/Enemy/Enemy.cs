using UnityEngine;
using System.Collections;

public class Enemy : BaseGameObject
{
    //di chuyen
    public float speed;
    public float timeDelayAttack;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public virtual void Init()
    {
    }
    public virtual void Hit(float _damge)
    {        
        hp -= _damge;
        //TestPlayer.Instance.RenderNumber(_damge);
        ManagerObject.Instance.RenderNumber(ObjectType.NUMBER, posNumberHit.position, _damge);        
        health.HP(hp);        
        if(hp <=0 )
        {
            Die();
        }
    }
    public virtual void SetSpeed(int isRight)
    {
        speed = Mathf.Abs(speed);
        if (isRight == 1)
        {
            speed *= -1;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
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
        ManagerObject.Instance.RenderNumber(ObjectType.NUMBER, GameController.Instance.heroCowboy.posNumberHit.position, damge);
    }
    public virtual void Die()
    {
        
        ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_DIE, transform.position);
        //kiem tra xe co Respawn ENmey lan tiep theo k
        

        //remove Enemy ra khoi List Spawn
        Enemy e = gameObject.GetComponent<Enemy>();        
        SpawnEnemy.Instance.RemoveListEnemy(e);
        SpawnEnemy.Instance.SpawnEnemyAlternate();

        PoolObject.Instance.DespawnObject(transform, "Enemy");
        
       
        //PoolObject.Instance.DespawnEnemy(transform, "Enemy", ref SpawnEnemy.Instance.listEnemy);
    }
    //xet va cham voi Enemy
    //khi toi gan Player no se dung lai
    void OnTriggerEnter2D(Collider2D col)
    {       
        if(col.tag == "Player")
        {
            Attack();
        }
        if(col.tag == "Bullet")
        {
            Bullet bullet = col.GetComponent<Bullet>();
            if(bullet != null)
            {
                if(bullet.bulletOfObject == BulletOfObjectType.PLAYER)
                {
                    bullet.KillEnemies();                    
                    Hit(bullet.damge);
                    PoolObject.Instance.DespawnObject(bullet.gameObject.transform, "Bullet");
                }
            }
        }
    }
    
}
