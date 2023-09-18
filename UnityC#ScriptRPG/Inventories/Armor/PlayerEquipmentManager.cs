using GameDevTV.Inventories;
using GameDevTV.Saving;
using GameDevTV.Utils;
using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using RPG.Customization;
using RPG.Invetories;
using RPG.Stats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    [SerializeField]Equipment equipment;

    [Header("Equipment Model Changer")]

    private int activeHelmetIndex = -1;
    private int activeTorseIndex = -1;
    private int activeHandsIndex = -1;
    private int activeShoesIndex = -1;
    private int activePelerynaIndex = -1;
    private int activeShieldIndex = -1;
    private int activeHelmetNoHairIndex = -1;
    private int activeMaskIndex = -1;
    private int activeShoulderIndex = -1;
    private int activeHipsTorseIndex = -1;
    private int activeElblowIndex = -1;
    private int activeKneeIndex = -1;
    // leg
    // Hand itp

    [Header("Default Naked Models")]
    public string nakedHelmetModel;
    public string nakedTorseModel;

    [SerializeField] TextMeshProUGUI CurrentHelmet = null;

//MAN EQUIPMENT
    //Head
    LazyValue<float> helmet;   
    [SerializeField] GameObject[] Helmets;
    LazyValue<float> helmetDodatki;
    [SerializeField] GameObject[] HelmetsDodatki;
    public List<GameObject> hideWhenHelmetActivate;

    LazyValue<float> noHair;
    [SerializeField] GameObject[] HelmetsNoHairAndCap;
    LazyValue<float> mask;
    [SerializeField] GameObject[] HelmetsMask;
    

    //Torse
    LazyValue<float> torse;
    [SerializeField] GameObject[] Torse;

    [SerializeField] GameObject[] RightArm;

    [SerializeField] GameObject[] LeftArm;

    [SerializeField] GameObject[] LowerRightArm;

    [SerializeField] GameObject[] LowerLeftArm;

    [SerializeField] GameObject[] Hips;


    //Hands
    LazyValue<float> hands;
    [SerializeField] GameObject[] RightHands;

    [SerializeField] GameObject[] LeftHands;

    //Shoes
    LazyValue<float> shoes;
    [SerializeField] GameObject[] RightShoes;

    [SerializeField] GameObject[] LeftShoes;

    //MAN EQUIPMENT
    //Head
    [SerializeField] GameObject[] fameleHelmets;

    //Torse
    [SerializeField] GameObject[] fameleTorse;

    [SerializeField] GameObject[] fameleRightArm;

    [SerializeField] GameObject[] fameleLeftArm;

    [SerializeField] GameObject[] fameleLowerRightArm;

    [SerializeField] GameObject[] fameleLowerLeftArm;

    [SerializeField] GameObject[] fameleHips;


    //Hands
    [SerializeField] GameObject[] fameleRightHands;

    [SerializeField] GameObject[] fameleLeftHands;


    //Shoes

    [SerializeField] GameObject[] fameleRightShoes;

    [SerializeField] GameObject[] fameleLeftShoes;

    //Peleryna
    LazyValue<float> pelerynas;
    [SerializeField] GameObject[] peleryna;

    //shield
    LazyValue<float> shields;
    [SerializeField] GameObject[] shield;

    //Dodatki do torse
    LazyValue<float> shoulder;
    [SerializeField] GameObject[] shoulderRightTorse;
    [SerializeField] GameObject[] shoulderLeftTorse;
    LazyValue<float> hipsTorseValue;
    [SerializeField] GameObject[] hipsTorse;
    LazyValue<float> elbowTorse;
    [SerializeField] GameObject[] elblowRightTorse;
    [SerializeField] GameObject[] elblowLeftTorse;
    LazyValue<float> knee;
    [SerializeField] GameObject[] kneeRightTorse;
    [SerializeField] GameObject[] kneeLeftTorse;

    LazyValue<float> defenseArmor;

    private void Awake()
    {
        torse = new LazyValue<float>(GetMaxTorse);
        helmet = new LazyValue<float>(GetMaxHelmet);
        //characterCustomization = GetComponentInParent<CharacterCustomization>();
        //helmetModelChanger = GetComponentInChildren<HelmetModelChanger>();
        pelerynas = new LazyValue<float>(GetMaxPeleryna);
        hands = new LazyValue<float>(GetMaxHands);
        shoes = new LazyValue<float>(GetMaxShoes);
        shields = new LazyValue<float>(GetMaxShield);
        noHair = new LazyValue<float>(GetMaxHelmetNoHair);
        helmetDodatki = new LazyValue<float>(GetMaxHelmetDodatki);
        mask = new LazyValue<float>(GetMaxMask);
        defenseArmor = new LazyValue<float>(GetMaxDefense);
        shoulder = new LazyValue<float>(GetMaxShoulder);
        hipsTorseValue = new LazyValue<float>(GetMaxHipsTorse);
        elbowTorse = new LazyValue<float>(GetMaxElblow);
        knee = new LazyValue<float>(GetMaxKnee);

    }

    private void Update()
    {
        int index = Mathf.RoundToInt(GetMaxHelmet()) - 1;
        if (index != activeHelmetIndex)
        {
            ActivateHelmet();
        }
        if (index > 1)
        {
            UnEquipAllHelmetModels();
        }
        else
        {
            EquipAllHelmetModels();
        }

        int indexTotse = Mathf.RoundToInt(GetMaxTorse()) - 1;
        if (indexTotse != activeTorseIndex)
        {
            ActivateTorse();
        }

        int indexpel = Mathf.RoundToInt(GetMaxPeleryna()) - 1;
        if (indexpel != activePelerynaIndex)
        {
            ActivatePeleryna();
        }
        int indexhand = Mathf.RoundToInt(GetMaxHands()) - 1;
        if (indexhand != activeHandsIndex)
        {
            ActivateHands();
        }
        int indexshoe = Mathf.RoundToInt(GetMaxShoes()) - 1;
        if (indexshoe != activeShoesIndex)
        {
            ActivateShoes();
        }
        int indexShie = Mathf.RoundToInt(GetMaxShield()) - 1;
        if (indexShie != activeShieldIndex)
        {
            ActivateShield();
        }
        int indexHelNoH = Mathf.RoundToInt(GetMaxHelmetNoHair()) - 1;
        if (indexHelNoH != activeHelmetNoHairIndex)
        {
            ActivateHelmetNoHair();
        }
        int indexMask = Mathf.RoundToInt(GetMaxMask()) - 1;
        if (indexMask != activeMaskIndex)
        {
            ActivateMask();
        }
        //int indexDefense = Mathf.RoundToInt(GetMaxDefense()) - 1;
        int indexSholder = Mathf.RoundToInt(GetMaxShoulder()) - 1;
        if (indexSholder != activeShoulderIndex)
        {
            ActivateShoulder();
        }
        int indexHipTor = Mathf.RoundToInt(GetMaxHipsTorse()) - 1;
        if (indexHipTor != activeHipsTorseIndex)
        {
            ActivateHipsTorse();
        }
        int indexEl = Mathf.RoundToInt(GetMaxElblow()) - 1;
        if (indexEl != activeElblowIndex)
        {
            ActivateElblow();
        }
        int indexknee = Mathf.RoundToInt(GetMaxKnee()) - 1;
        if (indexknee != activeKneeIndex)
        {
            ActivateKnee();
        }

    }

    private void Start()
    {
        // EquipAllEquipmentModelsOnStart();
        /*ActivateHelmet();
        ActivateTorse();
        
        ActivateHands();
        ActivateShoes();
        ActivatePeleryna();
        ActivateShield();
        ActivateHelmetNoHair();
        ActivateMask();
        ActivateShoulder();
        ActivateHipsTorse();
        ActivateElblow();
        ActivateKnee();*/
    }

    void SetActive(GameObject[] objects, int index)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == index)
            {
                objects[i].SetActive(true);
            }
            else if (objects[i].activeSelf)
            {
                objects[i].SetActive(false);
            }
        }
    }

    void ActivateHelmet()
    {
        int index = Mathf.RoundToInt(GetMaxHelmet()) - 1;
        if (index >= 0 && index < Torse.Length && index != activeHelmetIndex)
        {
            activeHelmetIndex = index;
            //man
            SetActive(Helmets, index);
            SetActive(HelmetsDodatki, index);
            //Famele
            SetActive(fameleHelmets, index);

        }
    }

    public void UnEquipAllHelmetModels()
    {
        foreach (GameObject hide in hideWhenHelmetActivate)
        {
            hide.SetActive(false);
        }
    }

    public void EquipAllHelmetModels()
    {
        foreach (GameObject hide in hideWhenHelmetActivate)
        {
            hide.SetActive(true);
        }
    }

    void ActivateTorse()
    {
        int index = Mathf.RoundToInt(GetMaxTorse()) - 1;

        if (index >= 0 && index < Torse.Length && index != activeTorseIndex)
        {
            activeTorseIndex = index;
            //man
            SetActive(Torse, index);
            SetActive(RightArm, index);
            SetActive(LeftArm, index);
            SetActive(Hips, index);
            SetActive(LowerRightArm, index);
            SetActive(LowerLeftArm, index);
            //famele
            SetActive(fameleTorse, index);
            SetActive(fameleRightArm, index);
            SetActive(fameleLeftArm, index);
            SetActive(fameleHips, index);
            SetActive(fameleLowerLeftArm, index);
            SetActive(fameleLowerRightArm, index);
        }
    }

    void ActivateHands()
    {
        int index = Mathf.RoundToInt(GetMaxHands()) - 1;

        if (index >= 0 && index < RightHands.Length && index != activeHandsIndex)
        {
            activeHandsIndex = index;
            //man
            SetActive(RightHands, index);
            SetActive(LeftHands, index);
            SetActive(fameleLeftHands, index);
            SetActive(fameleRightHands, index);
        }
    }

    void ActivateShoes()
    {
        int index = Mathf.RoundToInt(GetMaxShoes()) - 1;

        if (index >= 0 && index < LeftShoes.Length && index != activeShoesIndex)
        {
            activeShoesIndex = index;
            //man
            SetActive(LeftShoes, index);
            SetActive(RightShoes, index);
            SetActive(fameleRightShoes, index);
            SetActive(fameleLeftShoes, index);
        }
    }

    void ActivatePeleryna()
    {
        int index = Mathf.RoundToInt(GetMaxPeleryna()) - 1;

        if (index >= 0 && index < peleryna.Length && index != activePelerynaIndex)
        {
            activePelerynaIndex = index;
            //man
            SetActive(peleryna, index);
        }
    }

    void ActivateShield()
    {
        int index = Mathf.RoundToInt(GetMaxShield()) - 1;

        if (index >= 0 && index < shield.Length && index != activeShieldIndex)
        {
            activeShieldIndex = index;
            //man
            SetActive(shield, index);
        }
    }

    void ActivateHelmetNoHair()
    {
        int index = Mathf.RoundToInt(GetMaxHelmetNoHair()) - 1;

        if (index >= 0 && index < HelmetsNoHairAndCap.Length && index != activeHelmetNoHairIndex)
        {
            activeHelmetNoHairIndex = index;
            //man
            SetActive(HelmetsNoHairAndCap, index);
        }
    }


    void ActivateMask()
    {
        int index = Mathf.RoundToInt(GetMaxMask()) - 1;

        if (index >= 0 && index < HelmetsMask.Length && index != activeMaskIndex)
        {
            activeMaskIndex = index;
            //man
            SetActive(HelmetsMask, index);
        }
    }

    void ActivateShoulder()
    {
        int index = Mathf.RoundToInt(GetMaxShoulder()) - 1;

        if (index >= 0 && index < shoulderLeftTorse.Length && index != activeShoulderIndex)
        {
            activeShoulderIndex = index;
            //man
            SetActive(shoulderLeftTorse, index);
            SetActive(shoulderRightTorse, index);
        }
    }
    void ActivateHipsTorse()
    {
        int index = Mathf.RoundToInt(GetMaxHipsTorse()) - 1;

        if (index >= 0 && index < hipsTorse.Length && index != activeHipsTorseIndex)
        {
            activeHipsTorseIndex = index;
            //man
            SetActive(hipsTorse, index);
        }
    }
    void ActivateElblow()
    {
        int index = Mathf.RoundToInt(GetMaxElblow()) - 1;

        if (index >= 0 && index < elblowLeftTorse.Length && index != activeElblowIndex)
        {
            activeElblowIndex = index;
            //man
            SetActive(elblowLeftTorse, index);
            SetActive(elblowRightTorse, index);
        }
    }
    void ActivateKnee()
    {
        int index = Mathf.RoundToInt(GetMaxKnee()) - 1;

        if (index >= 0 && index < kneeLeftTorse.Length && index != activeKneeIndex)
        {
            activeKneeIndex = index;
            //man
            SetActive(kneeLeftTorse, index);
            SetActive(kneeRightTorse, index);
        }
    }

    public float GetMaxHelmet()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Helmet);
    }
    public float GetMaxTorse()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Torse);
    }
    public float GetMaxPeleryna()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Peleryna);
    }
    public float GetMaxHands()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Hands);
    }
    public float GetMaxShoes()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Shoes);
    }
    public float GetMaxShield()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Shield);
    }
    //Inne
    public float GetMaxHelmetNoHair()
    {
        return GetComponent<BaseStats>().GetStat(Stat.HelmetNoHair);
    }
    public float GetMaxHelmetDodatki()
    {
        return GetComponent<BaseStats>().GetStat(Stat.HelmetDodatek);
    }
    public float GetMaxMask()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Mask);
    }
    public float GetMaxDefense()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Defence);
    }
    public float GetMaxShoulder()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Shoulder);
    }
    public float GetMaxHipsTorse()
    {
        return GetComponent<BaseStats>().GetStat(Stat.HipsTorse);
    }
    public float GetMaxElblow()
    {
        return GetComponent<BaseStats>().GetStat(Stat.Elblow);
    }
    public float GetMaxKnee()
    {
        return GetComponent<BaseStats>().GetStat(Stat.knee);
    }



    public void OpenBlockingColider()
    {
        // kod dlaa 2 recznosci
    }



    /*public object CaptureState()
     {

         return helmet.value;
         return torse.value;
     }

     public void RestoreState(object state)
     {
         torse.value = (float)state;
         helmet.value = (float)state;
     }*/

}
