using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeSensitivity : MonoBehaviour
{
    public PreferredSensitivity preferredSensitivity;
    public Slider sensitivitySlider;
    void Start()
    {
        preferredSensitivity = FindObjectOfType<PreferredSensitivity>();
    }
    void Update()
    {
        preferredSensitivity.preferredMouseLookSensitivity = sensitivitySlider.value;
        Debug.Log(preferredSensitivity.preferredMouseLookSensitivity);
    }
}
