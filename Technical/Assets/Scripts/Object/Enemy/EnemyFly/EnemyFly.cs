using UnityEngine;
using System.Collections;

public enum Direction
{
    NONE = 0,
    LEFT = 1,
    RIGHT = 2
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
    public override void Init(int _level, float _speed, float _hp, float _damge)
    {
        base.Init(_level, _speed, _hp, _damge);
    }
	// Use this for initialization
	void Start () {
        posStart = transform.position.x;
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

        if(transform.position.x > posXPlayer)
        {
            dir = Direction.RIGHT;
        }
        else
        {
            dir = Direction.LEFT;
        }
        Idle();

        //if (Mathf.Abs(transform.position.x - posXPlayer) > 2)
        //{
        //    transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        //}
        //else
        //{
        //    //attack
        //    Invoke("PhoenixAttack", 2);
        //}
    }
    void PhoenixAttack()
    {
        //speedX = Mathf.Abs(speedX);
        //switch(dir)
        //{
        //    case Direction.NONE:
        //        break;
        //    case Direction.LEFT:
        //        speedX = speedX;
        //        break;
        //    case Direction.RIGHT:
        //        speedX = -speedX;
        //        break;
        //}
        if (dir != Direction.NONE)
        {
            transform.position += new Vector3(speedX, Mathf.Sin(transform.position.x) * -5) * Time.deltaTime;
        }
    }
    void Idle()
    {
        float posTarget = posStart - ((posStart - posXPlayer) * 2);
        //if(Mathf.Abs(transform.position.x - posTarget) <= 0)
        if(transform.position.x < -2.15f)
        {
            dir = Direction.NONE;
        }
        PhoenixAttack();
    }
    public override void SetSpeed(int isRight)
    {
        base.SetSpeed(isRight);
    }

}
