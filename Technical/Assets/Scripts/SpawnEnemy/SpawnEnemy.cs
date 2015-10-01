using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public float timeSpawn = 0;//thoi gian giua cac luot Random
    public float countEnemy = 4;//so luong Enemy xuat hien trong 1 luot choi
    public Transform transfLeft;//vi tri random Enemy
    public Transform transfRight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(timeSpawn > 4)
        {
            RenderEnemy();
            
        }
        timeSpawn += Time.deltaTime;
	}
    IEnumerator DelaySpawn(float time)
    {
        yield return new WaitForSeconds(time);
        
    }
    float t = 0;//thoi gian giua 2 lan random Enemy trong 1 luot
    int i = 0;//so enemy xuat hien trong 1 luot
    void RenderEnemy()
    {
        if (i < countEnemy)
        {
            if (t > 0.5f)
            {
                //StartCoroutine(DelaySpawn(2f));
                int isRight = Random.Range(0, 2);
                if (isRight == 0)
                {
                    ManagerObject.Instance.RenderEnemy(ObjectType.ENEMY_RUN, transfLeft.position, "EnemyRun", isRight);
                }
                else
                {
                    ManagerObject.Instance.RenderEnemy(ObjectType.ENEMY_RUN, transfRight.position, "EnemyRun", isRight);
                }
                i++;
                t = 0;
            }
            t += Time.deltaTime;
        }
        else
        {
            timeSpawn = 0;
            i = 0;
        }
    }
}
