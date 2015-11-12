using UnityEngine;
using System.Collections;

public enum Direction
{
    NONE = 0,
    LEFT = 1,
    RIGHT = 2,
    MOVE = 3
}
public class EnemyFly : Enemy {

    public float speedX;
    public float speedY;
    public float biendo = 0.4f;
    private float x = 0;
    private float y = 0;
    private float posXPlayer = 0;
    private float posStart;
    public Direction dir;

    private Vector3 posLeft;
    private Vector3 posRight;
    public float dis = 2.15f;
    private bool isTop = false;
    private float yy = -5.0f;
    public override void Init(int _level, float _speed, float _hp, float _damge)
    {
        base.Init(_level, _speed, _hp, _damge);
    }
	// Use this for initialization
	void Start () {
        posStart = transform.position.x;

        posLeft = new Vector3(-dis, transform.position.y, 0);
        posRight = new Vector3(dis, transform.position.y, 0);
    }
	
	// Update is called once per frame
    void Update()
    {
        if (!pause && status != 1)
        {
            Move();
        }
    }
    public override void Attack()
    {
        base.Attack();
        Damge();
    }
    public override void Die()
    {
        base.Die();
    }
    public override void Hit(float _damge, bool isCrit)
    {
        base.Hit(_damge,isCrit);
    }
    public override void Move()
    {
        base.Move();
        if(dir == Direction.MOVE)
        {

            if (transform.position.x < posLeft.x || transform.position.x > posRight.x)
            {
                transform.position += new Vector3(speed, 0) * Time.deltaTime;
            }
            else
            {
                Invoke("isAttack", 1);
            }

        }
        else
        {
            if (isTop)
            {
                if (transform.position.x >= posRight.x)
                {
                    dir = Direction.RIGHT;
                    isTop = false;
                    speedX = -Mathf.Abs(speedX);
                    yy = -Mathf.Abs(yy);
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    Invoke("isAttack", 2);
                }
                if (transform.position.x <= posLeft.x)
                {
                    dir = Direction.LEFT;
                    isTop = false;
                    speedX = Mathf.Abs(speedX);
                    yy = Mathf.Abs(yy);
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    Invoke("isAttack", 2);
                }

            }
            PhoenixAttack();
            if (speedY >= 0 && dir == Direction.NONE)
            {
                isTop = true;
            }
            
            
        }
        
    }
    void isAttack()
    {
        dir = Direction.NONE;
    }
    void PhoenixAttack()
    {        
        speedY = Mathf.Sin(transform.position.x);
        if (dir == Direction.NONE)
        {
            transform.position += new Vector3(speedX, speedY * yy) * Time.deltaTime;
        }
    }   
    public override void SetSpeed(int isRight)
    {
        base.SetSpeed(isRight);
        if(isRight == 1)
        {
            yy = -Mathf.Abs(yy);
        }
        else
        {
            yy = Mathf.Abs(yy);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Attack();
            Damge();
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
