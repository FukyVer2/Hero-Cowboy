using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SpawnEnemy : MonoBehaviour {
    public bool isRIght;
    private int level;
    void Start()
    {
        level = Level.Instance.level;
    }
    void Update()
    {
        Spawn();
    }
    int i = 0;
    float t = 0;
    [ContextMenu("Reset")]
    public void Reset()
    {
        i = 0;
    }
    public void SetLevel(int _level)
    {
        level = _level;
    }
    void Spawn()
    {
        int soluot = Level.Instance.soluot;
        if (Level.Instance.stage == StageSpawn.ENEMY)
        {
            if (t > 2.0f)
            {
                if (isRIght)
                {
                    string[] str = GetListEnemy(Level.Instance.listLevel[level].luot[soluot].right);
                    if (i < str.Length)
                    {
                        int type = int.Parse(str[i].ToString());
                        switch (type)
                        {
                            case 0:
                                break;
                            case 1:
                                ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_RUN, transform.position, "Enemy", 1, ref Level.Instance.listEnemy);
                                break;
                            case 2:
                                ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_TANK, transform.position, "Enemy", 1, ref Level.Instance.listEnemy);
                                break;
                            case 3:
                                ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_FLY, new Vector3(3.0f, 1.6f, 0), "Enemy", 1, ref Level.Instance.listEnemy);
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                        }
                        i++;
                    }
                }
                else
                {
                    string[] str = GetListEnemy(Level.Instance.listLevel[level].luot[soluot].left);
                    if (i < str.Length)
                    {
                        int type = int.Parse(str[i].ToString());
                        switch (type)
                        {
                            case 0:
                                break;
                            case 1:
                                ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_RUN, transform.position, "Enemy", 0, ref Level.Instance.listEnemy);
                                break;
                            case 2:
                                ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_TANK, transform.position, "Enemy", 0, ref Level.Instance.listEnemy);
                                break;
                            case 3:
                                ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_FLY, new Vector3(-3.0f, 1.6f, 0), "Enemy", 1, ref Level.Instance.listEnemy);

                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                        }
                        i++;
                    }
                }
                t = 0;
            }
            t += Time.deltaTime;
        }
    }
    string[] GetListEnemy(string _str)
    {
        string[] str = _str.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
        return str;
    }
}
