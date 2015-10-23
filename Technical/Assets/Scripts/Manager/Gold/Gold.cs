using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gold : MonoBehaviour {

    private float timeUp = 0.5f;
    private float t = 0;

	// Use this for initialization
	void Start () {
        t = GameController.Instance.Gold();
	}
	
	// Update is called once per frame
	void Update () {
        AddGold();
	}
    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
    void AddGold()
    {
        float gold = GameController.Instance.Gold();
        if(t <= gold)
        {
            t += timeUp * Time.deltaTime;
            string str = Round(t, 2).ToString() + "K";
            UIGamePlay.Instance.SetTextGold(str);
        }
    }
}
