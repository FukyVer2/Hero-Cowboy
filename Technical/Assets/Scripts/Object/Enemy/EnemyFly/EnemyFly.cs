using UnityEngine;
using System.Collections;

public class EnemyFly : Enemy {

    public float speedX;
    public float speedY;
    public float biendo = 0.4f;
    private float x = 0;
    private float y = 0;
    private float posXPlayer = 0;
    public override void Init(int _level, float _speed, float _hp, float _damge)
    {
        base.Init(_level, _speed, _hp, _damge);
    }
	// Use this for initialization
	void Start () { 
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
        if (Mathf.Abs(transform.position.x - posXPlayer) > 2)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else
        {
            //attack
            Invoke("PhoenixAttack", 2);
        }
    }
    void PhoenixAttack()
    {
        Debug.Log("Begin Attack");

        transform.position += new Vector3(speedX, Mathf.Sin(transform.position.x) * -5) *Time.deltaTime;
    }
    public override void SetSpeed(int isRight)
    {
        base.SetSpeed(isRight);
    }

}
