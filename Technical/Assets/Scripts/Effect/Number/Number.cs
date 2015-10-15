using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Number : MonoBehaviour {

    public float hp;
    public float timeRemove = 2.0f;
    public float speed;
    public List<Sprite> listNumber;
    public List<SpriteRenderer> listSpriteRender;
    
	// Use this for initialization
	void Start () {
        //Destroy(gameObject, timeRemove);
        
	}
    public void Init()
    {
        PoolObject.Instance.DespawnObjectTime(transform, "Number", timeRemove);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    [ContextMenu("TestNumber")]
    void Test()
    {
        Calculogic(hp);
    }
    public void Calculogic(float damge)
    {
        List<int> dayso = new List<int>();
        //tinh toan luong dam nhan vao
        if (damge < 9999)
        {

            int mod = -1;
            while ((int)damge / 10 > 0)
            {

                mod = (int)damge % 10;
                damge = damge / 10;
                dayso.Add(mod);
            }
            dayso.Add((int)damge);
        }
        int j = 0;

        // hien thi luong damge
        for (int i = dayso.Count - 1; i >= 0; --i)
        {
            listSpriteRender[j].sprite = listNumber[dayso[i]];
            j++;
        }
        for (int i = 3; i > dayso.Count - 1; --i)
        {
            listSpriteRender[i].sprite = null;
        }
    }
    void Move()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }
}
