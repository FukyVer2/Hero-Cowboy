using UnityEngine;
using System.Collections;

public class EnemyRun : Enemy {

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        health.SetHpDefault(hp);
	}
	
	// Update is called once per frame
	void Update () {
        if (!pause)
        {
            Move();
        }
	}
    //set ben huong quay
    //isRight = 0 ben trai, isRight = 1 ben phai
    public override void SetSpeed(int isRight)
    {
        speed = Random.Range(0.5f, 1.0f);
        if(isRight == 1)
        {
            speed *= -1;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }else
        {
            
        }
    }
    //ham di chuyen cua Enemy
    public override void Move()
    {
        gameObject.transform.position += new Vector3(speed,0,0) * Time.deltaTime;
    }
    //chuyen sang trang thai danh
    public override void Attack()
    {
        speed = 0;
        animator.SetBool("isAttack", true);        
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
    [ContextMenu("Hit")]
    void TestHit()
    {
        Hit(50);
    }
}
