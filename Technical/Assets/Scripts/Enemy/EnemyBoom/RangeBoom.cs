using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeBoom : MonoBehaviour {

    public List<Enemy> listTaget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    [ContextMenu("Attack")]
    void Test()
    {
        Attack(100);
    }
    public void Attack(float damge)
    {
        
        //for(int i = 0; i < listTaget.Count; i++)
        //{
        //    //Destroy(listTaget[i].gameObject);
        //    listTaget[i].Hit(damge);

        //    listTaget.Remove(listTaget[i]);
        //}
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy target = col.GetComponent<Enemy>();
        if(target != null)
        {
            if (!listTaget.Contains(target))
                listTaget.Add(target);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        Enemy target = col.GetComponent<Enemy>();
        if (target != null)
        {
            if (listTaget.Contains(target))
                listTaget.Remove(target);
        }
    }
}
