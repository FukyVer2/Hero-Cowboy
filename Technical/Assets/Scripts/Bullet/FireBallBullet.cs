using UnityEngine;
using System.Collections;

public class FireBallBullet : Bullet {

    //public float speed = 40;
    //public float damge = 100;
    
    public override void Move()
    {
        float posX = gameObject.transform.position.x;
        posX += speedCurrent * Time.deltaTime;
        gameObject.transform.position = new Vector3(posX, 0, 0);
    }

    public virtual void KillEnemies()
    {
        //Nếu là enemy thì tiêu diệt player
        //Ngược lại thì tiêu diệt enemies
    }
    /*
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

    public void ChangeDirection(BulletDirection direction)
    {
        switch(direction){
            case BulletDirection.LEFT:
                {
                    speed = (speed < 0) ? speed : -speed;
                    gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                }
            case BulletDirection.RIGHT:
                {
                    speed = (speed > 0) ? speed : -speed;
                    gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                }
            case BulletDirection.NONE:
                {
                    speed = 0;
                    break;
                }
        }

    }
    */
    public override void Die()
    {
        if (gameObject.transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x ||
            gameObject.transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
            PoolObject.Instance.DespawnObject(gameObject.transform, "Bullet");
    }

    public void Update()
    {
        Move();
        Die();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag =="Enemy")
        {
            ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT, transform.position);
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
                enemy.Hit(damge);
            PoolObject.Instance.DespawnObject(gameObject.transform, "Bullet");
            
        }
    }
}
