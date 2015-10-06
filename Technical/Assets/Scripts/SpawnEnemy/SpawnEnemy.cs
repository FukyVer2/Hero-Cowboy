﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SpawnEnemy : MonoSingleton<SpawnEnemy> {


    public float timeSpawnEnemy = 4;//thoi gian giua cac luot Random
    public float countEnemy = 3;//so luong Enemy xuat hien trong 1 luot choi
    public Transform transfLeft;//vi tri random Enemy
    public Transform transfRight;

    public Slider slider;
    private float timeSpawn = 0;
    private float timeLevel = 0;
    public int timeGame = 0;
    public List<Enemy> listEnemy = new List<Enemy>();
    public Alternate[] luot = new Alternate[10];
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.A))
            //RenderEnemyver2();
        //if (!GameController.Instance.isStopSpawnEnemy)
        //{
        //    if (timeSpawn > timeSpawnEnemy)
        //    {
        //        RenderEnemyTime();

        //    }
        //    timeSpawn += Time.deltaTime;
        //    if (timeLevel >= 1)
        //    {
        //        timeGame += 1;
        //        //xu li o day;
        //        Level(timeGame);
        //        slider.value -= 1.0f / 120.0f;
        //        timeLevel = 0;
        //        if (timeGame >= 120)
        //        {
        //            GameController.Instance.GameWin();
        //        }
        //    }
        //    timeLevel += Time.deltaTime;
        //}
	}
    void Level(int _time)
    {
        switch(_time)
        {
            case 24:
                countEnemy = 4;
                timeSpawnEnemy = 4;
                //Debug.Log("Count Enemy = " + countEnemy + "----Time = " + timeSpawnEnemy);
                break;
            case 48:
                countEnemy = 5;
                timeSpawnEnemy = 4;
                //Debug.Log("Count Enemy = " + countEnemy + "----Time = " + timeSpawnEnemy);
                break;
            case 72:
                countEnemy = 5;
                timeSpawnEnemy = 3;
                //Debug.Log("Count Enemy = " + countEnemy + "----Time = " + timeSpawnEnemy);
                break;
            case 96:
                countEnemy = 6;
                timeSpawnEnemy = 3;
                //Debug.Log("Count Enemy = " + countEnemy + "----Time = " + timeSpawnEnemy);
                break;
        }
    }    
    float t = 0;//thoi gian giua 2 lan random Enemy trong 1 luot
    int i = 0;//so enemy xuat hien trong 1 luot
    void RenderEnemyTime()
    {
        if (i < countEnemy)
        {
            if (t > 0.5f)
            {
                int isRight = Random.Range(0, 2);
                int typeEnemy = Random.Range(0, 2);

                if (isRight == 0)
                {
                    ManagerObject.Instance.RenderEnemy((EnemyType)typeEnemy, transfLeft.position, "Enemy", isRight, ref listEnemy);
                }
                else
                {
                    ManagerObject.Instance.RenderEnemy((EnemyType)typeEnemy, transfRight.position, "Enemy", isRight, ref listEnemy);
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
    //remove Enemy ra khoi list
    //de kiem tra xem luot do da Finish chua
    public void RemoveListEnemy(Enemy e)
    {
        if (listEnemy.Contains(e))
            listEnemy.Remove(e);
    }
    public void Reset()
    {
        timeGame = 0;
        timeSpawnEnemy = 4;
        countEnemy = 3;
        slider.value = 1;
    }
    [ContextMenu("Test")]
    void RenderEnemyver2()
    {
        RenderEnemy(typeEnemy, luot[soluot].countEnemyRun);
    }
    int count = 0;//so luong Enemy loai nao trong 1 luot Render
    int countAll = 0;//tong so Enemy trong Man choi
    int typeEnemy = 0;//loai Enemy
    int soluot = 0;//so luot 
    int n = 0;//loai Enemy sinh ra trong 1 luot
    void RenderEnemy(int type, int countE)
    {
        if (count > luot[soluot].CountEnemy())
        {
            return;
        }       
        type = typeEnemy;

        if(n < countE)
        {
            count++;
            countAll++;
            n++;
            RenderEnemy(type, countE);
        }
        else
        {
            typeEnemy++;
            n = 0;
            RenderEnemy(type, luot[soluot].countEnemyTank);
        }
    }
    [ContextMenu("Update Luot")]
    void UpdateLuot()
    {
        typeEnemy = 0;
        soluot++;
        n = 0;
        count = 0;
        RenderEnemy(typeEnemy, luot[soluot].countEnemyRun);
    }

}
