using UnityEngine;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;

    [SerializeField]
    private Slider sfxVolumeSlider;

    private PlayerData data;

    [SerializeField]
    private AudioSource SliderSound;

    [SerializeField]
    private AudioSource MusicSound;

    private void Start()
    {
        data = Data.GetPlayerData();
        // Load settings from PlayerData
        LoadSettings();

        // Initialize the sliders and toggles
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

        // Set initial values
        UpdateUI();
    }

    private void LoadSettings()
    {
        musicVolumeSlider.value = data.musicVolume;
        sfxVolumeSlider.value = data.sfxVolume;
    }

    private void SaveSettings()
    {
        data.musicVolume = musicVolumeSlider.value;
        data.sfxVolume = sfxVolumeSlider.value;
        Data.SavePlayerDataToFile();
    }

    private void UpdateUI()
    {
        // Update the UI elements based on the current values
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = data.musicVolume;
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.value = data.sfxVolume;
        }
    }

    public void SetMusicVolume(float value)
    {
        data.musicVolume = value;
        SaveSettings();
        AudioManager.Instance.UpdateMusicVolume(value);
        // Update the UI
        UpdateUI();
        MusicSound.Play();
    }

    public void SetSFXVolume(float value)
    {
        data.sfxVolume = value;
        SaveSettings();
        AudioManager.Instance.UpdateSFXVolume(value);
        // Update the UI
        UpdateUI();
        SliderSound.Play();
    }

    public void SetMuteMusic(bool isMuted)
    {
        data.muteMusic = isMuted;
        SaveSettings();
        AudioManager.Instance.MuteMusic(isMuted);
        // Update the UI
        UpdateUI();
    }

    public void SetMuteSFX(bool isMuted)
    {
        data.muteSfx = isMuted;
        SaveSettings();
        AudioManager.Instance.MuteSFX(isMuted);
        // Update the UI
        UpdateUI();
    }
}
