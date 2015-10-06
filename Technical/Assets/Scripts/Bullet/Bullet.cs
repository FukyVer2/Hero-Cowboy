using UnityEngine;
using System.Collections;

public abstract class Bullet : MonoBehaviour {

    public float speed; //Tốc độ di chuyển thực
    public float speedCurrent; // Tốc độ di chuyển hiện tại
    public float damge; //Dagme
    public Vector2 range; // Vùng ảnh hưởng của đạn
    //public float respawn; // Thời gian bắn ra một viên đạn
    //public int quantity; // Số lượng viên đạn hiện tại của súng
    public BulletDirection direction; //Hướng di chuyển của đạn
    public float angle; //Góc quay của viên đạn
    public BulletOfObjectType bulletOfObject; //Đạn của đối tượng nào

    public virtual void InitBullet()
    {
        //Khởi tạo ban đầu của đạn gồm một số thông số:
        // + Hướng di chuyển của đạn
        // + Rotate hình
        // + Thay đổi giá trị tốc độ di chuyển của đạn
        direction = BulletDirection.LEFT;
        gameObject.transform.localPosition = Vector3.zero;
        switch (direction)
        {
            case BulletDirection.LEFT:
                {
                    speedCurrent = speed;
                    FlipHorizontal(0);
                    break;
                }
            case BulletDirection.RIGHT:
                {
                    speedCurrent = -speed;
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
        Destroy(gameObject);
    }

    public virtual void Rotate(float angle) //quay theo chiều z
    {
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public virtual void FlipHorizontal(float angle)
    {
        //lat theo chieu ngang
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    public virtual void FlipVertical(float angle)
    {
        //Lat theo chieu doc
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(angle, 0, 0));
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