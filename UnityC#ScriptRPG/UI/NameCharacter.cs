using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.Stats
{
    public class NameCharacter : MonoBehaviour
    {
        public CharacterStatManager character;
        public TMP_InputField inputFielPro;
        

        public  void NameMyCharacter()
        {
            character.characterName = inputFielPro.text;

            if (character.characterName == "")
            {
                character.characterName = "Nameless?";
            }

            inputFielPro.text = character.characterName;
        }
    }
}