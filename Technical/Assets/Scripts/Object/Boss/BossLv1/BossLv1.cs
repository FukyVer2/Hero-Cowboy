using UnityEngine;
using System.Collections;

public class BossLv1 : Boss {

	// Use this for initialization
    public override void StartObject()
    {
        base.StartObject();
    }
	
	// Update is called once per frame
    public override void UpdateObject()
    {
        base.UpdateObject();
    }
    public override void Init()
    {
        hp = HeroCowboyConfigs.HP_BOSS_LV1;
        speed = HeroCowboyConfigs.SPEED_BOSS_LV1;
        damge = HeroCowboyConfigs.DAMGE_BOSS_LV1;
        base.Init();
    }
    public override void Attack()
    {
        base.Attack();
        animator.SetBool("isAttack", true);
    }
    void Idle()
    {
        bossStage = BossStage.IDLE;
        animator.SetBool("isAttack", false);        
    }
    void BossStart()
    {
        isPause = false;
    }
    void BossFlicker()
    {
        isPause = true;
        animator.speed = 0;
        Idle();
        Flicker f = gameObject.AddComponent<Flicker>();
        f.FlickerTo(gameObject, 1, 0.1f);
        Invoke("ChangePosition", 1.2f);
    }
    void ChangePosition()
    {
        isPause = false;
        speed = Mathf.Abs(speed);
        float scaleX = Mathf.Abs(transform.localScale.x);
        if (bossDirection == BossDirection.RIGHT)
        {
            bossDirection = BossDirection.LEFT;
            speed *= 1;
            gameObject.transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(-2.5f, transform.position.y, 0);
        }
        else
        {
            bossDirection = BossDirection.RIGHT;
            speed *= -1;
            gameObject.transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(2.5f, transform.position.y, 0);
        }

        animator.speed = 1;
        bossStage = BossStage.MOVE;
    }
    public override void Die()
    {
        base.Die();
    }
    public override void Hit(float _damge, bool isCrit)
    {
        base.Hit(_damge, isCrit);
    }
    
    public override void Move()
    {
        base.Move();
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    public override void SetSpeed(int isRight)
    {
        base.SetSpeed(isRight);
    }
    public override void SetDamge()
    {
        base.SetDamge();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="Player")
        {
            Attack();
            Invoke("BossFlicker", 3f);
        }
        if (bossStage != BossStage.DIE && bossStage != BossStage.IDLE)
        {
            if (col.tag == "Bullet")
            {
                Bullet bullet = col.GetComponent<Bullet>();
                if(bullet != null)
                {
                    Particle.Instance.EnemyHit(bullet.transform.position);
                    Hit(bullet.damge, bullet.isCritDamge);
                    bullet.Reset();
                    PoolObject.Instance.DespawnObject(bullet.transform, "Bullet");
                }               
            }
        }
    }

}
