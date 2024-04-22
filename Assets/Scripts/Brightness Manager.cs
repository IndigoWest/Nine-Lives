// Uses the System.Collections namespace for project
using System.Collections;
// Uses the System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses the UnityEngine namespace for project
using UnityEngine;

// Creates a public class called BrightnessManager that inherits from MonoBehaviour
public class BrightnessManager : MonoBehaviour
{
    // Declares a public Light called sun
    public Light sun;

    // Creates a private method called Start
    private void Start()
    {
        // Sets the sun's intensity to the GetBrightness method in the PreferencesManager script
        sun.intensity = PreferencesManager.GetBrightness();
    }
}
