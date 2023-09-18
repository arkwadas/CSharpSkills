using UnityEngine;
using TMPro;



namespace RPG.Combat
{
    public class DamageBars : MonoBehaviour
    {
        public GameObject updateDamageScriptObject; // Przeci�gnij obiekt zawieraj�cy skrypt "UpdateDamage" do tego pola w inspektorze
        public TextMeshProUGUI textMeshProComponent = null; // Przeci�gnij komponent TextMeshProUGUI, na kt�rym chcesz wy�wietli� wynik

        private UpdateDamagePlayer updateDamageScript = null;

        private void Start()
        {
            updateDamageScript = updateDamageScriptObject.GetComponent<UpdateDamagePlayer>();
            UpdateText();
        }

        private void Update()
        {
           
                UpdateText();
            
            
        }

        private void UpdateText()
        {
            
                float minDamage = updateDamageScript.GetInitialMinDamage();
                float maxDamage = updateDamageScript.GetInitialMaxDamage();

                // Zak�adaj�c, �e chcesz wy�wietla� obie warto�ci, oddzielone znakiem "/":
                textMeshProComponent.text = minDamage.ToString() + "/" + maxDamage.ToString();
            
        }
    }
}
