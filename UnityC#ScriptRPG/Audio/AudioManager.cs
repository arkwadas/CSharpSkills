using UnityEngine.Audio;
using UnityEngine;
using System;

namespace RPG.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager instance;
        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>(); // mo¿emy to zrobiæ dla rodzica albo dziecka!
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }

        }

        // Wywo³anie muzyki
        private void Start()
        {
            Play("Theme"); //theme bo np tak nazwaliœmy nasza muzyke w tle dla rozgrywki w audio managerze
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if(s == null)
            {
                Debug.LogWarning("Sound: " + name + "nie znaleziono, popraw nazwe w kodzie!");
                return;
            }
            s.source.Play();
        }
    }

}

