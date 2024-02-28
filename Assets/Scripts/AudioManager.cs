using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    public AudioMixer masterMixer;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        masterMixer.SetFloat("MasterVolume", PreferencesManager.GetMasterVolume());
        masterMixer.SetFloat("MusicVolume", PreferencesManager.GetMusicVolume());
    }

    public void ChangeSoundVolume(float soundLevel)
    {
        masterMixer.SetFloat("MasterVolume", soundLevel);
        PreferencesManager.SetMasterVolume(soundLevel);
    }
    public void ChangeMusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("MusicVolume", soundLevel);
        PreferencesManager.SetMusicVolume(soundLevel);
    }
}
