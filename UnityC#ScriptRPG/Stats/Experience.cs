
using UnityEngine;
using RPG.SceneManagement;
using System;
using UnityEngine.UI;
using MoreMountains.Tools;
using GameDevTV.Saving;
using TMPro;

namespace RPG.Stats

{
    public class Experience : MonoBehaviour, ISaveable
    {
        [SerializeField] float experiencePoint = 0;

        public event Action OnExperienceGained;

        private void Update()
        {
            if (Input.GetKey(KeyCode.L))
            {
                GainExperience(Time.deltaTime * 1000);
            }
            if (Input.GetKey(KeyCode.M))
            {
                GainExperience(Time.deltaTime * -1000);
            }
        }

        public void GainExperience(float experience)
        {
            experiencePoint += experience;

            if (OnExperienceGained != null)
            {
                OnExperienceGained();
            }
        }
        public float GetPoints()
        {
            return experiencePoint;
        }

        public object CaptureState()
        {
            return experiencePoint;
        }

        public void RestoreState(object state)
        {
            experiencePoint = (float)state;
        }



    }
}


