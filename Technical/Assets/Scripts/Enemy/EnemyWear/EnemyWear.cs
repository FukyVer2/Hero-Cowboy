using UnityEngine;
using System.Collections;

public class EnemyWear : Enemy {

	// Use this for initialization
	void Start () {
	
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
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        base.Move();
    }
    public override void Attack()
    {
        base.Attack();
    }
    public override void Die()
    {
        base.Die();
    }
}
