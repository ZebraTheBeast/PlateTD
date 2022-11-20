using UnityEngine;
using UnityEngine.Audio;

public class AudioSettingsService
{
    public const float DefaultValue = 100f;

    private const string MasterVolume = "MasterVolumeValue";
    private const string MusicVolume = "MusicVolumeValue";
    private const string EffectsVolume = "EffectsVolumeValue";

    private const float DefaultDBValue = 0f;
    private const float MinDBValue = -80f;
    private const float MaxDBValue = 0f;

    private AudioMixer _audioMixer;

    public AudioSettingsService(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public void SetMasterVolumeValue(float value)
    {
        var _dbValue = TransferToDB(value);
        _audioMixer.SetFloat(MasterVolume, _dbValue);
    }

    public void SetMusicVolumeValue(float value)
    {
        var _dbValue = TransferToDB(value);
        _audioMixer.SetFloat(MusicVolume, _dbValue);
    }

    public void SetEffectsVolumeValue(float value)
    {
        var _dbValue = TransferToDB(value);
        _audioMixer.SetFloat(EffectsVolume, _dbValue);
    }

    public void ResetAll()
    {
        _audioMixer.SetFloat(MusicVolume, DefaultDBValue);
        _audioMixer.SetFloat(EffectsVolume, DefaultDBValue);
        _audioMixer.SetFloat(MasterVolume, DefaultDBValue);
    }

    private float TransferToDB(float value)
    {
        return Mathf.Lerp(MinDBValue, MaxDBValue, value / DefaultValue);
    }
}