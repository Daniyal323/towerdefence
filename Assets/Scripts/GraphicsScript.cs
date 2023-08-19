using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsScript : MonoBehaviour
{
    public void SetLow()
    {
        QualitySettings.SetQualityLevel(0);
        PlayerPrefs.Save();
        Debug.Log("Low");

    }
    public void SetMid()
    {
        QualitySettings.SetQualityLevel(3);
        PlayerPrefs.Save();
        Debug.Log("Medium");

    }
    public void SetHigh()
    {
        QualitySettings.SetQualityLevel(7);
        PlayerPrefs.Save();
        Debug.Log("High");
    }
}
