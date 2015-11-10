using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum StageSpawn
{
    NONE = 0,
    ENEMY = 1,
    BOSS = 2,
    WIN = 3,
    VICTORY = 4
}
[System.Serializable]
public class Luot
{
    public List<Alternate> luot = new List<Alternate>();
    public GameObject boss;
    public Luot()
    {
        luot = new List<Alternate>();
    }
    public Luot(GameObject _boss)
    {
        this.boss = _boss;
    }
}
public class Level : MonoSingleton<Level> {

    public List<Luot> listLevel = new List<Luot>();
    public List<Enemy> listEnemy;
    public int soluot = 0;
    public List<SpawnEnemy> listSpawn;
    public StageSpawn stage = StageSpawn.NONE;
    public int level;

	// Use this for initialization
	void Start () {
        //InitLevel();
	}
    public void InitLevel()
    {
        stage = StageSpawn.ENEMY;       
        level = GameController.Instance.level;
        //LoadAllLevelFromFile("Level");
        //string l = (soluot + 1).ToString() + "/10";
        UIGamePlay.Instance.SetLuot((soluot + 1).ToString() + "/10");
    }
    [ContextMenu("Load Level")]
    void Test2()
    {
        LoadAllLevelFromFile("Level");
    }
    public void LoadAllLevelFromFile(string filePath)
    {
        TextAsset[] textAsset = Resources.LoadAll<TextAsset>(filePath);

        if (textAsset != null)
        {
            for (int i = 0; i < textAsset.Length; i++)
            {
                string[] temp = textAsset[i].text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < temp.Length; j++)
                {
                    string[] context = temp[j].Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                    Alternate lr = new Alternate(context[1], context[2]);
                    if (listLevel != null)
                        listLevel[i].luot.Add(lr);
                    else
                    {
                        Debug.Log("chua khoi tao list Level");
                    }
                }
            }
        }
        else
        {
            Debug.Log("Chua load dc file : " + filePath);
        }
        for(int i = 0; i < listLevel.Count;i++)
        {
            listLevel[i].boss = ManagerObject.Instance.listBoss[i];
        }
    }
    public void RemoveListEnemy(Enemy enemy)
    {
        if(listEnemy.Contains(enemy))
        {
            listEnemy.Remove(enemy);

            if (stage != StageSpawn.VICTORY)
            {
                if (listEnemy.Count <= 0)
                {
                    //if (soluot < listLevel[level].luot.Count - 1 && stage != StageSpawn.BOSS)
                    if (soluot < 9 && stage != StageSpawn.BOSS)
                    {
                        soluot++;
                        UIGamePlay.Instance.SetLuot((soluot + 1).ToString() + "/10");
                        UpdateSpawn();
                    }
                    else
                    {
                        stage = StageSpawn.BOSS;
                        UIGamePlay.Instance.SetLuot("BOSS");
                        Invoke("Boss", 2.0f);
                    }
                }
            }
        }        
    }
    void UpdateSpawn()
    {
        for (int i = 0; i < listSpawn.Count; i++)
        {
            listSpawn[i].Reset();
        }
    }
    void Boss()
    {
        Instantiate(listLevel[level].boss, new Vector3(-3.5f, 0.5f, 0), Quaternion.identity);
    }
    
    public void SetStage()
    {
        stage = StageSpawn.WIN;
        Win();
    }
    void Win()
    {
        GameController.Instance.GameWin();
        if (level <= listLevel.Count - 1)
            GameController.Instance.LevelUp();
        else
        {
            stage = StageSpawn.VICTORY;
            GameController.Instance.isStopSpawnEnemy = false;
            Debug.Log("Game Win CMNR Ver 1");
        }
    }
    public void LevelUp(int _level)
    {
        if (level < listLevel.Count - 1)
        {
            level = _level;
            stage = StageSpawn.ENEMY;
            soluot = 0;
            UpdateSpawn();
            for (int i = 0; i < listSpawn.Count; i++)
            {
                listSpawn[i].SetLevel(level);
            }
            listEnemy.Clear();
            UIGamePlay.Instance.SetLuot((soluot + 1).ToString() + "/10");
        }
        else
        {
            stage = StageSpawn.VICTORY;
            GameController.Instance.isStopSpawnEnemy = false;
            Debug.Log("Game Win CMNR");
        }
    }
}
