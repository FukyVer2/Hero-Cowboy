using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoSingleton<GunController> {

    public List<GunConfig> listGunConfig;
    public GameObject gunCurrent;
    private Gun gun;
    private Dictionary<GunType, GameObject> dicGunResources; // loại đạn theo súng

    void Awake()
    {
        dicGunResources = new Dictionary<GunType, GameObject>();
        InitGun();
    }

    public virtual void InitGun()
    {
        foreach (GunConfig item in listGunConfig)
        {
            dicGunResources.Add(item.gunType, item.gunObject);
        }
    }

    public void SetGun(GunType _gunType)
    {
        this.gunCurrent = GetGunOfGunType(_gunType);
        if (this.gunCurrent != null)
        {
            gun = this.gunCurrent.GetComponent<Gun>();
        }
    }

    public bool AllowShoot()
    {
        if (gun != null)
        {
            return this.gun.isShoot && !this.gun.isInsteadOfBullet;
        }
        return false;
    }

    public void ShootSpawn(Vector3 _positionStart, BulletDirection _direction)
    {
        if (gun != null)
        {
            this.gun.CreateBullet(_positionStart, _direction);
        }
    }

    //Kiem tra sung con dan hay khong
    public bool CheckGun()
    {
        if (gun != null)
            return this.gun.enableGun;
        return false;
    }

    private GameObject GetGunOfGunType(GunType _gunType)
    {
        if (dicGunResources.ContainsKey(_gunType))
            return dicGunResources[_gunType];
#if UNITY_EDITOR
        Debug.Log("Chưa có viên đạn loại này");
#endif
        return null;
    }
}

[System.Serializable]
public class GunConfig
{
    public GunType gunType;
    public GameObject gunObject;
}
