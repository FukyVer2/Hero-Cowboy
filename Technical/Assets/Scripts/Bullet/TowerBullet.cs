using UnityEngine;
using System.Collections;

public class TowerBullet : Bullet
{

    //public float speed = 40;
    //public float damge = 100;
    //private float posX;
    //private float posY;
    //private float vx;
    //private float vy;
    public float scaleUnit;
    public Vector3 target;

    void Start()
    {
        //posX = gameObject.transform.position.x;
        //posY = gameObject.transform.position.y;
        //vx = velocityX;
        //vy = velocityY;
        //target = new Vector3(20, -40, 0);
    }

    public override void ResetProperties()
    {
        //posX = gameObject.transform.position.x;
        //posY = gameObject.transform.position.y;
        //vx = velocityX;
        //vy = velocityY;
    }

    public void SetTarget(Vector3 _target)
    {
        this.target = _target;
    }

    public override void InitBullet(Vector3 _positionStart, BulletDirection _direction)
    {
        //Khởi tạo ban đầu của đạn gồm một số thông số:
        // + Hướng di chuyển của đạn
        // + Rotate hình
        // + Thay đổi giá trị tốc độ di chuyển của đạn
        gameObject.transform.localPosition = _positionStart;
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

    public float CalAngleWithTarget()
    {
        Vector3 positionTarget = target;
        Vector3 relative = positionTarget - transform.position;//transform.InverseTransformPoint(target.position);
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

        return angle;
    }

    public float CalDistanceWithTarget()
    {
        Vector3 positionTarget = target;
        return Vector3.Distance(positionTarget, transform.position);
    }

    public void AppearBullet()
    {
        float angle = CalAngleWithTarget();
        float distance = CalDistanceWithTarget();
        transform.localScale = new Vector3(transform.localScale.x, distance * scaleUnit , transform.localScale.z);
        iTween.ScaleTo(gameObject, iTween.Hash("isLocal",true,
                                                "scale",new Vector3(0.4f, 0.5f, 0.5f), 
                                                iT.ScaleTo.time, 0.35f,
                                                //iT.ScaleTo.easetype, iTween.EaseType.easeInSine,
                                                iT.ScaleTo.oncomplete, "Complete"));
        Rotate(-270 + angle);
    }

    private void Complete()
    {
        transform.localScale = Vector3.zero;
    }

    public override void Move()
    {
        ///*
        //float posX = gameObject.transform.position.x;
        //posX += speedCurrent * Time.deltaTime;
        //gameObject.transform.position = new Vector3(posX, gameObject.transform.position.y, 0);
        //*/
        //vx += accelerationX * Time.deltaTime;
        //vy += accelerationY * Time.deltaTime;

        //if (direction == BulletDirection.LEFT)
        //    posX -= vx * Time.deltaTime;
        //else if (direction == BulletDirection.RIGHT)
        //    posX += vx * Time.deltaTime;

        //posY += vy * Time.deltaTime;

        //gameObject.transform.position = new Vector3(posX, posY, 0);
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
        //Move();
        //Die();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            ManagerObject.Instance.RenderParticalEnemy(ObjectType.ENEMY_HIT, transform.position);
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
                enemy.Hit(damge);
            //PoolObject.Instance.DespawnObject(gameObject.transform, "Bullet");

        }
    }
}