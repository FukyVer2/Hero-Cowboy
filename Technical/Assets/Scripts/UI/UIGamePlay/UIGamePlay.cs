using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGamePlay : MonoSingleton<UIGamePlay> {

    public Text txtGold;
    public Text txtDiamond;
    public Text txtLuot;
    public Text txtLive;
    void Start()
    {
        SetTextGold(GameController.Instance.gold.ToString());
    }

    public void SetTextGold(string txt)
    {
        txtGold.text = txt;
    }
    public void SetTextDiamond(string txt)
    {
        txtDiamond.text = txt;
    }
    public void SetTextLive(string txt)
    {
        txtLive.text = txt;
    }
    public void SetLuot(string txt)
    {
        txtLuot.text = txt;
    }
}
