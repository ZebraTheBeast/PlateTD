using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectsVolumeSlider;

    private Action _resetButtonClickCallback;
    private Action<float> _masterVolumeValueChangedCallback;
    private Action<float> _musicVolumeValueChangedCallback;
    private Action<float> _effectsVolumeValueChangedCallback;

    private Action _backButtonClickCallback;

    public void SetValue(float masterVolumeValue, float musicVolumeValue, float effectsVolumeValue)
    {
        _masterVolumeSlider.value = masterVolumeValue;
        _musicVolumeSlider.value = musicVolumeValue;
        _effectsVolumeSlider.value = effectsVolumeValue;
    }

    public void SetActive(bool state)
    {
        this.gameObject.SetActive(state);
    }

    public void SetResetButtonClickCallback(Action callback)
    {
        _resetButtonClickCallback = callback;
    }

    public void SetBackButtonClickCallback(Action callback)
    {
        _backButtonClickCallback = callback;
    }

    public void SetMasterVolumeValueChangedCallback(Action<float> callback)
    {
        _masterVolumeValueChangedCallback = callback;
    }

    public void SetMusicVolumeValueChangedCallback(Action<float> callback)
    {
        _musicVolumeValueChangedCallback = callback;
    }

    public void SetEffectsVolumeValueChangedCallback(Action<float> callback)
    {
        _effectsVolumeValueChangedCallback = callback;
    }

    private void BackButtonClickHandler()
    {
        _backButtonClickCallback?.Invoke();
    }

    private void ResetButtonClickHandler()
    {
        _resetButtonClickCallback?.Invoke();
    }

    private void MasterVolumeValueChangedHandler(float value)
    {
        _masterVolumeValueChangedCallback?.Invoke(value);
    }

    private void MusicVolumeValueChangedHandler(float value)
    {
        _musicVolumeValueChangedCallback?.Invoke(value);
    }

    private void EffectsVolumeValueChangedHandler(float value)
    {
        _effectsVolumeValueChangedCallback?.Invoke(value);
    }

    private void Start()
    {
        _backButton.onClick.AddListener(BackButtonClickHandler);
        _resetButton.onClick.AddListener(ResetButtonClickHandler);
        _masterVolumeSlider.onValueChanged.AddListener(MasterVolumeValueChangedHandler);
        _musicVolumeSlider.onValueChanged.AddListener(MusicVolumeValueChangedHandler);
        _effectsVolumeSlider.onValueChanged.AddListener(EffectsVolumeValueChangedHandler);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveListener(BackButtonClickHandler);
        _resetButton.onClick.RemoveListener(ResetButtonClickHandler);
        _masterVolumeSlider.onValueChanged.RemoveListener(MasterVolumeValueChangedHandler);
        _musicVolumeSlider.onValueChanged.RemoveListener(MusicVolumeValueChangedHandler);
        _effectsVolumeSlider.onValueChanged.RemoveListener(EffectsVolumeValueChangedHandler);
    }
}
