using UnityEngine;
using System.Collections;

public class UIGunConfig : MonoBehaviour {
    
    public GunType gunType;

    public void GunChangedClickEvent()
    {
        if (GameController.Instance.heroCowboy != null)
        {
            GameController.Instance.heroCowboy.GunChange(gunType);
        }
    }
}
