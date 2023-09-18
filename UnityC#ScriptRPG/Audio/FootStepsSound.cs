using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Audio
{
    public class FootStepsSound : MonoBehaviour
    {
        [SerializeField] string sound;
        public void StepEvent()
        {
            FindObjectOfType<AudioManager>().Play(sound);
        }

    }
}