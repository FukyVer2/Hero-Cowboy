using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int numberBulletMax; //số lượng đạn lớn nhất trong một màn chơi
    public int numberBulletsOfCartridge; //số lượng đạn trong băng đạn
    public float timeRespawnShoot; //thời gian bắn ra một viên đạn
    public float damge; //độ sát thương của súng
    public float bulletCountOfShoot; //số lượng viên đạn trong một lần bắn
    public float timeInsteadOfBullets; //thời gian thay đạn
    public GunType gunType; //loại súng - tương ứng sẽ bắn ra loại đạn nào
    public GunOfObjectType gunOfObjectType; //súng của đối tượng nào
    //public List<GunConfig> listBulletResources; // đạn load từ ngoài vào
    //private Dictionary<GunType, GameObject> dicBulletResources; // loại đạn theo súng
    //
    private float timeRespawnShootCurrent;
    private float timeInsteadOfBulletsCurrent;
    private int numberBulletCurrent;
    public GameObject bulletPrefab;
    public bool isShoot = true;
    public bool isInsteadOfBullet = false;
    public bool enableGun;

    public Text txtCountBullet;
    public Text txtCountCartridge;
    public float critDamge = 230.0f;//phan tram crit damge
    public float ratioCrit = 0;
    public int level = 0;
    void Start()
    {
        //dicBulletResources = new Dictionary<GunType, GameObject>();
        InitGun();
    }
    public virtual void InitGun(int _level, int _numberBulletMax, int _numberBulletsOfCartridge, float _damge, float _ratioCrit, float _critDamge, float _timeInsteadOfBullets, float _timeRespawnShoot)
    {
        this.level = _level;
        this.numberBulletMax = _numberBulletMax;
        this.numberBulletsOfCartridge = _numberBulletsOfCartridge;
        this.damge = _damge;
        this.ratioCrit = _ratioCrit;
        this.critDamge = _critDamge;
        this.timeInsteadOfBullets = _timeInsteadOfBullets;
        this.timeRespawnShoot = 1.0f / _timeRespawnShoot;
        numberBulletCurrent = numberBulletsOfCartridge;
        numberBulletMax -= numberBulletCurrent;

    }

    public virtual void InitGun()
    {
        numberBulletCurrent = numberBulletsOfCartridge;
        numberBulletMax -= numberBulletCurrent;
        enableGun = true;
        //foreach (GunConfig item in listBulletResources)
        //{
        //    dicBulletResources.Add(item.gunType, item.bulletPrefab);
        //}
        //bulletPrefab = GetBulletOfGunType(gunType);
    }

    /*
    private GameObject GetBulletOfGunType(GunType _gunType)
    {
        if (dicBulletResources.ContainsKey(_gunType))
            return dicBulletResources[_gunType];
#if UNITY_EDITOR
        Debug.Log("Chưa có viên đạn loại này");
#endif 
        return null;
    }
     */

    void Update()
    {
        /*if (numberBulletMax <= 0)
        {
            Debug.Log("Vao 1");
            //Dung ban, da het dan
            //Doi sang sung khac
        }
        else */
        SetTextCountBullet();

        if (!enableGun) //Het dan roi, thay dan di
            return;
        if (numberBulletCurrent <= 0 && !this.isInsteadOfBullet && this.numberBulletMax > 0)
        {
            GameController.Instance.heroCowboy.ChangeState(CowboyState.IDLE_STATE);
            GameController.Instance.InsteadBullet(true);

            this.isInsteadOfBullet = true;
            Invoke("InsteadOfBullets", timeInsteadOfBullets);
        }
        else if (numberBulletCurrent <= 0 && numberBulletMax <= 0)
        {
            GameController.Instance.heroCowboy.GunChange(GunType.SHOOT_GUN);
            enableGun = false;
        }
       
    }
    float RandomCritDamge(Bullet bullet)
    {
        float _damge = damge;
        int rand = Random.Range(0, 100);
        if (rand < 17)
        {            
            _damge = damge * critDamge / 100.0f;
            bullet.isCritDamge = true;
        }
        return _damge;
    }
    public virtual void CreateBullet(Vector3 _positionStart, BulletDirection _direction)
    {
        //Kiem tra sung con dan khong
        //Neu sung het dan tihi khoa lai va goi ham thay dan
        /*if (numberBulletMax <= 0)
        {
            Debug.Log("Vao 1");
            return 0;
            //Dung ban, da het dan
            //Doi sang sung khac
        }/*
        else if (numberBulletCurrent <= 0 && !this.isInsteadOfBullet )
        {
            this.isInsteadOfBullet = true;
            Debug.Log("Vao 2");
            Invoke("InsteadOfBullets", timeInsteadOfBullets);
            return 1;
        }
        else */
        if(this.isShoot && this.enableGun)
        {
            GameObject bulletObject = PoolObject.Instance.SpawnObject(bulletPrefab, "Bullet");
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            bullet.InitBullet(_positionStart, _direction);
            bullet.ResetProperties();
            //bullet.SetDamge(this.damge);
            float _damge = RandomCritDamge(bullet);
            bullet.SetDamge(_damge);
            
            switch (gunOfObjectType)
            {
                case GunOfObjectType.PLAYER:
                    bullet.SetBulletOfObjectType(BulletOfObjectType.PLAYER);
                    break;
                case GunOfObjectType.ENEMIES:
                    bullet.SetBulletOfObjectType(BulletOfObjectType.ENEMIES);
                    break;
                case GunOfObjectType.TOWER:
                    bullet.SetBulletOfObjectType(BulletOfObjectType.TOWER);
                    break;
                case GunOfObjectType.BOSS:
                    break;
                case GunOfObjectType.OTHER:
                    break;
                default:
                    break;
            }

            this.isShoot = false;
            this.numberBulletCurrent -= 1;
            Invoke("AllowShoot", timeRespawnShoot);
        }
    }

    public virtual void InsteadOfBullets()
    {
		numberBulletCurrent = numberBulletsOfCartridge;
//        if (numberBulletMax > numberBulletsOfCartridge)
//        {
//            numberBulletCurrent = numberBulletsOfCartridge;
//            
//        }
//        else
//        {
//            numberBulletCurrent = numberBulletMax;
//        }
        numberBulletMax -= numberBulletCurrent;
        this.isInsteadOfBullet = false;
        GameController.Instance.InsteadBullet(false);
    }

    public virtual void AllowShoot()
    {
        this.isShoot = true;
    }

    public virtual void Die()
    {
        
    }

    public virtual void GunUpdate()
    {
        //Update bullet tại đây
    }
    void SetTextCountBullet()
    {
        txtCountBullet.text = numberBulletCurrent.ToString();
        txtCountCartridge.text = (numberBulletMax / numberBulletsOfCartridge).ToString();
    }
    float addCountGun = 0;
    void UpdateCountGun()
    {
        if(addCountGun > 0.5)
        {
            numberBulletMax += 1;
            addCountGun = 0;
        }
        addCountGun += Time.deltaTime;
    }
}



public enum GunOfObjectType
{
    PLAYER = 0,
    TOWER = 1,
    ENEMIES = 2,
    BOSS = 3,
    OTHER = 4
}

public enum GunType
{
    SHOOT_GUN = 0, //Súng ngắn
    AK47 = 1, // Súng phóng lựu
    GRENADE = 2, // Súng phóng lưu
    MACHINE_GUN = 3// Súng bắn liên thanh
} 
