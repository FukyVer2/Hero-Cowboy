using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameOver : MonoSingleton<UIGameOver> {

    public Text txtGold;
    public Text txtDiamond;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("Gold")]
    public void SetTextGold()
    {
        float gold = PlayerPrefs.GetFloat("Gold") / 100.0f;
        string str = Gold.Round(gold, 2).ToString() + "K";
        txtGold.text = str;
    }
}
