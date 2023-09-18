using UnityEngine.Audio;
using UnityEngine;

namespace RPG.Audio
{
    [System.Serializable]
    public class Sound
    {

        public string name;

        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;
        [Range(0f, 1f)]
        public float pitch;

        public bool loop;

        [HideInInspector] //Ukrywa w inspektorze
        public AudioSource source;

    }
}

