using System.Collections.Generic;
using System.Linq;
using PlateTD.Entities;
using PlateTD.Entities.Enums;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectsSource;

    [SerializeField] private List<MusicAudioData> _musicAudioData = new List<MusicAudioData>();
    [SerializeField] private List<EffectsAudioData> _effectsAudioData = new List<EffectsAudioData>();

    public static AudioManager Instance;

    public void PlayEffects(EffectsType type)
    {
        var clip = _effectsAudioData.FirstOrDefault(i => i.Type == type).Clip;
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayMusic(MusicType type)
    {
        var clip = _musicAudioData.FirstOrDefault(i => i.Type == type).Clip;
        _musicSource.clip = clip;
        _musicSource.Play();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
