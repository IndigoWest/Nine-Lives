using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessManager : MonoBehaviour
{
    public Light sun;

    private void Start()
    {
        sun.intensity = PreferencesManager.GetBrightness();
    }
}
