using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isRightClick = true;
    public bool isDown = false;
    private GunType gunType;
    private float right = 0;
    void Start()
    {
        right = Screen.width / 2.0f;
    }
    void UpdateInput()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftClickEvent();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightClickEvent();
        }
    }
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
#if UNITY_EDITOR
        UpdateInput();
#endif
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
        if (GameController.Instance.heroCowboy != null)
        {
            isDown = false;
            if (gunType == GunType.MACHINE_GUN)
            {
                isDown = true;
            }
            if (eventData.position.x > right)
            {
                isRightClick = true;
                GameController.Instance.heroCowboy.Rotation(false);
                GameController.Instance.heroCowboy.AllowCowboyShoot();
            }
            else
            {
                isRightClick = false;
                GameController.Instance.heroCowboy.Rotation(true);
                GameController.Instance.heroCowboy.AllowCowboyShoot();
            }
        }
        //if (gunType == GunType.MACHINE_GUN)
        //{
        //    isDown = true;
        //}
        //else
        //{
        //    if (GameController.Instance.heroCowboy != null)
        //    {
        //        if (isRightClick)
        //        {
        //            GameController.Instance.heroCowboy.Rotation(false);
        //            GameController.Instance.heroCowboy.AllowCowboyShoot();
        //        }
        //        else
        //        {
        //            GameController.Instance.heroCowboy.Rotation(true);
        //            GameController.Instance.heroCowboy.AllowCowboyShoot();
        //        }
        //    }
        //}
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if ((isRightClick == true && eventData.position.x > right) || (isRightClick == false && eventData.position.x < right))
            isDown = false;
        if (gunType == GunType.MACHINE_GUN)
            GameController.Instance.heroCowboy.ChangeState(CowboyState.IDLE_STATE);
        //throw new System.NotImplementedException();
    }
}
