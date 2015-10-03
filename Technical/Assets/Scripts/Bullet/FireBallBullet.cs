using UnityEngine;
using System.Collections;

public class FireBallBullet : MonoBehaviour {

    public float speed = 40;
    public bool isLeftDirection = true;
    public float damge = 100;

    public void Move()
    {
        float posX = gameObject.transform.position.x;
        posX += speed * Time.deltaTime;
        gameObject.transform.position = new Vector3(posX, 0, 0);
    }

    public void ChangeDirection(bool direction)
    {
        if (direction)
        {
            speed = (speed < 0) ? speed : -speed;
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            speed = (speed > 0) ? speed : -speed;
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    public void Destroy()
    {
        if (gameObject.transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x ||
            gameObject.transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
            PoolObject.Instance.DespawnObject(gameObject.transform, "Bullet");
    }

    public void Update()
    {
        Move();
        Destroy();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="Enemy")
        {
            ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT, transform.position);
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.Hit(damge);
            PoolObject.Instance.DespawnObject(gameObject.transform, "Bullet");
            
        }
    }
}
