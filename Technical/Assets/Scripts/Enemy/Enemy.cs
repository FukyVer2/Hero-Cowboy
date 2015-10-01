using UnityEngine;
using System.Collections;

public class Enemy : BaseGameObject
{

    

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
   
    public void Hit(float _damge)
    {        
        hp -= _damge;
        //TestPlayer.Instance.RenderNumber(_damge);
        ManagerObject.Instance.RenderNumber(ObjectType.NUMBER, posNumberHit.position, _damge);
        health.HP(hp);        
        if(hp <=0 )
        {
            Die();
        }
    }
    public virtual void SetSpeed(int isRight)
    {

    }
    public virtual void Move()
    {
        status = 0;
    }
    //chuyen sang trang thai danh
    public virtual void Attack()
    {
        status = 1;
    }
    public void Damge()
    {        
        //player Mat mau o day
        TestPlayer.Instance.Hit(damge);
        //TestPlayer.Instance.RenderNumber(damge);
        ManagerObject.Instance.RenderNumber(ObjectType.NUMBER, posNumberHit.position, damge);
    }
    public virtual void Die()
    {
    }
    //xet va cham voi Enemy
    //khi toi gan Player no se dung lai
    void OnTriggerEnter2D(Collider2D col)
    {       
        if(col.tag == "Player")
        {
            Attack();
        }
    }
    
}
