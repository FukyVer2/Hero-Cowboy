using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isRightClick = true;
    public bool isDown = false;
    public bool isLeftClick = true;

    private GunType gunType;

    public void LeftClickEvent()
    {
        if (GameController.Instance.heroCowboy != null)
        {
            GameController.Instance.heroCowboy.Rotation(true);
            GameController.Instance.heroCowboy.AllowCowboyShoot();
        }
    }

    public void RightClickEvent()
    {
        if (GameController.Instance.heroCowboy != null)
        {
            GameController.Instance.heroCowboy.Rotation(false);
            GameController.Instance.heroCowboy.AllowCowboyShoot();
        }
    }
    GunType GetGuntype()
    {
        GunType type = GameController.Instance.heroCowboy.GetGuntype();
        return type;
    }
    void Update()
    {
        gunType = GetGuntype();
        if (gunType == GunType.MACHINE_GUN)
        {
            if (GameController.Instance.heroCowboy != null)
            {
                if (isDown)
                {
                    if (isRightClick)
                    {
                        GameController.Instance.heroCowboy.Rotation(false);
                        GameController.Instance.heroCowboy.AllowCowboyShoot();
                    }
                    else
                    {
                        GameController.Instance.heroCowboy.Rotation(true);
                        GameController.Instance.heroCowboy.AllowCowboyShoot();
                    }
                }
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (gunType == GunType.MACHINE_GUN)
        {
            isDown = true;
        }
        else
        {
            if (GameController.Instance.heroCowboy != null)
            {
                if (isRightClick)
                {
                    GameController.Instance.heroCowboy.Rotation(false);
                    GameController.Instance.heroCowboy.AllowCowboyShoot();
                }
                else
                {
                    GameController.Instance.heroCowboy.Rotation(true);
                    GameController.Instance.heroCowboy.AllowCowboyShoot();
                }
            }
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
        if (gunType == GunType.MACHINE_GUN)
            GameController.Instance.heroCowboy.ChangeState(CowboyState.IDLE_STATE);
        //throw new System.NotImplementedException();
    }
}
