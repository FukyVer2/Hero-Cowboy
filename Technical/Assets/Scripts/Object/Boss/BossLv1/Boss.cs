using UnityEngine;
using System.Collections;
public enum BossType
{
    NONE = 0
}
public enum BossStage
{
    NONE = 0,
    IDLE = 1,
    MOVE = 2,
    JUMB = 3,
    ATTACK = 4,
    DIE = 5
}
public enum BossDirection
{
    NONE = 0,
    LEFT = 1,
    RIGHT = 2
}
public class Boss : MonoBehaviour {

    public BossType bossType = BossType.NONE;
    public BossStage bossStage = BossStage.NONE;
    public BossDirection bossDirection = BossDirection.NONE;
    public float hp;
    public float damge = 0;
    public float speed = 0;
    public Transform posNumberHit;
    public Health health;
    public Animator animator;
    public bool isPause;
    private float timeDelayStun = 0.2f;
    private Color c = Color.red; 
    
	// Use this for initialization
    void Start()
    {
        StartObject();
    }
    public virtual void StartObject()
    {
        Init();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateObject();
	}
    public virtual void UpdateObject()
    {
        if (!isPause)
        {
            Move();
        }        
    }
    public virtual void Init()
    {
        animator = gameObject.GetComponent<Animator>();
        health.Reset();
        health.SetHpDefault(hp);
    }

    public virtual void Attack()
    {
        bossStage = BossStage.ATTACK;
        isPause = true;
    }
    public virtual void Die()
    {
        
        bossStage = BossStage.DIE;
        ManagerObject.Instance.RenderCoin(ObjectType.COIN, transform.position, 80, true);
        Level.Instance.SetStage();

        //PoolObject.Instance.DespawnObject(gameObject.transform, "Enemy");
        Destroy(gameObject);
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
    void Delay()
    {
        if (bossStage != BossStage.ATTACK)
        {
            int rand = Random.Range(0, 100);
            if (rand > 10 && rand < 30)
            {
                SpriteRenderer sprite = GetComponent<SpriteRenderer>();
                sprite.color = c;
                isPause = true;
                animator.speed = 0;
                Invoke("AllowDelay", timeDelayStun);
            }
        }
    }
    void AllowDelay()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
        isPause = false;
        animator.speed = 1;
    }
    public virtual void Move()
    {
        bossStage = BossStage.MOVE;
    }
    public void Damge()
    {
        GameController.Instance.heroCowboy.Hit(damge);
    }
    public virtual void SetSpeed(int isRight)
    {
        speed = Mathf.Abs(speed);
        if (isRight == 1)
        {
            bossDirection = BossDirection.RIGHT;
            speed *= -1;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            bossDirection = BossDirection.LEFT;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public virtual void SetDamge()
    {       
    }
    public virtual void SetStage()
    {

    }
}
