using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeBullet : MonoBehaviour {

    public BoxCollider2D boxCollider;
    public List<Enemy> enemyInBoxs;

    void Start()
    {
        enemyInBoxs = new List<Enemy>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            enemyInBoxs.Add(col.gameObject.GetComponent<Enemy>());
        }
    }
}
