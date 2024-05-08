using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsMenuHandler : MonoBehaviour
{
    public GameObject optionsMenu;
    public AudioMixer audioMixer;
    public TMP_Dropdown resDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider; 
    public Canvas canvas;
    Resolution[] resolutions;

    void Start()
    {
      volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
      fullscreenToggle.isOn = Screen.fullScreen;
      GetResolution();

    }

    public void ToggleOptionsMenu()
    {
        // Toggle the visibility of the options menu
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void SetMasterVolume(float volume)
    {    
        audioMixer.SetFloat("MasterVolume",ConvertToDec(volumeSlider.value));
        PlayerPrefs.SetFloat("MasterVolume",volumeSlider.value);
    }

    float ConvertToDec(float sliderValue){
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

     void GetResolution()
    {
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        for(int i = 0; i<resolutions.Length; i++){
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height,fullscreenToggle.isOn);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenOptions(){
        canvas.enabled = true;
    }
    public void CloseOptions(){
        canvas.enabled = false;
    }
}
