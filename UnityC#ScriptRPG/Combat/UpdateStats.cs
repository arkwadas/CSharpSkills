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

        // Je¿eli poziom gracza wzrós³ od ostatniego sprawdzenia
        if (lastLevel != currentLevel)
        {
            lastLevel = currentLevel; // aktualizujemy ostatni poziom
            LevelUpEffect(); // wywo³ujemy efekt podniesienia poziomu
        }

        // Obliczanie doœwiadczenia wymaganego do osi¹gniêcia obecnego poziomu
        float XPForCurrentLevel = baseStats.progression.GetStat(Stat.ExperienceToLevelUp, baseStats.characterClass, currentLevel - 1);

         // Obliczanie doœwiadczenia zdobytego w bie¿¹cym poziomie
         float XPInCurrentLevel = currentXP - XPForCurrentLevel;

         // Obliczanie doœwiadczenia wymaganego do osi¹gniêcia nastêpnego poziomu
         float XPToLevelUP = baseStats.progression.GetStat(Stat.ExperienceToLevelUp, baseStats.characterClass, currentLevel);

         float XPPercent;

         if (XPForCurrentLevel < XPToLevelUP) // Gracz nie osi¹gn¹³ jeszcze maksymalnego poziomu
         {
             // Obliczanie procentowego wype³nienia paska doœwiadczenia
             XPPercent = XPInCurrentLevel / (XPToLevelUP - XPForCurrentLevel);
          
         }
         else // Gracz osi¹gn¹³ maksymalny poziom
         {
             XPPercent = 1; // Pasek doœwiadczenia powinien byæ w pe³ni wype³niony
         }

         // Aktualizacja paska doœwiadczenia
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
