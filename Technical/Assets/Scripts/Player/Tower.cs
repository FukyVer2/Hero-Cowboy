using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

    public Transform shootPosition; //Vi tri vien dan se bay ra
    private bool isShoot; //Duoc phep ban
    public float timeShootWait; //Thoi gian dan cach giua cac luot ban
    public Vector2 range; //Range cua tower
    private BoxCollider2D boxCollider2D;
    private List<GameObject> enemyInBoxs;
    public GameObject towerBulletPrefab;

    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        boxCollider2D.size = range;
        enemyInBoxs = new List<GameObject>();
        isShoot = true;
    }

    void Update()
    {
        TowerShoot();
        //enemyInBoxs.RemoveAll(enemy => enemy == null);
    }

    private void AllowShoot()
    {
        this.isShoot = true;
    }

    private void TowerShoot()
    {
        GameObject enemyObj = this.GetEnemyObjectInBoxs();
        if (enemyObj != null)
        {
            if (isShoot)
            {
                isShoot = false;
                Invoke("AllowShoot", timeShootWait);
                GameObject bulletObject = PoolObject.Instance.SpawnObject(towerBulletPrefab, "Bullet");
                TowerBullet bullet = bulletObject.GetComponent<TowerBullet>();
                bullet.InitBullet(shootPosition.position, BulletDirection.NONE);
                bullet.SetTarget(enemyObj.transform.position);
                bullet.AppearBullet();
            }
        }
    }

    public GameObject GetEnemyObjectInBoxs()
    {
        if (this.enemyInBoxs.Count > 0)
        {
            GameObject enemyObj = this.enemyInBoxs[0];
            this.enemyInBoxs.Remove(enemyObj);
            return enemyObj;
        }
        return null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy") { 
            //Enemy enemy = col.GetComponent<Enemy>();
            enemyInBoxs.Add(col.gameObject);
        }
    }
}
