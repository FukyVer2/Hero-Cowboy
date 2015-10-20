using UnityEngine;
using System.Collections;

public class HandBossLv1 : MonoBehaviour {

    
    public bool isRight;
    public float timeAttack = 3.0f;
    public float speed = 1.0f;
    private float time;
    public bool isMove = false;
    public bool isAttack = false;
    private float damge = 0;
    private Vector3 posStart;
	// Use this for initialization
	void Start () {
        posStart = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Attack();
        if (isAttack && isMove)
        {
            StandAttack();
        }
	}
    void Hit(float damge)
    {
        Delay();
        
    }
    void Delay()
    {
        int rand = Random.Range(0, 100);
        if (rand > 10 && rand < 30)
        {
            isMove = true;                
            Invoke("AllowDelay", 0.2f);
        }      
    }
    void AllowDelay()
    {
        isMove = false;
    }
    void Attack()
    {
        if (time < timeAttack)
        {
            if (!isMove)
            {
                if (isRight)
                {
                    transform.localPosition += new Vector3(-speed, 0, 0) * Time.deltaTime;
                }
                else
                {
                    transform.localPosition += new Vector3(speed, 0, 0) * Time.deltaTime;
                }
            }            
        }  
        else
        {

        }

        time += Time.deltaTime;
    }
    void StandAttack()
    {
        transform.position = Vector3.MoveTowards(transform.position, posStart, speed * 2 *Time.deltaTime);
        if(Mathf.Abs(transform.position.x - posStart.x) < 0.2f)
        {
            isAttack = false;
            isMove = false;
            Invoke("StartAttack", 1.0f);
        }
    }
    void FinisAttack()
    {
        isAttack = true;        
    }
    void StartAttack()
    {
        time = 0;
        if (isRight)
        {
            speed = Mathf.Abs(speed);
        }
        else
        {
            speed = -Mathf.Abs(speed);
        }
    }
    public void SetDamge(float _damge)
    {
        this.damge = _damge;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {            
            GameController.Instance.heroCowboy.Hit(damge);
            isMove = true;
            Invoke("FinisAttack", 2.0f);
        }
        if(col.tag == "Bullet")
        {
            Bullet bullet = col.GetComponent<Bullet>();
            if(bullet != null)
            {
                Hit(bullet.damge);
            }
        }
    }
}
