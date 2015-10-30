using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TestPlayer : MonoBehaviour
{
    public LevelInfo levelinfo;

    [ContextMenu("Test load file")]
    void Test()
    {
        levelinfo.LoadLevelFromFile("Player/Player", LevelType.PLAYER);
    }
}
