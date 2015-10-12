using UnityEngine;
using System.Collections;

public class EnemyBoom : Enemy {

    public RangeBoom range;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        health.SetHpDefault(hp);
	}
	
	// Update is called once per frame
	void Update () {
	    if(!pause)
        {
            Move();
        }
	}
    public override void Init()
    {
        base.Init();
    }
    public override void Attack()
    {
        base.Attack();
        speed = 0;
        animator.SetBool("isAttack", true);   
    }
    public override void Hit(float _damge)
    {
        base.Hit(_damge);
    }
    public override void Die()
    {
        range.Attack(damge);
        base.Die();
        
    }
    public override void Move()
    {
        base.Move();
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
    }
    public void FinisAnimation()
    {
        Destroy(gameObject);
        //PoolObject.Instance.DespawnObject(transform, "Enemy");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            range.Attack(damge);
        }
    }
}
