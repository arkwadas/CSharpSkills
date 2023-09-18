using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.SceneManagement;
using GameDevTV.Saving;

public enum Gender { Male, Female }
public enum Race { Human, Elf }
public enum SkinColor { White, Brown, Black, Elf }
public enum Elements { Yes, No }
public enum HeadCovering { HeadCoverings_Base_Hair, HeadCoverings_No_FacialHair, HeadCoverings_No_Hair }
public enum FacialHair { Yes, No }

public class TestKolor : MonoBehaviour, ISaveable
{
    [Header("Demo Settings")]
    public bool repeatOnPlay = false;
    public float shuffleSpeed = 0.7f;

    [Header("Material")]
    public Material mat;

    [Header("Gear Colors")]
    public Color[] primary = { new Color(0.2862745f, 0.4f, 0.4941177f), new Color(0.4392157f, 0.1960784f, 0.172549f), new Color(0.3529412f, 0.3803922f, 0.2705882f), new Color(0.682353f, 0.4392157f, 0.2196079f), new Color(0.4313726f, 0.2313726f, 0.2705882f), new Color(0.5921569f, 0.4941177f, 0.2588235f), new Color(0.482353f, 0.4156863f, 0.3529412f), new Color(0.2352941f, 0.2352941f, 0.2352941f), new Color(0.2313726f, 0.4313726f, 0.4156863f) };
    public Color[] secondary = { new Color(0.7019608f, 0.6235294f, 0.4666667f), new Color(0.7372549f, 0.7372549f, 0.7372549f), new Color(0.1647059f, 0.1647059f, 0.1647059f), new Color(0.2392157f, 0.2509804f, 0.1882353f) };

    [Header("Metal Colors")]
    public Color[] metalPrimary = { new Color(0.6705883f, 0.6705883f, 0.6705883f), new Color(0.5568628f, 0.5960785f, 0.6392157f), new Color(0.5568628f, 0.6235294f, 0.6f), new Color(0.6313726f, 0.6196079f, 0.5568628f), new Color(0.6980392f, 0.6509804f, 0.6196079f) };
    public Color[] metalSecondary = { new Color(0.3921569f, 0.4039216f, 0.4117647f), new Color(0.4784314f, 0.5176471f, 0.5450981f), new Color(0.3764706f, 0.3607843f, 0.3372549f), new Color(0.3254902f, 0.3764706f, 0.3372549f), new Color(0.4f, 0.4039216f, 0.3568628f) };

    [Header("Leather Colors")]
    public Color[] leatherPrimary;
    public Color[] leatherSecondary;

    [Header("Skin Colors")]
    public Color[] allSkin = { new Color(1f, 0.8000001f, 0.682353f), new Color(0.8196079f, 0.6352941f, 0.4588236f), new Color(0.5647059f, 0.4078432f, 0.3137255f), new Color(0.9607844f, 0.7843138f, 0.7294118f) };
    public Color[] alllSkin = { new Color(1f, 0.8000001f, 0.682353f), new Color(0.8196079f, 0.6352941f, 0.4588236f), new Color(0.5647059f, 0.4078432f, 0.3137255f), new Color(0.9607844f, 0.7843138f, 0.7294118f) };
    public Color[] whiteSkin = { new Color(1f, 0.8000001f, 0.682353f) };
    public Color[] brownSkin = { new Color(0.8196079f, 0.6352941f, 0.4588236f) };
    public Color[] blackSkin = { new Color(0.5647059f, 0.4078432f, 0.3137255f) };
    public Color[] elfSkin = { new Color(0.9607844f, 0.7843138f, 0.7294118f) };

    [Header("Hair Colors")]
    public Color[] alllHair = { new Color(0.3098039f, 0.254902f, 0.1764706f), new Color(0.2196079f, 0.2196079f, 0.2196079f), new Color(0.8313726f, 0.6235294f, 0.3607843f), new Color(0.8901961f, 0.7803922f, 0.5490196f), new Color(0.8000001f, 0.8196079f, 0.8078432f), new Color(0.6862745f, 0.4f, 0.2352941f), new Color(0.5450981f, 0.427451f, 0.2156863f), new Color(0.8470589f, 0.4666667f, 0.2470588f),
    new Color(0.3098039f, 0.254902f, 0.1764706f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.3843138f, 0.2352941f, 0.0509804f), new Color(0.6196079f, 0.6196079f, 0.6196079f), new Color(0.6196079f, 0.6196079f, 0.6196079f),
    new Color(0.2431373f, 0.2039216f, 0.145098f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.1764706f, 0.1686275f, 0.1686275f),
    new Color(0.9764706f, 0.9686275f, 0.9568628f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.8980393f, 0.7764707f, 0.6196079f)
    };
    public Color[] alllStubbble = {new Color(0.8039216f, 0.7019608f, 0.6313726f),
    new Color(0.6588235f, 0.572549f, 0.4627451f),
    new Color(0.3882353f, 0.2901961f, 0.2470588f),
    new Color(0.8627452f, 0.7294118f, 0.6862745f),
    new Color(0.45f, 0.45f, 0.45f)
    };

    public Color[] whiteHair = { new Color(0.3098039f, 0.254902f, 0.1764706f), new Color(0.2196079f, 0.2196079f, 0.2196079f), new Color(0.8313726f, 0.6235294f, 0.3607843f), new Color(0.8901961f, 0.7803922f, 0.5490196f), new Color(0.8000001f, 0.8196079f, 0.8078432f), new Color(0.6862745f, 0.4f, 0.2352941f), new Color(0.5450981f, 0.427451f, 0.2156863f), new Color(0.8470589f, 0.4666667f, 0.2470588f) };
    public Color whiteStubble = new Color(0.8039216f, 0.7019608f, 0.6313726f);
    public Color[] brownHair = { new Color(0.3098039f, 0.254902f, 0.1764706f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.3843138f, 0.2352941f, 0.0509804f), new Color(0.6196079f, 0.6196079f, 0.6196079f), new Color(0.6196079f, 0.6196079f, 0.6196079f) };
    public Color brownStubble = new Color(0.6588235f, 0.572549f, 0.4627451f);
    public Color[] blackHair = { new Color(0.2431373f, 0.2039216f, 0.145098f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.1764706f, 0.1686275f, 0.1686275f) };
    public Color blackStubble = new Color(0.3882353f, 0.2901961f, 0.2470588f);
    public Color[] elfHair = { new Color(0.9764706f, 0.9686275f, 0.9568628f), new Color(0.1764706f, 0.1686275f, 0.1686275f), new Color(0.8980393f, 0.7764707f, 0.6196079f) };
    public Color elfStubble = new Color(0.8627452f, 0.7294118f, 0.6862745f);

    [Header("Scar Colors")]
    public Color[] alllScar = { new Color(0.9294118f, 0.6862745f, 0.5921569f),
    new Color(0.6980392f, 0.5450981f, 0.4f),
    new Color(0.4235294f, 0.3176471f, 0.282353f),
    new Color(0.8745099f, 0.6588235f, 0.6313726f)
    };
    public Color whiteScar = new Color(0.9294118f, 0.6862745f, 0.5921569f);
    public Color brownScar = new Color(0.6980392f, 0.5450981f, 0.4f);
    public Color blackScar = new Color(0.4235294f, 0.3176471f, 0.282353f);
    public Color elfScar = new Color(0.8745099f, 0.6588235f, 0.6313726f);

    [Header("Body Art Colors")]
    public Color[] bodyArt = { new Color(0.0509804f, 0.6745098f, 0.9843138f), new Color(0.7215686f, 0.2666667f, 0.2666667f), new Color(0.3058824f, 0.7215686f, 0.6862745f), new Color(0.9254903f, 0.882353f, 0.8509805f), new Color(0.3098039f, 0.7058824f, 0.3137255f), new Color(0.5294118f, 0.3098039f, 0.6470588f), new Color(0.8666667f, 0.7764707f, 0.254902f), new Color(0.2392157f, 0.4588236f, 0.8156863f) };

    [Header("Eye Colors")]
    public Color[] eyesColor = { new Color(0f, 0f, 0f), new Color(0.2862745f, 0.4f, 0.4941177f), new Color(0.4392157f, 0.1960784f, 0.172549f), new Color(0.3529412f, 0.3803922f, 0.2705882f), new Color(0.682353f, 0.4392157f, 0.2196079f), new Color(0.4313726f, 0.2313726f, 0.2705882f), new Color(0.5921569f, 0.4941177f, 0.2588235f), new Color(0.482353f, 0.4156863f, 0.3529412f), new Color(0.2352941f, 0.2352941f, 0.2352941f), new Color(0.2313726f, 0.4313726f, 0.4156863f),
    new Color(0.7019608f, 0.6235294f, 0.4666667f), new Color(0.7372549f, 0.7372549f, 0.7372549f), new Color(0.1647059f, 0.1647059f, 0.1647059f), new Color(0.2392157f, 0.2509804f, 0.1882353f)};


    // list of enabed objects on character
    [HideInInspector]
    public List<GameObject> enabledObjects = new List<GameObject>();

    // character object lists
    // male list
    [HideInInspector]
    public CharacterObjectGroups male;

    // female list
    [HideInInspector]
    public CharacterObjectGroups female;

    // universal list
    [HideInInspector]
    public CharacterObjectListsAllGender allGender;

    private int idColor;
    private int idSkinColor;
    private int idTatoColor;
    private int idScarColor;
    private int idEyeColor;
    public Material mate;
    //we grab the material from the skin mesh renderer, and change the color propestues of the mateial
    public List<SkinnedMeshRenderer> hairList = new List<SkinnedMeshRenderer>();
    public List<SkinnedMeshRenderer> scarList = new List<SkinnedMeshRenderer>();
    public List<SkinnedMeshRenderer> skinList = new List<SkinnedMeshRenderer>();
    public List<SkinnedMeshRenderer> tatoList = new List<SkinnedMeshRenderer>();
    public List<SkinnedMeshRenderer> eyeList = new List<SkinnedMeshRenderer>();

    private Color currentHairColor;

    private void Update()
    {
        ChangeSkinColor();
        ChangeScarColor();
        ChangeHairColor();
        ChangeTatoColor();
        ChangeEyeColor();
    }
    public void ChangeHairColor()
    {

        //currentHairColor = new Color();
        for (int i = 0; i < hairList.Count; i++)
        {
            //currentHairColor.a = i;
            hairList[i].material.SetColor("_Color_Hair", alllHair[idColor]);

        }
    }
    public void ChangeEyeColor()
    {

        //currentHairColor = new Color();
        for (int i = 0; i < eyeList.Count; i++)
        {
            //currentHairColor.a = i;
            eyeList[i].material.SetColor("_Color_Eyes", eyesColor[idEyeColor]);

        }
    }

    public void ChangeScarColor()
    {

        //currentHairColor = new Color();
        for (int i = 0; i < scarList.Count; i++)
        {
            //currentHairColor.a = i;
            scarList[i].material.SetColor("_Color_Scar", alllScar[idScarColor]);

        }
    }

    public void ChangeSkinColor()
    {

        //currentHairColor = new Color();
        for (int i = 0; i < skinList.Count; i++)
        {
            //currentHairColor.a = i;
            skinList[i].material.SetColor("_Color_Skin", alllSkin[idSkinColor]);
            skinList[i].material.SetColor("_Color_Stubble", alllStubbble[idSkinColor]);

        }
    }



    public void ChangeTatoColor()
    {

        //currentHairColor = new Color();
        for (int i = 0; i < tatoList.Count; i++)
        {
            //currentHairColor.a = i;
            tatoList[i].material.SetColor("_Color_BodyArt", bodyArt[idTatoColor]);

        }
    }

    public void NextHairSwitchKolor()
    {
        if (idColor == alllHair.Length - 1)
        { idColor = 0; }
        else
        { idColor++; }
    }
    public void NextEyeSwitchKolor()
    {
        if (idEyeColor == eyesColor.Length - 1)
        { idEyeColor = 0; }
        else
        { idEyeColor++; }
    }
    public void NextStubbleSwitchKolor()
    {
        if (idSkinColor == alllStubbble.Length - 1)
        { idSkinColor = 0; }
        else
        { idSkinColor++; }
    }
    public void NextSkinSwitchKolor()
    {
        if (idSkinColor == alllSkin.Length - 1)
        { idSkinColor = 0; }
        else
        { idSkinColor++; }
    }
    public void NextTatooSwitchKolor()
    {
        if (idTatoColor == bodyArt.Length - 1)
        { idTatoColor = 0; }
        else
        { idTatoColor++; }
    }
    public void NextScarSwitchKolor()
    {
        if (idScarColor == alllScar.Length - 1)
        { idScarColor = 0; }
        else
        { idScarColor++; }
    }
    public void BackHairSwitchKolor()
    {
        if (idColor == 0)
        {
            idColor = alllHair.Length - 1;
        }
        else
        {
            idColor--;
        }
    }
    public void BackEyeSwitchKolor()
    {
        if (idEyeColor == 0)
        {
            idEyeColor = eyesColor.Length - 1;
        }
        else
        {
            idEyeColor--;
        }
    }
    public void BackStubbleSwitchKolor()
    {
        if (idSkinColor == 0)
        {
            idSkinColor = alllStubbble.Length - 1;
        }
        else
        {
            idSkinColor--;
        }
    }
    public void BackSkinSwitchKolor()
    {
        if (idSkinColor == 0)
        {
            idSkinColor = alllSkin.Length - 1;
        }
        else
        {
            idSkinColor--;
        }
    }
    public void BackTatoSwitchKolor()
    {
        if (idTatoColor == 0)
        {
            idTatoColor = bodyArt.Length - 1;
        }
        else
        {
            idTatoColor--;
        }
    }
    public void BackScarSwitchKolor()
    {
        if (idScarColor == 0)
        {
            idScarColor = alllScar.Length - 1;
        }
        else
        {
            idScarColor--;
        }
    }

    //#region Save And Load System
    public object CaptureState()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        // data["P³eæ"] = 

        return data;
    }

    public void RestoreState(object state)
    {
        Debug.Log("RestoreState");

        Dictionary<string, object> data = (Dictionary<string, object>)state;
        //int gd = (int)data
    }

    /*
     private int idColor;
    private int idSkinColor;
    private int idTatoColor;
    private int idScarColor;
    private int idEyeColor;
     */



    /*private void Start()
    {
        // rebuild all lists
        BuildLists();

        // disable any enabled objects before clear
        if (enabledObjects.Count != 0)
        {
            foreach (GameObject g in enabledObjects)
            {
                g.SetActive(false);
            }
        }

        // clear enabled objects list
        enabledObjects.Clear();

        // set default male character
        ActivateItem(male.headAllElements[0]);
        ActivateItem(male.eyebrow[0]);
        ActivateItem(male.facialHair[0]);
        ActivateItem(male.torso[0]);
        ActivateItem(male.arm_Upper_Right[0]);
        ActivateItem(male.arm_Upper_Left[0]);
        ActivateItem(male.arm_Lower_Right[0]);
        ActivateItem(male.arm_Lower_Left[0]);
        ActivateItem(male.hand_Right[0]);
        ActivateItem(male.hand_Left[0]);
        ActivateItem(male.hips[0]);
        ActivateItem(male.leg_Right[0]);
        ActivateItem(male.leg_Left[0]);

       

        // if repeat on play is checked in the inspector, repeat the randomize method based on the shuffle speed, also defined in the inspector
        if (repeatOnPlay)
            InvokeRepeating("Randomize", shuffleSpeed, shuffleSpeed);
    }
    */








    // classe for keeping the lists organized, allows for simple switching from male/female objects
    [System.Serializable]
    public class CharacterObjectGroups
    {
        public List<GameObject> headAllElements;
        public List<GameObject> headNoElements;
        public List<GameObject> eyebrow;
        public List<GameObject> facialHair;
        public List<GameObject> torso;
        public List<GameObject> arm_Upper_Right;
        public List<GameObject> arm_Upper_Left;
        public List<GameObject> arm_Lower_Right;
        public List<GameObject> arm_Lower_Left;
        public List<GameObject> hand_Right;
        public List<GameObject> hand_Left;
        public List<GameObject> hips;
        public List<GameObject> leg_Right;
        public List<GameObject> leg_Left;
    }

    // classe for keeping the lists organized, allows for organization of the all gender items
    [System.Serializable]
    public class CharacterObjectListsAllGender
    {
        public List<GameObject> headCoverings_Base_Hair;
        public List<GameObject> headCoverings_No_FacialHair;
        public List<GameObject> headCoverings_No_Hair;
        public List<GameObject> all_Hair;
        public List<GameObject> all_Head_Attachment;
        public List<GameObject> chest_Attachment;
        public List<GameObject> back_Attachment;
        public List<GameObject> shoulder_Attachment_Right;
        public List<GameObject> shoulder_Attachment_Left;
        public List<GameObject> elbow_Attachment_Right;
        public List<GameObject> elbow_Attachment_Left;
        public List<GameObject> hips_Attachment;
        public List<GameObject> knee_Attachement_Right;
        public List<GameObject> knee_Attachement_Left;
        public List<GameObject> all_12_Extra;
        public List<GameObject> elf_Ear;
    }
}
