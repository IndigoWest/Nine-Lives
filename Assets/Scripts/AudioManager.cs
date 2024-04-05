// Uses System namespace for project
using System;
// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;
// Uses UnityEngine.UI namespace for project
using UnityEngine.UI;
// Uses UnityEngine.Audio namespace for project
using UnityEngine.Audio;

// Creates a public class called AudioManager that inherits from MonoBehaviour
public class AudioManager : MonoBehaviour
{
    // Declares a private static AudioManager called instance
    private static AudioManager instance;

    // Creates a public static AudioManager method called Instance that has a getter and returns instance
    public static AudioManager Instance { get { return instance; } }

    // Declares a public AudioMixer called masterMixer
    public AudioMixer masterMixer;

    // Creates a private method called Awake
    private void Awake()
    {
        // Creates an if statement where is instance does not equal null and instance does not equal this, then it will destroy this.gameObject
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        // Else, it sets instance to this
        else
        {
            instance = this;
        }
        // Calls the DontDestroyOnLoad method that passes through this.gameObject
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Calls the SetFloat method from the masterMixer and passes through the string variable MasterVolume and the GetMasterVolume method from the PreferencesManager
        masterMixer.SetFloat("MasterVolume", PreferencesManager.GetMasterVolume());
        // Calls the SetFloat method from the masterMixer and passes through the string variable MusicVolume and the GetMusicVolume method from the PreferencesManager
        masterMixer.SetFloat("MusicVolume", PreferencesManager.GetMusicVolume());
    }

    // Creates a public method called ChangeSoundVolume that passes through the float variable soundLevel
    public void ChangeSoundVolume(float soundLevel)
    {
        // Calls the SetFloat method from the masterMixer and passes through the string variable MasterVolume and soundLevel
        masterMixer.SetFloat("MasterVolume", soundLevel);
        // Calls the SetMasterVolume method from the PreferencesManager and passes it through soundLevel
        PreferencesManager.SetMasterVolume(soundLevel);
    }
    // Creates a public method called ChangeMusicVolume that passes through the float variable soundLevel
    public void ChangeMusicVolume(float soundLevel)
    {
        // Calls the SetFloat method from the masterMixer and passes through the string variable MusicVolume and soundLevel
        masterMixer.SetFloat("MusicVolume", soundLevel);
        // Calls the SetMusicVolume method from the PreferencesManager and passes it through soundLevel
        PreferencesManager.SetMusicVolume(soundLevel);
    }
}
