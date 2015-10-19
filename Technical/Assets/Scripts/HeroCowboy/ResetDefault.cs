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
                    gun.Reset(HeroCowboyConfigs.NUMBER_BULLET_MAX_SHOTGUN, HeroCowboyConfigs.NUMBER_BULLET_OF_CARTRIDGE_SHOTGUN);
                    break;
                case GunType.MACHINE_GUN:
                    gun.Reset(HeroCowboyConfigs.NUMBER_BULLET_MAX_MACHINEGUN, HeroCowboyConfigs.NUMBER_BULLET_OF_CARTRIDGE_MACHINEGUN);
                    break;
            }
        }
    }
    public void ResetSpawnEnemy()
    {
        SpawnEnemy.Instance.Reset();
    }
    
}
