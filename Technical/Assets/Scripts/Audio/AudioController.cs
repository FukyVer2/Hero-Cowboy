using UnityEngine;
using System.Collections;

public enum AudioType
{
    SOUND_BG_INGAME = 0,
    SHOT = 1,
    ENEMY_ATTACK = 2,
    ENEMY_DIE = 3,
    PLAYER_SHOT = 4,
    PLAYER_HIT,
    GAME_OVER
};

public class AudioController : MonoSingleton<AudioController> {

    public AudioClip[] audioClip;

    public bool isSoundBG;
    public bool isSoundGamePlay;

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(AudioType audioType)
    {
        if (isSoundGamePlay)
        {
            audioSource.PlayOneShot(audioClip[(int)audioType]);
        }

    }

    public void PressMute()
    {
        isSoundGamePlay = !isSoundGamePlay;
        Debug.Log("Press Mute Sound Game Play = " + isSoundGamePlay);
    }

    public void PressMuteSoundBG()
    {
        isSoundBG = !isSoundBG;
        Debug.Log("Press Mute Sound BG = " + isSoundBG);
    }
}
