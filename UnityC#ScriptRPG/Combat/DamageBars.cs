using UnityEngine;
using TMPro;



namespace RPG.Combat
{
    public class DamageBars : MonoBehaviour
    {
        public GameObject updateDamageScriptObject; // Przeci¹gnij obiekt zawieraj¹cy skrypt "UpdateDamage" do tego pola w inspektorze
        public TextMeshProUGUI textMeshProComponent = null; // Przeci¹gnij komponent TextMeshProUGUI, na którym chcesz wyœwietliæ wynik

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

                // Zak³adaj¹c, ¿e chcesz wyœwietlaæ obie wartoœci, oddzielone znakiem "/":
                textMeshProComponent.text = minDamage.ToString() + "/" + maxDamage.ToString();
            
        }
    }
}
