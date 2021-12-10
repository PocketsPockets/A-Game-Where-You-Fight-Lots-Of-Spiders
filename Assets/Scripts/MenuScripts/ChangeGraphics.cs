using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class ChangeGraphics : MonoBehaviour
{
    public Dropdown graphicsQuality;
    int qualityLevel;
    void Update()
    {
        qualityLevel = QualitySettings.GetQualityLevel();
        Debug.Log(qualityLevel);
        GraphicsSettings();
    }
    void GraphicsSettings()
    {
        if (graphicsQuality.value == 0)
        {
            QualitySettings.SetQualityLevel(6);
        }
        if (graphicsQuality.value == 1)
        {
            QualitySettings.SetQualityLevel(5);
        }
        if (graphicsQuality.value == 2)
        {
            QualitySettings.SetQualityLevel(4);
        }
        if (graphicsQuality.value == 3)
        {
            QualitySettings.SetQualityLevel(3);
        }
        if (graphicsQuality.value == 4)
        {
            QualitySettings.SetQualityLevel(2);
        }
        if (graphicsQuality.value == 5)
        {
            QualitySettings.SetQualityLevel(1);
        }
        if (graphicsQuality.value == 6)
        {
            QualitySettings.SetQualityLevel(0);
        }
    }
}
