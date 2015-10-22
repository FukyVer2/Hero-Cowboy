using UnityEngine;
using System.Collections;

public class HandBossLv1 : Boss {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("isAttack");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {            
            GameController.Instance.heroCowboy.Hit(damge);
            Attack();
        }
        if (col.tag == "Bullet")
        {
            Bullet bullet = col.GetComponent<Bullet>();
        }
    }
}
