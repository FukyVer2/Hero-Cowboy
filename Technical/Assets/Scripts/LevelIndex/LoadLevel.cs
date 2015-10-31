using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadLevel : MonoBehaviour {

    public List<Luot> listLevel = new List<Luot>();
    public List<string> left = new List<string>();
    public List<string> right = new List<string>();

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
                for(int j = 1 ; j < temp.Length ; j++)
                {
                    string[] context = temp[j].Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                    Alternate lr = new Alternate(context[1], context[2]);
                    listLevel[i].luot.Add(lr);

                }
            }
        }
        else
        {
            Debug.Log("Chua load dc file : " + filePath);
        }
    }
}
