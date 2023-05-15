using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text musicSliderText;
    [SerializeField] TMP_Text sfxSliderText;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";

    private void Start()
    {
        LoadVolume();
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetMusicVolume(float volume)
    {
        // Update the musicSliderText with the new value of the musicSlider
        float volumeValue = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", volumeValue);
        musicSliderText.text = Mathf.RoundToInt(volumeValue * 100).ToString();
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(volumeValue) * 20);
    }

    void SetSFXVolume(float volume)
    {
        // Update the sfxSliderText with the new value of the sfxSlider
        float volumeValue = sfxSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", volumeValue);
        sfxSliderText.text = Mathf.RoundToInt(volumeValue * 100).ToString();
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(volumeValue) * 20);
    }

    void LoadVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSlider.value = musicVolume;
            SetMusicVolume(musicVolume);
        }
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
            sfxSlider.value = sfxVolume;
            SetSFXVolume(sfxVolume);
        }
    }
}