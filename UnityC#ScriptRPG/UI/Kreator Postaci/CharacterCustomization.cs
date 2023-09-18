
using System.Collections.Generic;
using UnityEngine;
using RPG.SceneManagement;
using GameDevTV.Saving;
using RPG.Invetories;
using System.Collections;

namespace RPG.Customization
{
    public class CharacterCustomization : MonoBehaviour, ISaveable
    {



        // tablica przechowuj¹ca modele 3D w³osów
        public GameObject[] hairModels;

       
        //private int currentHair;



        // tablica przechowuj¹ca modele 3D twarzy
        public GameObject[] faceManModels;

        public GameObject[] faceFameleModels;

        // tablica przechowuj¹ca modele 3D brod
        public GameObject[] beardModels;

        // tablica przechowuj¹ca modele 3D brwi
        public GameObject[] browModels;
        public GameObject[] browFameleModels;

        public GameObject[] earModels;

        // referencja do aktualnie u¿ywanego modelu 3D w³osów
        private GameObject currentHairModel;

        // referencja do aktualnie u¿ywanego modelu 3D twarzy
        private GameObject currentFaceManModel;
        private GameObject currentFaceFameleModel;

        // referencja do aktualnie u¿ywanego modelu 3D brody
        private GameObject currentBeardModel;

        // referencja do aktualnie u¿ywanego modelu 3D brwi
        private GameObject currentBrowModel;
        private GameObject currentBrowFameleModel;

        // referencja do aktualnie u¿ywanego modelu 3D uszu
        private GameObject currentEarModel;



        //MODELE
        private int idHair;
        private int idFaceMan;
        private int idFaceFamele;
        private int idBeard;
        private int idBrowMan;
        private int idBrowFamele;
        private int idEar;

        [Header("CurrentEquipment")]
        public HelmetEquipment currentHelmetEquipment;
        //public TorseEquipment currentTorseEquipment;




        [Header("Armor")]
        private int idManHelmet;
        public void SetManHelmetId(int newHelmetId)
        {
            idManHelmet = newHelmetId;
        }
        private GameObject currentManHelmet;
        public GameObject[] manHelmet;
        public GameObject nullManHelmet;

        private int idFameleHelmet;
        private GameObject currentFameleHelmet;
        public GameObject[] fameleHelmet;

        private int idManArmorPancerz;
        private GameObject currentManArmorPancerz;
        public GameObject[] manArmorPancerz;
        public GameObject nullManArmorPancerz;
        public void SetManArmorPancerzId(int newId)
        {
            idManArmorPancerz = newId;
        }

       

        private void Start()
        {
            /*SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            wrapper.Load();*/

            // Za³aduj poni¿sze modele na pocz¹tku sceny
            Hair();
            FaceMan();
            FaceFamele();
            Beard();
            BrowMan();
            BrowFamele();
            Ear();



            //Kolory 
            ChangeSkinColor();
            ChangeScarColor();
            ChangeHairColor();
            ChangeTatoColor();
            ChangeEyeColor();
        }
        private void Update()
        {
            ChangeSkinColor();
            ChangeScarColor();
            ChangeHairColor();
            ChangeTatoColor();
            ChangeEyeColor();
            if (shouldCalculateSkinColor)
            {
                StartCoroutine(CalculateSkinColor());
                shouldCalculateSkinColor = false;
            }
            if (shouldCalculateScarColor)
            {
                StartCoroutine(CalculateScarColor());
                shouldCalculateScarColor = false;
            }
            if (shouldCalculateHairColor)
            {
                StartCoroutine(CalculateHairColor());
                shouldCalculateHairColor = false;
            }
            if (shouldCalculateTatoColor)
            {
                StartCoroutine(CalculateTatoColor());
                shouldCalculateTatoColor = false;
            }
            if (shouldCalculateEyeColor)
            {
                StartCoroutine(CalculateEyeColor());
                shouldCalculateEyeColor = false;
            }
            if (shouldCalculateStubbleColor)
            {
                StartCoroutine(CalculateStubbleColor());
                shouldCalculateStubbleColor = false;
            }


        }

        private IEnumerator CalculateSkinColor()
        {
            ChangeSkinColor();
            yield return null;
        }
        public void SomeFunctionThatTriggersSkinColorCalculation()
        {
            shouldCalculateSkinColor = true;
        }

        private IEnumerator CalculateScarColor()
        {
            ChangeScarColor();
            yield return null;
        }

        public void SomeFunctionThatTriggersScarColorCalculation()
        {
            shouldCalculateScarColor = true;
        }
        private IEnumerator CalculateHairColor()
        {
            ChangeHairColor();
            yield return null;
        }

        public void SomeFunctionThatTriggersHairColorCalculation()
        {
            shouldCalculateHairColor = true;
        }
        private IEnumerator CalculateTatoColor()
        {
            ChangeTatoColor();
            yield return null;
        }

        public void SomeFunctionThatTriggersTatoColorCalculation()
        {
            shouldCalculateTatoColor = true;
        }
        private IEnumerator CalculateEyeColor()
        {
            ChangeEyeColor();
            yield return null;
        }

        public void SomeFunctionThatTriggersEyeColorCalculation()
        {
            shouldCalculateEyeColor = true;
        }
        private IEnumerator CalculateStubbleColor()
        {
            ChangeStubbleColor();
            yield return null;
        }

        public void SomeFunctionThatTriggersStubbleColorCalculation()
        {
            shouldCalculateStubbleColor = true;
        }



        public void Hair()
        {
            for (int i = 0; i < hairModels.Length; i++)
            {
                if (i == idHair)
                {
                    hairModels[i].SetActive(true);
                }
                else
                {
                    hairModels[i].SetActive(false);
                }
            }
            
        }

        public void FaceMan()
        {
            for (int i = 0; i < faceManModels.Length; i++)
            {
                if (i == idFaceMan)
                {
                    faceManModels[i].SetActive(true);
                }
                else
                {
                    faceManModels[i].SetActive(false);
                }
            }

        }

        public void FaceFamele()
        {
            for (int i = 0; i < faceFameleModels.Length; i++)
            {
                if (i == idFaceFamele)
                {
                    faceFameleModels[i].SetActive(true);
                }
                else
                {
                    faceFameleModels[i].SetActive(false);
                }
            }
        }
        public void Beard()
        {
            for (int i = 0; i < beardModels.Length; i++)
            {
                if (i == idBeard)
                {
                    beardModels[i].SetActive(true);
                }
                else
                {
                    beardModels[i].SetActive(false);
                }
            }
        }
        public void BrowMan()
        {
            for (int i = 0; i < browModels.Length; i++)
            {
                if (i == idBrowMan)
                {
                    browModels[i].SetActive(true);
                }
                else
                {
                    browModels[i].SetActive(false);
                }
            }
        }
        public void BrowFamele()
        {
            for (int i = 0; i < browFameleModels.Length; i++)
            {
                if (i == idBrowFamele)
                {
                    browFameleModels[i].SetActive(true);
                }
                else
                {
                    browFameleModels[i].SetActive(false);
                }
            }
        }
        public void Ear()
        {
            for (int i = 0; i < earModels.Length; i++)
            {
                if (i == idEar)
                {
                    earModels[i].SetActive(true);
                }
                else
                {
                    earModels[i].SetActive(false);
                }
            }
        }
        

        
        //PRZYK£AD
        public void SwitchNext()
        {
            if (idHair == hairModels.Length - 1)
            { idHair = 0; }
            else
            { idHair++; }
            
        }

        void Awake()
        {
           
        }


        //Przyciski
        public void SwitchHairModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            hairModels[idHair].SetActive(false);

            // zwiêkszenie indeksu o 1
            idHair++;

            // jeœli indeks przekroczy³ rozmiar tablicy, przywróæ go do 0
            if (idHair >= hairModels.Length)
            {
                idHair = 0;
            }

            // w³¹czenie nowego modelu
            hairModels[idHair].SetActive(true);
        }

        public void BackHairModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            hairModels[idHair].SetActive(false);

            // zmniejszenie indeksu o 1
            idHair--;

            // jeœli indeks jest mniejszy ni¿ 0, przywróæ go do maksymalnej wartoœci
            if (idHair < 0)
            {
                idHair = hairModels.Length - 1;
            }

            // w³¹czenie nowego modelu
            hairModels[idHair].SetActive(true);
        }

        public void ForwardFaceManModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            faceManModels[idFaceMan].SetActive(false);

            // zwiêkszenie indeksu o 1
            idFaceMan++;

            // jeœli indeks przekroczy³ rozmiar tablicy, przywróæ go do 0
            if (idFaceMan >= faceManModels.Length)
            {
                idFaceMan = 0;
            }

            // w³¹czenie nowego modelu
            faceManModels[idFaceMan].SetActive(true);
        }

        public void BackFaceManModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            faceManModels[idFaceMan].SetActive(false);

            // zmniejszenie indeksu o 1
            idFaceMan--;

            // jeœli indeks jest mniejszy ni¿ 0, przywróæ go do maksymalnej wartoœci
            if (idFaceMan < 0)
            {
                idFaceMan = faceManModels.Length - 1;
            }

            // w³¹czenie nowego modelu
            faceManModels[idFaceMan].SetActive(true);
        }

        public void ForwardFaceFameleModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            faceFameleModels[idFaceFamele].SetActive(false);

            // zwiêkszenie indeksu o 1
            idFaceFamele++;

            // jeœli indeks przekroczy³ rozmiar tablicy, przywróæ go do 0
            if (idFaceFamele >= faceFameleModels.Length)
            {
                idFaceFamele = 0;
            }

            // w³¹czenie nowego modelu
            faceFameleModels[idFaceFamele].SetActive(true);
        }

        public void BackFaceFameleModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            faceFameleModels[idFaceFamele].SetActive(false);

            // zmniejszenie indeksu o 1
            idFaceFamele--;

            // jeœli indeks jest mniejszy ni¿ 0, przywróæ go do maksymalnej wartoœci
            if (idFaceFamele < 0)
            {
                idFaceFamele = faceFameleModels.Length - 1;
            }

            // w³¹czenie nowego modelu
            faceFameleModels[idFaceFamele].SetActive(true);
        }

        public void ForwardBeardModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            beardModels[idBeard].SetActive(false);

            // zwiêkszenie indeksu o 1
            idBeard++;

            // jeœli indeks przekroczy³ rozmiar tablicy, przywróæ go do 0
            if (idBeard >= beardModels.Length)
            {
                idBeard = 0;
            }

            // w³¹czenie nowego modelu
            beardModels[idBeard].SetActive(true);
        }

        public void BackBeardModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            beardModels[idBeard].SetActive(false);

            // zmniejszenie indeksu o 1
            idBeard--;

            // jeœli indeks jest mniejszy ni¿ 0, przywróæ go do maksymalnej wartoœci
            if (idBeard < 0)
            {
                idBeard = beardModels.Length - 1;
            }

            // w³¹czenie nowego modelu
            beardModels[idBeard].SetActive(true);
        }

        public void ForwardBrowManModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            browModels[idBrowMan].SetActive(false);

            // zwiêkszenie indeksu o 1
            idBrowMan++;

            // jeœli indeks przekroczy³ rozmiar tablicy, przywróæ go do 0
            if (idBrowMan >= browModels.Length)
            {
                idBrowMan = 0;
            }

            // w³¹czenie nowego modelu
            browModels[idBrowMan].SetActive(true);
        }

        public void BackBrowManModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            browModels[idBrowMan].SetActive(false);

            // zmniejszenie indeksu o 1
            idBrowMan--;

            // jeœli indeks jest mniejszy ni¿ 0, przywróæ go do maksymalnej wartoœci
            if (idBrowMan < 0)
            {
                idBrowMan = browModels.Length - 1;
            }

            // w³¹czenie nowego modelu
            browModels[idBrowMan].SetActive(true);
        }

        public void ForwardBrowFameleModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            browFameleModels[idBrowFamele].SetActive(false);

            // zwiêkszenie indeksu o 1
            idBrowFamele++;

            // jeœli indeks przekroczy³ rozmiar tablicy, przywróæ go do 0
            if (idBrowFamele >= browFameleModels.Length)
            {
                idBrowFamele = 0;
            }

            // w³¹czenie nowego modelu
            browFameleModels[idBrowFamele].SetActive(true);
        }

        public void BackBrowFameleModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            browFameleModels[idBrowFamele].SetActive(false);

            // zmniejszenie indeksu o 1
            idBrowFamele--;

            // jeœli indeks jest mniejszy ni¿ 0, przywróæ go do maksymalnej wartoœci
            if (idBrowFamele < 0)
            {
                idBrowFamele = browFameleModels.Length - 1;
            }

            // w³¹czenie nowego modelu
            browFameleModels[idBrowFamele].SetActive(true);
        }

        public void ForwardEarModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            earModels[idEar].SetActive(false);

            // zwiêkszenie indeksu o 1
            idEar++;

            // jeœli indeks przekroczy³ rozmiar tablicy, przywróæ go do 0
            if (idEar >= earModels.Length)
            {
                idEar = 0;
            }

            // w³¹czenie nowego modelu
            earModels[idEar].SetActive(true);
        }

        public void BackEarModel()
        {
            // wy³¹czenie aktualnie wyœwietlanego modelu
            earModels[idEar].SetActive(false);

            // zmniejszenie indeksu o 1
            idEar--;

            // jeœli indeks jest mniejszy ni¿ 0, przywróæ go do maksymalnej wartoœci
            if (idEar < 0)
            {
                idEar = earModels.Length - 1;
            }

            // w³¹czenie nowego modelu
            earModels[idEar].SetActive(true);
        }

        public void SetHairModel(int index)
        {
            // sprawdzenie, czy podany indeks jest prawid³owy
            if (index >= 0 && index < hairModels.Length)
            {
                // utworzenie nowego egzemplarza wybranego modelu 3D w³osów
                GameObject newHairModel = Instantiate(hairModels[index]);

                // skopiowanie pozycji i orientacji aktualnego modelu 3D w³osów do nowego
                newHairModel.transform.position = currentHairModel.transform.position;
                newHairModel.transform.rotation = currentHairModel.transform.rotation;

                // usuniêcie aktualnego modelu 3D w³osów z hierarchy
                Destroy(currentHairModel);

                // ustawienie nowego modelu 3D w³osów jako dziecko tego samego obiektu, co aktualny model
                newHairModel.transform.parent = transform;

                // zapisanie referencji do nowego modelu 3D w³osów jako aktualnego
                currentHairModel = newHairModel;

                idHair = index;
            }
        }
        // metoda do zamiany modelu 3D twarzy (analogiczna do metody SetHairModel)
        public void SetFaceManModel(int index)
        {
            if (index >= 0 && index < faceManModels.Length)
            {
                GameObject newFaceManModel = Instantiate(faceManModels[index]);
                newFaceManModel.transform.position = currentFaceManModel.transform.position;
                newFaceManModel.transform.rotation = currentFaceManModel.transform.rotation;
                Destroy(currentFaceManModel);
                newFaceManModel.transform.parent = transform;
                currentFaceManModel = newFaceManModel;
                idFaceMan = index;
            }
        }
        public void SetFaceFameleModel(int index)
        {
            if (index >= 0 && index < faceFameleModels.Length)
            {
                GameObject newFaceFameleModel = Instantiate(faceFameleModels[index]);
                newFaceFameleModel.transform.position = currentFaceFameleModel.transform.position;
                newFaceFameleModel.transform.rotation = currentFaceFameleModel.transform.rotation;
                Destroy(currentFaceFameleModel);
                newFaceFameleModel.transform.parent = transform;
                currentFaceFameleModel = newFaceFameleModel;
                idFaceFamele = index;
            }
        }
        // metoda do zamiany modelu 3D brody (analogiczna do metod SetHairModel i SetFaceModel)
        public void SetBeardModel(int index)
        {
            if (index >= 0 && index < beardModels.Length)
            {
                GameObject newBeardModel = Instantiate(beardModels[index]);
                newBeardModel.transform.position = currentBeardModel.transform.position;
                newBeardModel.transform.rotation = currentBeardModel.transform.rotation;
                Destroy(currentBeardModel);
                newBeardModel.transform.parent = transform;
                currentBeardModel = newBeardModel;
                idBeard = index;
            }
        }

        // metoda do zamiany modelu 3D brwi (analogiczna do metod SetHairModel, SetFaceModel i SetBeardModel)
        public void SetBrowModel(int index)
        {
            if (index >= 0 && index < browModels.Length)
            {
                GameObject newBrowModel = Instantiate(browModels[index]);
                newBrowModel.transform.position = currentBrowModel.transform.position;
                newBrowModel.transform.rotation = currentBrowModel.transform.rotation;
                Destroy(currentBrowModel);
                newBrowModel.transform.parent = transform;
                currentBrowModel = newBrowModel;
                idBrowMan = index;
            }
        }

        public void SetBrowFameleModel(int index)
        {
            if (index >= 0 && index < browFameleModels.Length)
            {
                GameObject newBrowFameleModel = Instantiate(browFameleModels[index]);
                newBrowFameleModel.transform.position = currentBrowFameleModel.transform.position;
                newBrowFameleModel.transform.rotation = currentBrowFameleModel.transform.rotation;
                Destroy(currentBrowFameleModel);
                newBrowFameleModel.transform.parent = transform;
                currentBrowFameleModel = newBrowFameleModel;
                idBrowFamele = index;
            }
        }

        // metoda do zamiany modelu 3D uszu
        public void SetEarModel(int index)
        {
            if (index >= 0 && index < earModels.Length)
            {
                GameObject newEarModel = Instantiate(earModels[index]);
                newEarModel.transform.position = currentEarModel.transform.position;
                newEarModel.transform.rotation = currentEarModel.transform.rotation;
                Destroy(currentBrowModel);
                newEarModel.transform.parent = transform;
                currentEarModel = newEarModel;
                idEar = index;
            }
        }




        //ZMIANA KOLORU
        [Header("Material")]
        public Material mat;

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


        [Header("Skin Colors")]
        public Color[] alllSkin = { new Color(1f, 0.8000001f, 0.682353f), new Color(0.8196079f, 0.6352941f, 0.4588236f), new Color(0.5647059f, 0.4078432f, 0.3137255f), new Color(0.9607844f, 0.7843138f, 0.7294118f) };

        [Header("Scar Colors")]
        public Color[] alllScar = { new Color(0.9294118f, 0.6862745f, 0.5921569f),
        new Color(0.6980392f, 0.5450981f, 0.4f),
        new Color(0.4235294f, 0.3176471f, 0.282353f),
        new Color(0.8745099f, 0.6588235f, 0.6313726f)
        };

        [Header("Body Art Colors")]
        public Color[] bodyArt = { new Color(0.0509804f, 0.6745098f, 0.9843138f), new Color(0.7215686f, 0.2666667f, 0.2666667f), new Color(0.3058824f, 0.7215686f, 0.6862745f), new Color(0.9254903f, 0.882353f, 0.8509805f), new Color(0.3098039f, 0.7058824f, 0.3137255f), new Color(0.5294118f, 0.3098039f, 0.6470588f), new Color(0.8666667f, 0.7764707f, 0.254902f), new Color(0.2392157f, 0.4588236f, 0.8156863f) };

        [Header("Eye Colors")]
        public Color[] eyesColor = { new Color(0f, 0f, 0f), new Color(0.2862745f, 0.4f, 0.4941177f), new Color(0.4392157f, 0.1960784f, 0.172549f), new Color(0.3529412f, 0.3803922f, 0.2705882f), new Color(0.682353f, 0.4392157f, 0.2196079f), new Color(0.4313726f, 0.2313726f, 0.2705882f), new Color(0.5921569f, 0.4941177f, 0.2588235f), new Color(0.482353f, 0.4156863f, 0.3529412f), new Color(0.2352941f, 0.2352941f, 0.2352941f), new Color(0.2313726f, 0.4313726f, 0.4156863f),
        new Color(0.7019608f, 0.6235294f, 0.4666667f), new Color(0.7372549f, 0.7372549f, 0.7372549f), new Color(0.1647059f, 0.1647059f, 0.1647059f), new Color(0.2392157f, 0.2509804f, 0.1882353f)};

        [Header("Gear Colors")]
        public Color[] primary = { new Color(0.2862745f, 0.4f, 0.4941177f), new Color(0.4392157f, 0.1960784f, 0.172549f), new Color(0.3529412f, 0.3803922f, 0.2705882f), new Color(0.682353f, 0.4392157f, 0.2196079f), new Color(0.4313726f, 0.2313726f, 0.2705882f), new Color(0.5921569f, 0.4941177f, 0.2588235f), new Color(0.482353f, 0.4156863f, 0.3529412f), new Color(0.2352941f, 0.2352941f, 0.2352941f), new Color(0.2313726f, 0.4313726f, 0.4156863f) };
        public Color[] secondary = { new Color(0.7019608f, 0.6235294f, 0.4666667f), new Color(0.7372549f, 0.7372549f, 0.7372549f), new Color(0.1647059f, 0.1647059f, 0.1647059f), new Color(0.2392157f, 0.2509804f, 0.1882353f) };

        [Header("Metal Colors")]
        public Color[] metalPrimary = { new Color(0.6705883f, 0.6705883f, 0.6705883f), new Color(0.5568628f, 0.5960785f, 0.6392157f), new Color(0.5568628f, 0.6235294f, 0.6f), new Color(0.6313726f, 0.6196079f, 0.5568628f), new Color(0.6980392f, 0.6509804f, 0.6196079f) };
        public Color[] metalSecondary = { new Color(0.3921569f, 0.4039216f, 0.4117647f), new Color(0.4784314f, 0.5176471f, 0.5450981f), new Color(0.3764706f, 0.3607843f, 0.3372549f), new Color(0.3254902f, 0.3764706f, 0.3372549f), new Color(0.4f, 0.4039216f, 0.3568628f) };

        [Header("Leather Colors")]
        public Color[] leatherPrimary;
        public Color[] leatherSecondary;

        private int idColor;
        private int idSkinColor;
        private int idTatoColor;
        private int idScarColor;
        private int idEyeColor;
        private int idStubbleColor;
        
        //we grab the material from the skin mesh renderer, and change the color propestues of the mateial
        public List<SkinnedMeshRenderer> hairList, eyeList, tatoList = new List<SkinnedMeshRenderer>();
        public List<SkinnedMeshRenderer> scarList = new List<SkinnedMeshRenderer>();
        public List<SkinnedMeshRenderer> skinList = new List<SkinnedMeshRenderer>();
        public List<SkinnedMeshRenderer> stubbleList = new List<SkinnedMeshRenderer>();
        //public List<SkinnedMeshRenderer> tatoList = new List<SkinnedMeshRenderer>();
        //public List<SkinnedMeshRenderer> eyeList = new List<SkinnedMeshRenderer>();

        private Color currentHairColor;

         //metoda do zmiany koloru w³osów
       public void SetHairColor(Color color)
        {
           Renderer renderer = currentHairModel.GetComponent<Renderer>();
            renderer.material.color = color;
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

            }
        }
        public void ChangeStubbleColor()
        {

            //currentHairColor = new Color();
            for (int i = 0; i < stubbleList.Count; i++)
            {
                //currentHairColor.a = i;
                stubbleList[i].material.SetColor("_Color_Stubble", alllStubbble[idStubbleColor]);

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
            if (idStubbleColor == alllStubbble.Length - 1)
            { idStubbleColor = 0; }
            else
            { idStubbleColor++; }
        }
        public void NextSkinSwitchKolor()
        {
            /* if (idStubbleColor == alllSkin.Length - 1)
             { idSkinColor = 0; }
             else
             { idSkinColor++; }*/
            idSkinColor++;
            if (idSkinColor >= alllSkin.Length)
            {
                idSkinColor = 0;
            }
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
            if (idStubbleColor == 0)
            {
                idStubbleColor = alllStubbble.Length - 1;
            }
            else
            {
                idStubbleColor--;
            }
        }
        public void BackSkinSwitchKolor()
        {
            /*if (idSkinColor == 0)
            {
                idSkinColor = alllSkin.Length - 1;
            }
            else
            {
                idSkinColor--;
            }*/
            idSkinColor--;
            if (idSkinColor < 0)
            {
                idSkinColor = alllSkin.Length - 1;
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


        private int idGender;
        private int idElfHuman;

        public GameObject[] menFamele = new GameObject[2];
        public GameObject[] elfHuman = new GameObject[2];
        private bool shouldCalculateSkinColor;
        private bool shouldCalculateScarColor;
        private bool shouldCalculateHairColor;
        private bool shouldCalculateTatoColor;
        private bool shouldCalculateEyeColor;
        private bool shouldCalculateStubbleColor;

        public void MenFamele(int index)
        {
            // Dezaktywuj obiekt o indeksie przeciwnym do przekazanego indeksu.
            int oppositeIndex = (index == 0) ? 1 : 0;
            menFamele[oppositeIndex].SetActive(false);

            // Aktywuj obiekt o przekazanym indeksie.
            menFamele[index].SetActive(true);
            idGender = index;
        }

        public void OnClickButtonMen()
        {
            MenFamele(0);
        }

        public void OnClickButtonFamele()
        {
            MenFamele(1);
        }

        

        public void ElfHuman(int index)
        {
            // Dezaktywuj obiekt o indeksie przeciwnym do przekazanego indeksu.
            int oppositeIndex = (index == 0) ? 1 : 0;
            elfHuman[oppositeIndex].SetActive(false);

            // Aktywuj obiekt o przekazanym indeksie.
            elfHuman[index].SetActive(true);
            idElfHuman = index;
        }

        public void OnClickButtonHuman()
        {
            ElfHuman(0);
        }

        public void OnClickButtonElf()
        {
            ElfHuman(1);
        }
        /*public void Women()
        {
            if (womenParts.activeInHierarchy == false)
            {
                womenParts.SetActive(true);
                menParts.SetActive(false);
            }
        }
        */
        public object CaptureState()
        {
            
            Dictionary<string, object> data = new Dictionary<string, object>();
            //MOIDELE
            data["W³osy"] = idHair;
            data["TwarzMen"] = idFaceMan;
            data["TwarzFam"] = idFaceFamele;
            data["Broda"] = idBeard;
            data["BrwiMan"] = idBrowMan;
            data["BrwiFam"] = idBrowFamele;
            data["Uszy"] = idEar;
            //KOLORY
            data["KolorSkóry"] = idSkinColor;
            data["KolorOwlosienia"] = idColor;
            data["KolorTato"] = idTatoColor;
            data["KolorBlizn"] = idScarColor;
            data["KolorOczu"] = idEyeColor;
            data["KolorZarostu"] = idStubbleColor;
            //P£EÆ
            data["Gender"] = idGender;
            data["ElfHuman"] = idElfHuman;
            return data;
            
            // KOLORY
            /* return idColor;
             return idSkinColor;
             return idTatoColor;
             return idScarColor;
             return idEyeColor;
             return idStubbleColor;
             */
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> data = (Dictionary<string, object>)state;
            //MODEL
            idHair = (int)data["W³osy"];
            Hair();
            idFaceMan = (int)data["TwarzMen"];
            FaceMan();
            idFaceFamele = (int)data["TwarzFam"];
            FaceFamele();
            idBeard = (int)data["Broda"];
            Beard();
            idBrowMan = (int)data["BrwiMan"];
            BrowMan();
            idBrowFamele = (int)data["BrwiFam"];
            BrowFamele();
            idEar = (int)data["Uszy"];
            Ear();
            //Kolor
            idSkinColor = (int)data["KolorSkóry"];
            ChangeSkinColor();
            idColor = (int)data["KolorOwlosienia"];
            ChangeHairColor();
            idTatoColor = (int)data["KolorTato"];
            ChangeTatoColor();
            idScarColor = (int)data["KolorBlizn"];
            ChangeScarColor();
            idEyeColor = (int)data["KolorOczu"];
            ChangeEyeColor();
            idStubbleColor = (int)data["KolorZarostu"];
            ChangeStubbleColor();
            

            //
            idGender = (int)data["Gender"];
            MenFamele(idGender);
            idElfHuman = (int)data["ElfHuman"];
            ElfHuman(idElfHuman);

           
        }


    }
    }



