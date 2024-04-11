// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;

// Created a public static class called PreferencesManager
public static class PreferencesManager
{
    // Created a public static float method called GetMusicVolume that returned a GetFloat method that passed through the arguments MusicVolume and 1 that was accessed from PlayerPrefs
    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 1);
    }

    // Created a public static float method called GetMasterVolume that returned a GetFloat method that passed through the arguments MasterVolume and 1 that was accessed from PlayerPrefs
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1);
    }

    public static float GetBrightness()
    {
        return PlayerPrefs.GetFloat("Brightness", 1);
    }

    // Created a public static void method called SetMusicVolume that passed through the float soundLevel
    public static void SetMusicVolume(float soundLevel)
    {
        // Sets the music's volume by setting the float using the arguments MusicVolume and soundLevel that was accessed from PlayerPrefs
        PlayerPrefs.SetFloat("MusicVolume", soundLevel);
    }

    // Created a public static method called SetMasterVolume that passed through the float soundLevel
    public static void SetMasterVolume(float soundLevel)
    {
        // Sets the master's volume by setting the float value using the arguments MasterVolume and soundLevel that was accessed from PlayerPrefs
        PlayerPrefs.SetFloat("MasterVolume", soundLevel);
    }

    public static void SetBrightness(float soundLevel)
    {
        PlayerPrefs.SetFloat("Brightness", soundLevel);
    }
}
