using UnityEngine;
using System.Collections;

public enum Invisibility
{
    NONE = 0,
    MOVE = 1,
    INVI = 2,
    ATTACK = 3
}
public class EnemyInvi : Enemy {

    public SpriteRenderer spriteRender;
    public BoxCollider2D boxCollider;
    private float dis = 2.15f;
    private float disAttack = 1.0f;
    public Invisibility isInvi;
    private bool isAttack = false;
	// Use this for initialization
	void Start () {
	
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
    public override void Move()
    {
        base.Move();
        if (isInvi == Invisibility.MOVE)
        {
            if (transform.position.x <= dis && transform.position.x >= -dis)
            {
                animator.SetTrigger("isMove");
                isInvi = Invisibility.NONE;
            }
            else
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        if(isInvi == Invisibility.INVI)
        {
            if (transform.position.x <= disAttack && transform.position.x >= -disAttack)
            {
                spriteRender.enabled = true;
                animator.SetTrigger("isMove");
                isInvi = Invisibility.NONE;
                isAttack = true;
            }
            else
            {

                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        if (isInvi == Invisibility.ATTACK)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }        
    }
    public override void Hit(float _damge, bool isCrit)
    {
        base.Hit(_damge, isCrit);
    }
    public override void SetSpeed(int isRight)
    {
        base.SetSpeed(isRight);
    }
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("isAttack");
    }
    public override void Die()
    {
        base.Die();
    }
    public void Invi()
    {
        //move.Invi();

        if (isInvi == Invisibility.NONE && !isAttack)
        {
            spriteRender.enabled = false;
            isInvi = Invisibility.INVI;  
        }
        if (isInvi == Invisibility.NONE && isAttack)
        {
            isInvi = Invisibility.ATTACK;
            
            boxCollider.enabled = true;
        }
    }
}
