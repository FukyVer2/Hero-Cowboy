using UnityEngine;
using System.Collections;

public class ResetDefault : MonoSingleton<ResetDefault> {

	public void ResetPlayer()
    {
        GameController.Instance.heroCowboy.Reset(HeroCowboyConfigs.HP_PLAYER);
    }
    public void ResetGun()
    { 
        for(int i =0; i< GunController.Instance.listGunConfig.Count;i++)
        {
            Gun gun = GunController.Instance.listGunConfig[i].gunObject;
            GunType type = GunController.Instance.listGunConfig[i].gunType;
            switch(type)
            {
                case GunType.AK47:
                    break;
                case GunType.GRENADE:
                    break;
                case GunType.SHOOT_GUN:
                    break;
                case GunType.MACHINE_GUN:
                    break;
            }
        }
    }

}
