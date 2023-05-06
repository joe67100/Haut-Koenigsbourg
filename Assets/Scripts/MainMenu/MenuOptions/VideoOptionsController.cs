using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class VideoOptionsController : MonoBehaviour
{
    [SerializeField] private LoadPrefs loadPref;

    private const string QUALITY_INDEX = "qualityIndex";
    private const string RESOLUTION_INDEX = "resolutionIndex";
    private const string FULL_SCREEN_TOGGLE = "fullScreenToggle";
    private const string FRAMERATE_INDEX = "framerateIndex";
    private const string BRIGHTNESS = "brightness";

    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private TMP_Dropdown graphicsDropdown;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown framerateDropdown;
    [SerializeField] private Button resetSettings;

    [SerializeField] private Slider brightnessSlider;

    public void SetBrightness(float value)
    {
        RenderSettings.ambientIntensity = value;
        PlayerPrefs.SetFloat(BRIGHTNESS, value);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt(FULL_SCREEN_TOGGLE, isFullScreen ? 1 : 0);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt(QUALITY_INDEX, graphicsDropdown.value);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = loadPref.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_INDEX, resolutionIndex);
    }

    public void SetFramerate(int framerateIndex)
    {
        switch (framerateIndex)
        {
            case 0:
                Application.targetFrameRate = 200;
                break;
            case 1:
                Application.targetFrameRate = 144;
                break;
            case 2:
                Application.targetFrameRate = 60;
                break;
            default:
                break;
        }
        PlayerPrefs.SetInt(FRAMERATE_INDEX, framerateIndex);
    }
    
    public void ResetAllSettings()
    {
        PlayerPrefs.DeleteKey(QUALITY_INDEX);
        PlayerPrefs.DeleteKey(RESOLUTION_INDEX);
        PlayerPrefs.DeleteKey(FULL_SCREEN_TOGGLE);
        PlayerPrefs.DeleteKey(FRAMERATE_INDEX);
        PlayerPrefs.DeleteKey(BRIGHTNESS);

        graphicsDropdown.value = 0;
        framerateDropdown.value = 0;
        fullScreenToggle.isOn = true;
        brightnessSlider.value = 1.8f;
    }
}
