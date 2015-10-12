using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeBoom : MonoBehaviour {

    public List<BaseGameObject> listTaget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Attack(float damge)
    {
        for(int i = 0; i < listTaget.Count; i++)
        {
            listTaget[i].Hit(damge);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        BaseGameObject target = col.GetComponent<BaseGameObject>();
        if(target != null)
        {
            if (!listTaget.Contains(target))
                listTaget.Add(target);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        BaseGameObject target = col.GetComponent<BaseGameObject>();
        if (target != null)
        {
            if (listTaget.Contains(target))
                listTaget.Remove(target);
        }
    }
}
