using UnityEngine;
using System.Collections;

public class GrendaBullet : Bullet
{

    //public float speed = 40;
    //public float damge = 100;
    public float rangeBox;
    public RangeBullet rangeBullet;
    private float posX;
    private float posY;
    private float vx;
    private float vy;

    void Start()
    {
        posX = gameObject.transform.parent.position.x;
        posY = gameObject.transform.parent.position.y;
        vx = velocityX;
        vy = velocityY;
    }

    public override void InitBullet(Vector3 _positionStart, BulletDirection _direction)
    {
        //Khởi tạo ban đầu của đạn gồm một số thông số:
        // + Hướng di chuyển của đạn
        // + Rotate hình
        // + Thay đổi giá trị tốc độ di chuyển của đạn
        gameObject.transform.parent.localPosition = _positionStart;
        direction = _direction;
        //Rotate(90);
        switch (direction)
        {
            case BulletDirection.LEFT:
                {
                    speedCurrent = -speed;
                    FlipHorizontal(180);
                    break;
                }
            case BulletDirection.RIGHT:
                {
                    speedCurrent = speed;
                    FlipHorizontal(0);
                    break;
                }
            case BulletDirection.NONE:
                {
                    speedCurrent = 0;
                    FlipHorizontal(0);
                    break;
                }
        }
        // Rotate(-90);
    }


    public override void ResetProperties()
    {
        posX = gameObject.transform.parent.position.x;
        posY = gameObject.transform.parent.position.y;
        vx = velocityX;
        vy = velocityY;
    }

    public override void Move()
    {
        vx += accelerationX * Time.deltaTime;
        vy += accelerationY * Time.deltaTime;

        if (direction == BulletDirection.LEFT)
            posX -= vx * Time.deltaTime;
        else if(direction == BulletDirection.RIGHT)
            posX += vx * Time.deltaTime;

        posY += vy * Time.deltaTime;

        gameObject.transform.parent.position = new Vector3(posX, posY, 0);
    }

    public virtual void KillEnemies()
    {
        foreach (var enemyObj in rangeBullet.enemyInBoxs)
        {
            enemyObj.Hit(damge);
            rangeBullet.enemyInBoxs.Remove(enemyObj);
        }
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
            PoolObject.Instance.DespawnObject(gameObject.transform.parent, "Bullet");
    }

    public override void BulletUpdate()
    {
        Move();
        Die();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT, transform.position);
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
                enemy.Hit(damge);
            PoolObject.Instance.DespawnObject(gameObject.transform.parent, "Bullet");

        }
        else if (col.tag == "Ground")
        {
            //ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT, transform.position);
            PoolObject.Instance.DespawnObject(gameObject.transform.parent, "Bullet");
        }
    }
}
