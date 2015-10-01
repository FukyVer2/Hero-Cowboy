using UnityEngine;
using System.Collections;

public class EnemyBoom : Enemy {

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
    public override void Attack()
    {
        base.Attack();
        speed = 0;
        animator.SetBool("isAttack", true);   
    }
    public override void Die()
    {       
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
}
