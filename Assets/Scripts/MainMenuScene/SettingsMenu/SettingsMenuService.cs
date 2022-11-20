using System;
using UnityEngine.Audio;

public class SettingsMenuService
{
    private SettingsMenuView _settingsWindow;
    private AudioMixer _audioMixer;
    private AudioSettingsService _audioSettingsService;

    public SettingsMenuService(SettingsMenuView settingsWindow, AudioMixer audioMixer)
    {
        _settingsWindow = settingsWindow;
        _audioMixer = audioMixer;

        InitWindow();
    }

    private Action _closeSettingsClickCallback;

    public void ShowWindow()
    {
        _settingsWindow.SetActive(true);
    }

    public void HideWindow()
    {
        _settingsWindow.SetActive(false);
    }

    public void SetCloseSettingsClickCallback(Action callback)
    {
        _closeSettingsClickCallback = callback;
    }

    private void MasterVolumeValueChangedHandler(float value)
    {
        _audioSettingsService.SetMasterVolumeValue(value);
    }

    private void MusicVolumeValueChangedHandler(float value)
    {
        _audioSettingsService.SetMusicVolumeValue(value);
    }

    private void EffectsVolumeValueChangedHandler(float value)
    {
        _audioSettingsService.SetEffectsVolumeValue(value);
    }

    private void ResetButtonClickHandler()
    {
        _audioSettingsService.ResetAll();
        _settingsWindow.SetValue(AudioSettingsService.DefaultValue,
            AudioSettingsService.DefaultValue,
            AudioSettingsService.DefaultValue);
    }

    private void BackButtonClickHandler()
    {
        _closeSettingsClickCallback?.Invoke();
    }

    private void Awake()
    {
        _audioSettingsService = new AudioSettingsService(_audioMixer);
        ResetButtonClickHandler();
    }

    private void InitWindow()
    {
        _settingsWindow.SetMasterVolumeValueChangedCallback(
            (value) => MasterVolumeValueChangedHandler(value)
        );
        _settingsWindow.SetMusicVolumeValueChangedCallback(
            (value) => MusicVolumeValueChangedHandler(value)
        );
        _settingsWindow.SetEffectsVolumeValueChangedCallback(
            (value) => EffectsVolumeValueChangedHandler(value)
        );
        _settingsWindow.SetResetButtonClickCallback(
            () => ResetButtonClickHandler()
        );

        _settingsWindow.SetBackButtonClickCallback(BackButtonClickHandler);
    }
}