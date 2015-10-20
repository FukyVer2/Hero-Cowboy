using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SpawnEnemy : MonoBehaviour {
    public bool isRIght;
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
    void Spawn()
    {
        int soluot = Level.Instance.soluot;
        if (t > 2f)
        {
            if (isRIght)
            {
                string[] str = GetListEnemy(Level.Instance.luot[soluot].right);
                if (i < str.Length)
                {
                    int type = int.Parse(str[i].ToString());
                    switch (type)
                    {
                        case 1:
                            ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_RUN, transform.position, "Enemy", 1, ref Level.Instance.listEnemy);
                            break;
                        case 2:
                            ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_TANK, transform.position, "Enemy", 1, ref Level.Instance.listEnemy);
                            break;
                        case 3:
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
                string[] str = GetListEnemy(Level.Instance.luot[soluot].left);
                if (i < str.Length)
                {
                    int type = int.Parse(str[i].ToString());
                    switch (type)
                    {
                        case 1:
                            ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_RUN, transform.position, "Enemy", 0, ref Level.Instance.listEnemy);
                            break;
                        case 2:
                            ManagerObject.Instance.RenderEnemy(EnemyType.ENEMY_TANK, transform.position, "Enemy", 0, ref Level.Instance.listEnemy);
                            break;
                        case 3:
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
    string[] GetListEnemy(string _str)
    {
        string[] str = _str.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
        return str;
    }
}
