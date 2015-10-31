using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LevelInfo {


    public string filePath;
    private List<LevelIndex> listLevelIndex = new List<LevelIndex>();
    public List<LevelIndex> listPlayer;
    public List<LevelIndex> listEnemy;
    public List<LevelIndex> listGun;
    public LevelInfo()
    {}
    public LevelInfo(string _filePath)
    {
        this.filePath = _filePath;

    }
   
    public void LoadLevelFromFile(string filePath, LevelType levelType)
    {
        if (this.listLevelIndex != null)
        {
            listLevelIndex.Clear();            
        }
        TextAsset textAsset = Resources.Load<TextAsset>(filePath);
        if(textAsset != null)
        {
            string[] temp = textAsset.text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            
            for(int i = 1; i < temp.Length; i++)//bo dong dau tien
            {
                string[] context = temp[i].Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                
                LevelIndex levelIndex = new LevelIndex(context, levelType);                
                listLevelIndex.Add(levelIndex);
                switch(levelType)
                {
                    case LevelType.NONE:
                        break;
                    case LevelType.PLAYER:
                        listPlayer.Add(levelIndex);
                        break;
                    case LevelType.ENEMY:
                        listEnemy.Add(levelIndex);
                        break;
                    case LevelType.GUN:
                        listGun.Add(levelIndex);
                        break;
                }
            }
        }
        else
        {
            Debug.Log("chua load dc file");
        }
    }
}
