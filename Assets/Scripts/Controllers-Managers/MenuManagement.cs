using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class MenuManagement : MonoBehaviour
{
    public static MenuManagement instance;
    Resolution[] resolutions;
    public Dropdown resDropdown;
    public int levelInt;
    public int nextLevelInt;
    string currentMusic;
    /*private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }*/
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            levelInt = 0;
            FindObjectOfType<AudioManager>().Play("MainMenuTheme");
            currentMusic = "MainMenuTheme";
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
    }
    private void Update()
    {
        levelInt = SceneManager.GetActiveScene().buildIndex;
        //Change to a save data value
        nextLevelInt = SceneManager.GetActiveScene().buildIndex + 1;
    }
    /* Start Menu Code*/
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Stop(currentMusic);
        SceneManager.LoadScene(nextLevelInt);
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGameToDesktop()
    {
        Application.Quit();
    }

    public void PlayNextLevel()
    {
        SceneManager.LoadScene(nextLevelInt);
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
