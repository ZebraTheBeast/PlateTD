using System;
using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.Entities
{
    [Serializable]
    public class EffectsAudioData
    {
        public EffectsType Type;
        public AudioClip Clip;
    }
}