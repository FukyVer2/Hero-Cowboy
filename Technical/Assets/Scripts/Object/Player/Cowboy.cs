using UnityEngine;
using System.Collections;

public class Cowboy : MonoBehaviour{

    public int id;
    public CowboyState stateCurrent = CowboyState.IDLE_STATE;
    public float hp = 300;
    public float damge = 0;
    public float level = 0;

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

    public GunType gunType;
    public Health health;
    // Use this for initialization

    void Start()
    {

        MakeState();
        Rotation(true);
        //gunType = GunType.SHOOT_GUN;
        GunController.Instance.SetGun(gunType);
        //hp = HeroCowboyConfigs.HP_PLAYER;
        health.Reset();
        health.SetHpDefault(hp);

    }
    public void Init(float _hp, int _level)
    {
        this.hp = _hp;
        this.level = _level;
        health.Reset();
        health.SetHpDefault(hp);
    }

    [ContextMenu("GunShoot")]
    public void GunShoot()
    {
        ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT, shootPosition.position);
        //GunController.Instance.SetGun(gunType);
        GunController.Instance.ShootSpawn(shootPosition.position,
            (isLeftDirection) ? BulletDirection.LEFT : BulletDirection.RIGHT);
        isShoot = false;
        //if (gunType != GunType.MACHINE_GUN)
        //    ChangeState(CowboyState.IDLE_STATE);
        AudioController.Instance.PlaySound(AudioType.SHOT);
    }

    void Update()
    {
        if (!GunController.Instance.CheckGun())
        {
            //Sung da het dan, hoac khong co cay sung nay
            gunType = GunType.SHOOT_GUN;
            GunController.Instance.SetGun(gunType);
        }
        /*
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
         * */
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
        //Destroy(gameObject);
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
        ManagerObject.Instance.RenderNumber(ObjectType.NUMBER, posNumberHit.position, damge);
        if(hp <= 0 )
        {
            GameController.Instance.GameWin();
        }
        health.HP(hp);        
    }


    public void ShootSpawn()
    {
        if (gunType != GunType.MACHINE_GUN)
            ChangeState(CowboyState.IDLE_STATE);
        if (isShoot)
        {
            /*
            GameObject fireBallBullet = PoolObject.Instance.SpawnObject(fireBallBulletPrefabs, "Bullet");
            Bullet bulletConfig =  fireBallBullet.GetComponent<Bullet>();
            //fireBallBullet.transform.localPosition = shootPosition.position;
            if (isLeftDirection)
            {
                bulletConfig.InitBullet(shootPosition.position, BulletDirection.LEFT);
                bulletConfig.ResetProperties();
            }
            else
            {
                bulletConfig.InitBullet(shootPosition.position, BulletDirection.RIGHT);
                bulletConfig.ResetProperties();
            }
            
            //fireBallBullet.GetComponent<FireBallBullet>().ChangeDirection(isLeftDirection);
            AudioController.Instance.PlaySound(AudioType.SHOT);
            //fireBallBullet.SetActive(true);
            //Tao ra mot vien dan
            //isShoot = false;
             * */
            //GunShoot();
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

    public void AllowCowboyShoot()
    {
        if(GunController.Instance.AllowShoot())
        {
            isShoot = true;           
            ChangeState(CowboyState.ATTACK_STATE);
            GunShoot();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bullet")
        {
            Bullet bullet = col.gameObject.GetComponent<Bullet>();
            if(bullet != null)
            {
                if(bullet.bulletOfObject == BulletOfObjectType.ENEMIES)
                {
                    Hit(bullet.damge);
                }
            }
        }
    }

    public void GunChange(GunType _gunType)
    {
        gunType = _gunType;
        GunController.Instance.SetGun(gunType);
    }
    public GunType GetGuntype()
    {
        return gunType;
    }
    public void Reset(float _hp)
    {
        hp = _hp;
    }
}
