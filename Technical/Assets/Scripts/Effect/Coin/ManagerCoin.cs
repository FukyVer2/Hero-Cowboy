using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ManagerCoin : MonoBehaviour {
    
    public Text txtCoin;
    public float coin;
    public float timeUp = 0.5f;
    private float t = 0;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (t <= coin)
        {
            t += timeUp * Time.deltaTime;
            txtCoin.text = Round(t, 2).ToString();
        }
    }
    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
}
