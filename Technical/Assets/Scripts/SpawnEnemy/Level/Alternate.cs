using UnityEngine;
using System.Collections;

//so Enemy trong 1 luot
[System.Serializable]
public class Alternate  {

    public int countEnemyRun = 0;
    public int countEnemyTank = 0;
    public int countEnemyBoom = 0;
    public int countEnemyWeak = 0;
    public int countEnemyFly = 0;

    public string left = "";
    public string right = "";

    public Alternate()
    {

    }
    public Alternate(int run = 0, int tank = 0, int boom = 0)
    {

    }
    public int CountEnemy()
    {
        return countEnemyRun + countEnemyTank + countEnemyBoom + countEnemyWeak + countEnemyFly;
    }
}
