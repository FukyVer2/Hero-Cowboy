using UnityEngine;
using System.Collections;

public class EnemyRun : Enemy {

	// Use this for initialization
	void Start () {
        //hpDefault = hp;
        //health.Reset();
        //health.SetHpDefault(hp);
        //animator = GetComponent<Animator>();  
	}
	
	// Update is called once per frame
	void Update () {
        if (!pause)
        {
            Move();
        }
	}
    public override void Init(int _level, float _speed, float _hp, float _damge)
    {
        base.Init(_level, _speed, _hp, _damge);
    }

    public override void Hit(float _damge, bool isCrit)
    {
        base.Hit(_damge, isCrit);
    }
    //set ben huong quay
    //isRight = 0 ben trai, isRight = 1 ben phai
    public override void SetSpeed(int isRight)
    {
        health.SetHpDefault(hp);
        speed = Random.Range(0.4f, 0.6f);
        base.SetSpeed(isRight);
            
    }
    //ham di chuyen cua Enemy
    public override void Move()
    {
        base.Move();
        gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    //chuyen sang trang thai danh
    public override void Attack()
    {
        base.Attack();
        animator.SetBool("isAttack", true);        
    }
    public override void Die()
    {
        base.Die();
    }
    [ContextMenu("Hit")]
    void TestHit()
    {
        Hit(50,false);
    }
}
