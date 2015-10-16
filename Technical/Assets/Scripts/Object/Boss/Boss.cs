using UnityEngine;
using System.Collections;

public class Boss : Enemy {

	// Use this for initialization
	void Start () {
        hpDefault = hp;
        health.Reset();
        health.SetHpDefault(hp);
        animator = GetComponent<Animator>();  
	}
	
	// Update is called once per frame
	void Update () {
        if(!pause && status != 1)
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
        //animator.SetBool("isAttack", true);
        //Invoke("Jump", 2.0f);
    }
    public override void Die()
    {
        ManagerObject.Instance.RenderCoin(ObjectType.COIN, transform.position, 80, true);
        Enemy e = gameObject.GetComponent<Enemy>();
        SpawnEnemy.Instance.RemoveListEnemy(e);
        SpawnEnemy.Instance.SpawnEnemyAlternate();
        PoolObject.Instance.DespawnObject(gameObject.transform, "Enemy");

    }
    public override void Hit(float _damge, bool isCrit)
    {
        base.Hit(_damge, isCrit);
    }
    public override void Move()
    {
        base.Move();
        MoveUpdate();
    }
    public override void SetSpeed(int isRight)
    {
        base.SetSpeed(isRight);
    }
    void MoveUpdate()
    {              
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;      
    }
    [ContextMenu("Jump")]
    void Jump()
    {
        //Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        //rigid.AddForce(new Vector3(70, 150, 0));
        //speed = -1;
        animator.SetBool("isAttack", false);

        transform.position = new Vector3(transform.position.x + 3f, transform.position.y, 0);
        speed = -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        status = 0;
    }
}
