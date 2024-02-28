using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider musicSlider, masterSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (masterSlider != null)
            masterSlider.value = PreferencesManager.GetMasterVolume();

        if (musicSlider != null)
            musicSlider.value = PreferencesManager.GetMusicVolume();
    }

    public void ChangeSoundVolume(float soundLevel)
    {
        AudioManager.Instance.ChangeSoundVolume(soundLevel);
    }

    public void ChangeMusicVolume(float soundLevel)
    {
        AudioManager.Instance.ChangeMusicVolume(soundLevel);
    }
}