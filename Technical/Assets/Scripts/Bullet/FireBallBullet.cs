﻿using UnityEngine;
using System.Collections;

public class FireBallBullet : Bullet {

    //public float speed = 40;
    //public float damge = 100;

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

    public override void Move()
    {
        float posX = gameObject.transform.position.x;
        posX += speedCurrent * Time.deltaTime;
        gameObject.transform.position = new Vector3(posX, gameObject.transform.position.y, 0);
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
