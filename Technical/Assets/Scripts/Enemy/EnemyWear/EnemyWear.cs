using UnityEngine;
using System.Collections;

public class EnemyWear : Enemy {

    public bool isGiap = true;
    
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
    public override void Hit(float _damge)
    {
        //base.Hit(_damge);
        if(!isGiap)
        {
            base.Hit(_damge);
        }
    }
    public override void Die()
    {
        base.Die();
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Box" && isGiap)
        {
            animator.SetBool("isAttack", true);
            isGiap = false;
            StartCoroutine(Move2());
        }
        if (col.tag == "Player")
        {
            Attack();
        }
    }
}
