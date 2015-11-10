using UnityEngine;
using System.Collections;

public class UITab : MonoBehaviour {

    public GameObject tabPlayer;
    public GameObject tabGun;
    public GameObject tabSkill;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void btTabPlayer()
    {
        tabPlayer.SetActive(true);
        tabGun.SetActive(false);
        tabSkill.SetActive(false);
    }
    public void btTabGun()
    {       
        tabGun.SetActive(true);
        tabPlayer.SetActive(false);
        tabSkill.SetActive(false);
    }
    public void btTabSkill()
    {
        tabSkill.SetActive(true);
        tabPlayer.SetActive(false);
        tabGun.SetActive(false);        
    }
}
