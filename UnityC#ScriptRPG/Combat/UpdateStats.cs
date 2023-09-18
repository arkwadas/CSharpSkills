using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RPG.Stats;
using MoreMountains.Tools;

public class UpdateStats : MonoBehaviour
{
    [SerializeField] private Image experienceBar;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] GameObject levelUpParticle = null;

     private Experience experience;
     private BaseStats baseStats;
    private int lastLevel = -1;

    private void Awake()
     {
         experience = GetComponent<Experience>();
         baseStats = GetComponent<BaseStats>();
        //lastLevel = baseStats.CalculateLevel();
    }

    private void Start()
    {
        
    }

    private void Update()
     {
         UpdateExperienceUI();
     }

     private void UpdateExperienceUI()
     {
         float currentXP = experience.GetPoints();
         int currentLevel = baseStats.CalculateLevel();

        // Je�eli poziom gracza wzr�s� od ostatniego sprawdzenia
        if (lastLevel != currentLevel)
        {
            lastLevel = currentLevel; // aktualizujemy ostatni poziom
            LevelUpEffect(); // wywo�ujemy efekt podniesienia poziomu
        }

        // Obliczanie do�wiadczenia wymaganego do osi�gni�cia obecnego poziomu
        float XPForCurrentLevel = baseStats.progression.GetStat(Stat.ExperienceToLevelUp, baseStats.characterClass, currentLevel - 1);

         // Obliczanie do�wiadczenia zdobytego w bie��cym poziomie
         float XPInCurrentLevel = currentXP - XPForCurrentLevel;

         // Obliczanie do�wiadczenia wymaganego do osi�gni�cia nast�pnego poziomu
         float XPToLevelUP = baseStats.progression.GetStat(Stat.ExperienceToLevelUp, baseStats.characterClass, currentLevel);

         float XPPercent;

         if (XPForCurrentLevel < XPToLevelUP) // Gracz nie osi�gn�� jeszcze maksymalnego poziomu
         {
             // Obliczanie procentowego wype�nienia paska do�wiadczenia
             XPPercent = XPInCurrentLevel / (XPToLevelUP - XPForCurrentLevel);
          
         }
         else // Gracz osi�gn�� maksymalny poziom
         {
             XPPercent = 1; // Pasek do�wiadczenia powinien by� w pe�ni wype�niony
         }

         // Aktualizacja paska do�wiadczenia
         experienceBar.fillAmount = XPPercent;

         // Aktualizacja tekstu poziomu
         levelText.text = "" + currentLevel;
     }
    private void LevelUpEffect()    // METODA WYTWORZENIA EFEKTU W  EMPTY OBIEKCIE + PARTICLE WEWNATRZ NEIGO
    {
        GameObject effectInstance = Instantiate(levelUpParticle, transform);
        Destroy(effectInstance, 5f); // Zniszczenie obiektu po 5 sekundach
    }
}
