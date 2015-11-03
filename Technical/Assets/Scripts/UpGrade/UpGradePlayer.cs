using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class UpGradePlayer :MonoBehaviour
{
    public Transform transfPlayer;
    public Transform transfCoinPlayer;
    private float hpPlayer = 1500;
    private int levelPlayer;// = PlayerPrefs.GetInt("LevelPlayer");
    private float trongSoHp = 1;
    private float[] goldLevel = {1200, 1800, 2375, 3400, 4150, 5575, 6775, 8125, 10250, 12750, 14200, 16500, 19795};
    void Start()
    {
        levelPlayer = PlayerPrefs.GetInt("LevelPlayer");
    }
    public void Init()
    {
        UIGameOver.Instance.SetTextGold();
        UIGameOver.Instance.SetTextLevelPlayer(GetLevel().ToString());
        UIGameOver.Instance.SetTextGoldPlayer((goldLevel[levelPlayer] / 100.0f).ToString());
    }
    void EffectCoin()
    {
        ManagerObject.Instance.RenderCoinUpGrade(ObjectType.COIN, transfCoinPlayer.position, 4);
    }
    [ContextMenu("Up Grade")]
    public void btUpGradePlayer()
    {
        float coin = GameController.Instance.gold;
        if (coin >= goldLevel[levelPlayer])
        {
            GameController.Instance.AddGold(- goldLevel[levelPlayer]);
            ManagerObject.Instance.RenderLevelUp(ObjectType.LEVELUP, transfPlayer.position);
            Particle.Instance.PlayerLevelUp(transfPlayer.position);
            EffectCoin();
            UpdateLevel();
           
            UIGameOver.Instance.SetTextGold();
            UIGameOver.Instance.SetTextLevelPlayer(GetLevel().ToString());
            UIGameOver.Instance.SetTextGoldPlayer((goldLevel[levelPlayer] / 100.0f).ToString());
        }
    }    
    public void UpdateLevel()
    {       
        this.levelPlayer += 1;
        SaveLevel();
        SetHp();
        SavePlayer();
        
    }
    public void ResetLevelPlayer()
    {
        levelPlayer = 1;
        SaveLevel();
        SetHp();
    }
    public void txtGetLevel()
    {
        int l = GetLevel();
        Debug.Log("Level = " + l);
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
