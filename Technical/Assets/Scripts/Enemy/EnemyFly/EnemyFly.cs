using UnityEngine;
using System.Collections;

public class EnemyFly : Enemy {

    public float speedX;
    public float speedY;
    public float biendo = 0.4f;
    private float x = 0;
    private float y = 0;
	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
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
        x = transform.position.x;
        y = transform.position.y;
    }
    public override void Attack()
    {
        base.Attack();
    }
    public override void Die()
    {
        base.Die();
    }
    public override void Hit(float _damge)
    {
        base.Hit(_damge);
    }
    public override void Move()
    {
        base.Move();
        MoveFly();
    }

    void MoveFly()
    {
        x += speedX * Time.deltaTime;
        y = Mathf.Cos(x) * biendo;

        transform.position = new Vector3(x, y, 0);
    }    
    
}
