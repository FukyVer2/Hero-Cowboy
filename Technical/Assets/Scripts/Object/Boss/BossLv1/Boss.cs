using UnityEngine;
using System.Collections;

public class Boss : Enemy {

    public HandBossLv1 handBossLeft;
    public HandBossLv1 handBossRight;
	// Use this for initialization
	void Start () {
        SetDamgeHand();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public override void Init()
    {
        base.Init();
    }
    public override void Attack()
    {
        base.Attack();
        
    }
    public override void Die()
    {
        ManagerObject.Instance.RenderCoin(ObjectType.COIN, transform.position, 80, true);
        Enemy e = gameObject.GetComponent<Enemy>();

        //PoolObject.Instance.DespawnObject(gameObject.transform, "Enemy");

    }
    public override void Hit(float _damge, bool isCrit)
    {
        base.Hit(_damge, isCrit);
    }
    public override void Move()
    {
        base.Move();
        
    }
    public override void SetSpeed(int isRight)
    {
        
    }
    void SetDamgeHand()
    {
        handBossLeft.SetDamge(damge);
        handBossRight.SetDamge(damge);
    }
}
