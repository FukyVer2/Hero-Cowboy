using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{

    public bool isLeftClick = true;

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
}
