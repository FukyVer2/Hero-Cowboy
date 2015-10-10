using UnityEngine;
using System.Collections;

public enum TypeStage
{
    DELAY = 0,
    STUN = 1,
    SLOW = 2
}

public class StageManager : MonoBehaviour {

    public Enemy enemy;
    public float timeDelay = 0.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Stage(Enemy _enemy, TypeStage type)
    {
        switch(type)
        {
            case TypeStage.DELAY:
                //Delay();
                break;
            case TypeStage.STUN:
                //Stun();
                break;
            case TypeStage.SLOW:
                //Slow();
                break;
        }
    }
    [ContextMenu("Delay")]
    void Delay()
    {
        enemy.pause = true;
        enemy.animator.speed = 0;
        Invoke("AllowDelay", timeDelay);
    }
    void AllowDelay()
    {
        enemy.pause = false;
        enemy.animator.speed = 1;
    }
    
    public Vector2 force;
    [ContextMenu("Stun")]
    void Stun()
    {
        enemy.pause = true;
        enemy.animator.speed = 0;
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        rig.AddForce(force);
        Invoke("AllowStun", timeDelay);
    }
    void AllowStun()
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector3.zero;
        enemy.pause = false;
        enemy.animator.speed = 1;
    }
    void Slow(float phanTramTieuHao)
    {
        enemy.speed = enemy.speed * phanTramTieuHao;
    }

}
