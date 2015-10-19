using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text txtGold;
    public Text txtDiamond;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("Gold")]
    public void SetText()
    {
        float gold = PlayerPrefs.GetFloat("Gold");
        txtGold.text = gold.ToString() + "K";
    }
}
