using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{

    public bool isLeftClick = true;

    public void LeftClickEvent()
    {
        GameController.Instance.heroCowboy.Rotation(true);
        GameController.Instance.heroCowboy.isShoot = true;
        GameController.Instance.heroCowboy.ChangeState(CowboyState.ATTACK_STATE);
    }

    public void RightClickEvent()
    {
        GameController.Instance.heroCowboy.Rotation(false);
        GameController.Instance.heroCowboy.isShoot = true;
        GameController.Instance.heroCowboy.ChangeState(CowboyState.ATTACK_STATE);
    }
}
