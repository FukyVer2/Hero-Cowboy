using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class UpGradePlayer : MonoSingleton<UpGradePlayer> 
{
    private float hpPlayer = 1500;
    private int levelPlayer = PlayerPrefs.GetInt("LevelPlayer");
    private float trongSoHp = 1;

    public void UpdateLevel()
    {
        this.levelPlayer += 1;        
        SaveLevel();
        SetHp();
    }
    public int GetLevel()
    {
        int level = PlayerPrefs.GetInt("LevelPlayer");
        return level;
    }
    public float GetHpPlayer()
    {
        float hp = PlayerPrefs.GetFloat("HpPlayer");
        return hp;
    }
    void SaveLevel()
    {
        PlayerPrefs.SetInt("LevelPlayer", levelPlayer);
        PlayerPrefs.Save();
    }
    void SetHp()
    {
        this.hpPlayer = this.hpPlayer + (this.levelPlayer * this.hpPlayer) * trongSoHp / 100.0f;
        PlayerPrefs.Save();
    }
    //luu thong so Player xuong File
    [ContextMenu("Luu File xuong")]
    public void SavePlayer()
    {
        string fileName = "Player";
        Debug.Log("File Name : " + fileName + ".txt");

        string filePath = Application.dataPath + "/Resources/Player/";
        Debug.Log("File Path : " + filePath);

        SavePlayerToFile(filePath, fileName);
    }
    void SavePlayerToFile(string filePath, string fileName)
    {
        string firstLine = "id;type;level;hp;damge" + "\n";
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(firstLine);
        int id = 1;
        string type = "PLAYER";
        int levelPlayer = PlayerPrefs.GetInt("LevelPlayer");
        float hp = GetHpPlayer();
        float damge = 0;
        string valuePlayer = id.ToString() + ";" + type.ToString() + ";" + levelPlayer.ToString() + ";" + hp.ToString() + ";" + damge.ToString() + ";";
        
        stringBuilder.Append(valuePlayer);

        //luu file
        string playerData = stringBuilder.ToString();
        Debug.Log("Map data: " + playerData);

        string path = filePath + fileName + ".txt";
        StreamWriter stream = null;
        try
        {
            if (!File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
            }
            stream = File.CreateText(filePath + fileName + ".txt");
            stream.WriteLine(playerData);

            Debug.Log("Save Player Success");
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.StackTrace);
            Debug.Log(ex.Message);
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    }
}
