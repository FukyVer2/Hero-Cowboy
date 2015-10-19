using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour
{

    public float speed = 1;
    public float timeRemove = 1.0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }
    public void Init()
    {
        PoolObject.Instance.DespawnObjectTime(transform, "Effect", timeRemove);
    }
}
