using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuManagement : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resDropdown;

    void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; ++i)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();

    }

    /* Start Menu Code*/
    public int startScene = 1;

    public void PlayGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /* Settings Menu Code*/
    public AudioMixer audioMixer;

    public void SetVolume(float volumeLevel)
    {
        audioMixer.SetFloat("masterVolume", volumeLevel);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Setreolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
