// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;
// Uses UnityEngine.UI namespace for project
using UnityEngine.UI;

// Creates a public class called MenuManager that inherits from MonoBehaviour
public class MenuManager : MonoBehaviour
{
    // Declares a public Slider called musicSlider and masterSlider
    public Slider musicSlider, masterSlider, brightnessSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Creates an if statement where if the masterSlider does not equal null, the value of the masterSlider is set to the GetMasterVolume method from the PreferencesManager
        if (masterSlider != null)
            masterSlider.value = PreferencesManager.GetMasterVolume();

        // Creates an if statement where if the musicSlider does not equal null, the value of the musicSlider is set to the GetMusicVolume method from the PreferencesManager
        if (musicSlider != null)
            musicSlider.value = PreferencesManager.GetMusicVolume();

        if (brightnessSlider != null)
            brightnessSlider.value = PreferencesManager.GetBrightness();
    }

    // Creates a public method called ChangeSoundVolume that passes through the float value soundLevel
    public void ChangeSoundVolume(float soundLevel)
    {
        // When the method is called, it accesses the AudioManager script to change the sound's volume
        AudioManager.Instance.ChangeSoundVolume(soundLevel);
    }

    // Creates a public method called ChangeMusicVolume that passes through the float value soundLevel
    public void ChangeMusicVolume(float soundLevel)
    {
        // When the method is called, it accesses the AudioManager script to change the music's volume
        AudioManager.Instance.ChangeMusicVolume(soundLevel);
    }

    public void ChangeBrightness(float level)
    {
        PreferencesManager.SetBrightness(level);
    }
}