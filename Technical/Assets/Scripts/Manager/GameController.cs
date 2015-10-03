using UnityEngine;
using System.Collections;

public class GameController : MonoSingleton<GameController> {

	// Use this for initialization
    public Cowboy heroCowboy;
    public bool isStopSpawnEnemy;

	void Start () {
        AudioController.Instance.PlaySoundRepeat(AudioType.SOUND_BG_INGAME);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void StopSpawnEnemy()
    {
        isStopSpawnEnemy = true;
    }
}
