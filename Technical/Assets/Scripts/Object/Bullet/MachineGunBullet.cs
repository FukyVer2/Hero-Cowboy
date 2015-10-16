using UnityEngine;
using System.Collections;

public class MachineGunBullet : Bullet
{

    //public float speed = 40;
    //public float damge = 100;

    private float posX;
    private float posY;
    private float vx;
    private float vy;

    void Start()
    {
        posX = gameObject.transform.position.x;
        posY = gameObject.transform.position.y;
        vx = velocityX;
        vy = velocityY;
    }

    public override void ResetProperties()
    {
        posX = gameObject.transform.position.x;
        posY = gameObject.transform.position.y;
        vx = velocityX;
        vy = velocityY;
    }

    public override void Move()
    {
        vx += accelerationX * Time.deltaTime;
        vy += accelerationY * Time.deltaTime;

        if (direction == BulletDirection.LEFT)
            posX -= vx * Time.deltaTime;
        else if (direction == BulletDirection.RIGHT)
            posX += vx * Time.deltaTime;

        posY += vy * Time.deltaTime;

        gameObject.transform.position = new Vector3(posX, posY, 0);
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
        base.Die();
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
            //ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT, transform.position);
            ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT_3, transform.position);
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (isCritDamge)
                    enemy.Hit(damge, true);
                else
                {
                    enemy.Hit(damge, false);
                }
            }                
            PoolObject.Instance.DespawnObject(gameObject.transform, "Bullet");

        }
    }
}
