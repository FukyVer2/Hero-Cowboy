using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    void Start()
    {
        //dicBulletResources = new Dictionary<GunType, GameObject>();
        InitGun();
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
        if (!enableGun) //Het dan roi, thay dan di
            return;
        if (numberBulletCurrent <= 0 && !this.isInsteadOfBullet && this.numberBulletMax > 0)
        {
            this.isInsteadOfBullet = true;
            Debug.Log("Vao 2");
            Invoke("InsteadOfBullets", timeInsteadOfBullets);
        }
        else if (numberBulletCurrent <= 0 && numberBulletMax <= 0)
        {
            enableGun = false;
        }
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
        if(this.isShoot)
        {
            Debug.Log("ban - ban - ban");
            GameObject bulletObject = PoolObject.Instance.SpawnObject(bulletPrefab, "Bullet");
            Bullet bullet = bulletObject.GetComponentInChildren<Bullet>();
            bullet.InitBullet(_positionStart, _direction);
            bullet.SetDamge(this.damge);
            this.isShoot = false;
            this.numberBulletCurrent -= 1;
            Invoke("AllowShoot", timeRespawnShoot);
        }
    }

    public virtual void InsteadOfBullets()
    {
        if (numberBulletMax > numberBulletsOfCartridge)
        {
            numberBulletCurrent = numberBulletsOfCartridge;
            
        }
        else
        {
            numberBulletCurrent = numberBulletMax;
        }
        numberBulletMax -= numberBulletCurrent;
        this.isInsteadOfBullet = false;
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
}



public enum GunOfObjectType
{
    PLAYER = 0,
    TOWER = 1,
    BOSS = 2,
    OTHER = 3
}

public enum GunType
{
    SHOOT_GUN = 0, //Súng ngắn
    AK47 = 1, // Súng phóng lựu
    GRENADE = 2, // Súng phóng lưu
    MACHINE_GUN = 3// Súng bắn liên thanh
} 
