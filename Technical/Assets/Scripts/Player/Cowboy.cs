using UnityEngine;
using System.Collections;

public class Cowboy : MonoBehaviour{

    public int id;
    public CowboyState stateCurrent = CowboyState.IDLE_STATE;
    public float hp = 300;
    public float damge = 0;

    //di chuyen
    //public float speed;
    public float timeDelayAttack;
    public float timeAttackCurrent = 0.0f;

    public bool pause = false;

    public Animator animator;
    //public Health health;
    //public Transform posNumberHit;
    //
    public bool isLeftDirection = false; //huong di chuyen cua cowboy
    public bool isShoot = false;

    public GameObject fireBallBulletPrefabs;
    public Transform shootPosition;
    public Transform posNumberHit;
    // Use this for initialization

    void Start()
    {
        MakeState();
        Rotation(true);
    }

    void Update()
    {
        if (isShoot)
        {
            timeAttackCurrent += Time.deltaTime;
            if (timeAttackCurrent >= timeDelayAttack)
            {
                isShoot = false;
                ChangeState(CowboyState.IDLE_STATE);
                timeAttackCurrent = 0.0f;
            }
        }
    }

    public void AttackState()
    {
        animator.SetBool("isIdle", false);
        //ShootSpawn();
    }

    public void IdleState()
    {
        animator.SetBool("isIdle", true);
    }

    public void DieState()
    {
        Destroy(gameObject);
    }

    public void Rotation(bool isClickDirection)
    {
        isLeftDirection = isClickDirection;
        if (isLeftDirection)
        {
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void Hit(float damge)
    {
        hp -= damge;
    }


    public void ShootSpawn()
    {
        if (isShoot)
        {
            GameObject fireBallBullet = PoolObject.Instance.SpawnObject(fireBallBulletPrefabs, "Bullet");
            fireBallBullet.transform.localPosition = shootPosition.position;
            fireBallBullet.GetComponent<FireBallBullet>().ChangeDirection(isLeftDirection);
            //fireBallBullet.SetActive(true);
            //Tao ra mot vien dan
            //isShoot = false;
        }
    }

    public void MakeState()
    {
        switch (stateCurrent)
        {
            case CowboyState.ATTACK_STATE:
                {
                    //dothing
                    AttackState();
                    //change state
                    if (hp <= 0)
                    {
                        ChangeState(CowboyState.DIE_STATE);
                    }
                    break;
                }
            case CowboyState.DIE_STATE:
                {
                    //dothing
                    DieState();
                    //change state
                    break;
                }
            case CowboyState.IDLE_STATE:
                {

                    //dothing
                    IdleState();
                    //change state
                    if (hp <= 0)
                    {
                        ChangeState(CowboyState.DIE_STATE);
                    }
                    break;
                }
        }
    }

    public void ChangeState(CowboyState state)
    {
        this.stateCurrent = state;
        MakeState();
    }
}
