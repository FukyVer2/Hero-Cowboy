using UnityEngine;
using System.Collections;

public class EnemyWear : Enemy {

    public bool isGiap = true;
    public Gun gun;
    public Transform transBullet;
    public BulletDirection bulletDirection;
    
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        health.SetHpDefault(hp);
	}
	
	// Update is called once per frame
	void Update () {
        if(!pause && status != 1)
        {
            Move();
        }        
        if(status == 1)
        {
            gun.CreateBullet(transBullet.position, bulletDirection);
        }
	}
    public override void Init()
    {
        base.Init();
    }
    public override void SetSpeed(int isRight)
    {
        base.SetSpeed(isRight);
        if(isRight == 1)
        {
            bulletDirection = BulletDirection.RIGHT;
        }
        else
        {
            bulletDirection = BulletDirection.LEFT;
        }
    }
    public override void Move()
    {
        base.Move();
        if (isGiap)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }        
    }
    IEnumerator Move2()
    {
        yield return new WaitForSeconds(2.0f);
        isGiap = true;
        animator.SetBool("isAttack", false);
    }
    public override void Attack()
    {
        
        base.Attack();
        animator.SetBool("isAttack", true);
        
    }
    public override void Hit(float _damge, bool isCrit)
    {
        //base.Hit(_damge);
        if(!isGiap)
        {
            base.Hit(_damge, isCrit);
        }
    }
    public override void Die()
    {
        base.Die();
    }
    [ContextMenu("Shot")]
    IEnumerator ShotSpawn()
    {
        yield return new WaitForSeconds(1.0f);
        gun.CreateBullet(transBullet.position, bulletDirection);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Box" && isGiap)
        {
            
            animator.SetBool("isAttack", true);
            isGiap = false;            
            StartCoroutine(ShotSpawn());
            StartCoroutine(Move2());
        }
        if (col.tag == "Player")
        {
            //Destroy(gameObject);
            //Attack();
        }
        if (col.tag == "Bullet")
        {
            Bullet bullet = col.GetComponent<Bullet>();
            if (bullet != null)
            {
                if (bullet.bulletOfObject == BulletOfObjectType.PLAYER)
                {
                    bullet.KillEnemies();
                    //Hit(bullet.damge);
                    //PoolObject.Instance.DespawnObject(bullet.gameObject.transform, "Bullet");
                }
            }
        }
    }
}
