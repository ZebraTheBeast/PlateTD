using System;
using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.Entities
{
    [Serializable]
    public class MusicAudioData
    {
        public MusicType Type;
        public AudioClip Clip;
    }
}