﻿using UnityEngine;
using System.Collections;

public enum BulletType
{
    NONE = 0,
    BULLET_FIRE = 1,
    BULLET_MACHINEGUN =2
}
public abstract class Bullet : MonoBehaviour {

    public float speed; //Tốc độ di chuyển thực
    public float speedCurrent; // Tốc độ di chuyển hiện tại
    public float velocityX; // Vận tốc theo chiều x
    public float velocityY; //Vận tốc theo chiều y
    public float accelerationX; //gia tốc của đạn
    public float accelerationY; //gia tốc của đạn
    public float damge; //Dagme
    public Vector2 range; // Vùng ảnh hưởng của đạn
    //public float respawn; // Thời gian bắn ra một viên đạn
    //public int quantity; // Số lượng viên đạn hiện tại của súng
    public BulletDirection direction; //Hướng di chuyển của đạn
    public float angle; //Góc quay của viên đạn
    public BulletOfObjectType bulletOfObject; //Đạn của đối tượng nào
    public bool isCritDamge = false;

    public BulletType type = BulletType.NONE;
    public virtual void SetDamge()
    {
        switch(type)
        {
            case BulletType.BULLET_FIRE:                
                break;
            case BulletType.BULLET_MACHINEGUN:
                break;

        }
    }
    public virtual void InitBullet()
    {
        //Khởi tạo ban đầu của đạn gồm một số thông số:
        // + Hướng di chuyển của đạn
        // + Rotate hình
        // + Thay đổi giá trị tốc độ di chuyển của đạn
        isCritDamge = false;
        direction = BulletDirection.LEFT;
        gameObject.transform.localPosition = Vector3.zero;
        switch (direction)
        {
            case BulletDirection.LEFT:
                {
                    speedCurrent = -speed;
                    FlipHorizontal(0);
                    break;
                }
            case BulletDirection.RIGHT:
                {
                    speedCurrent = speed;
                    FlipHorizontal(-180);
                    break;
                }
            case BulletDirection.NONE:
                {
                    speedCurrent = 0;
                    FlipHorizontal(0);
                    break;
                }
        }
    }

    public virtual void InitBullet(Vector3 _positionStart, BulletDirection _direction)
    {
        //Khởi tạo ban đầu của đạn gồm một số thông số:
        // + Hướng di chuyển của đạn
        // + Rotate hình
        // + Thay đổi giá trị tốc độ di chuyển của đạn
        gameObject.transform.localPosition = _positionStart;
        direction = _direction;
        isCritDamge = false;
        switch (direction)
        {
            case BulletDirection.LEFT:
                {
                    speedCurrent = -speed;
                    FlipHorizontal(0);
                    break;
                }
            case BulletDirection.RIGHT:
                {
                    speedCurrent = speed;
                    FlipHorizontal(180);
                    break;
                }
            case BulletDirection.NONE:
                {
                    speedCurrent = 0;
                    FlipHorizontal(0);
                    break;
                }
        }        
    }

    public virtual void ResetProperties()
    {
        //dothing
        isCritDamge = false;
    }

    public void SetDamge(float _damge)
    {
        this.damge = _damge;        
    }

    public void SetBulletOfObjectType(BulletOfObjectType _bulletOfObjectType)
    {
        this.bulletOfObject = _bulletOfObjectType;
    }

    public virtual void Move()
    {
        //Tùy đối tượng bullet mà kiểu di chuyển là khác nhau
    }

    public virtual void KillEnemies()
    {

        //Nếu là enemy thì tiêu diệt player
        //Ngược lại thì tiêu diệt enemies
    }

    public virtual void Die()
    {
        //Tao hiệu ưng nổ của đạn tại đây
        //Khi đạn bị nổ thì đưa vào lại trong stack
        if (gameObject.transform.position.x >= Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x ||
           gameObject.transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
            PoolObject.Instance.DespawnObject(gameObject.transform, "Bullet");
    }

    void Update()
    {
        BulletUpdate();
    }

    public virtual void BulletUpdate()
    {
        //Update bullet tại đây
    }

    public virtual void Rotate(float angle) //quay theo chiều z
    {
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, angle));
    }

    public virtual void FlipHorizontal(float angle)
    {
        //lat theo chieu ngang
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.x, angle, gameObject.transform.rotation.z));
    }

    public virtual void FlipVertical(float angle)
    {
        //Lat theo chieu doc
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(angle, gameObject.transform.rotation.y, gameObject.transform.rotation.z));
    }
    public virtual void Reset()
    {
        isCritDamge = false;
    }
}

public enum BulletDirection
{
    LEFT = 0,
    RIGHT = 1,
    NONE = 2
}

public enum BulletOfObjectType
{
    PLAYER = 0,
    ENEMIES = 1,
    TOWER = 2,
    BOSS = 3,
    OTHER = 4
}
