using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeBullet : MonoBehaviour {

    public List<Enemy> enemyInBoxs;

    void Start()
    {
        enemyInBoxs = new List<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if (!enemyInBoxs.Contains(enemy))
            {
                enemyInBoxs.Add(enemy);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if (!enemyInBoxs.Contains(enemy))
            {
                enemyInBoxs.Add(enemy);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if (enemyInBoxs.Contains(enemy))
            {
                enemyInBoxs.Remove(enemy);
            }
        }
    }
}
