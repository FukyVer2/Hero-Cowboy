using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public List<AudioConfig> audioResourceCofig;
    private Dictionary<AudioType, AudioClip> audioReSources;

    public bool isSoundBG;
    public bool isSoundGamePlay;

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioResourceCofig = new List<AudioConfig>();
        audioReSources = new Dictionary<AudioType, AudioClip>();
        RevertDataToDictionary();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RevertDataToDictionary()
    {
        foreach (var item in audioResourceCofig)
        {
            audioReSources.Add(item.audioType, item.audioClip);
        }
    }

    public AudioClip GetAudioClip(AudioType audioType)
    {
        if (audioReSources.ContainsKey(audioType))
        {
            return audioReSources[audioType];
        }
        else
            return null;
    }

    public void PlaySound(AudioType audioType)
    {
        AudioClip _audioClip = GetAudioClip(audioType);
        if (_audioClip != null)
        {
            if (isSoundGamePlay)
            {
                audioSource.PlayOneShot(_audioClip);
            }
        }
        else
        {
            Debug.LogError("Chua co sound");
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

[System.Serializable]
public class AudioConfig
{
    public AudioType audioType;
    public AudioClip audioClip;
}