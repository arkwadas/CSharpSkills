using System;
using System.Collections;
using System.Collections.Generic;
using GameDevTV.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        //private const string currentSaveKey = "currentSaveName";
        const string autoSaveFile = "autosave";
        const string manualSaveFile = "manualsave";
        const string latestSaveFileKey = "latestSaveFile";
        [SerializeField] float fadeInTime = 0.2f;
        [SerializeField] float fadeOutTime = 0.2f;
        [SerializeField] int firstLevelBuildIndex = 1;
        [SerializeField] int menuLevelBuildIndex = 0;


   

        public void ContinueGame()
        {
            //if (!PlayerPrefs.HasKey(currentSaveKey)) return;
            if (!PlayerPrefs.HasKey(latestSaveFileKey)) return;
            
            //if (!GetComponent<SavingSystem>().SaveFileExist(GetCurrentSave())) return;
            //StartCoroutine(LoadLastScene());
            StartCoroutine(LoadScene(GetCurrentSave()));
        }

        public void NewGame(string saveFile)
        {
            if (String.IsNullOrEmpty(saveFile)) return;
            SetCurrentSave(saveFile);
            StartCoroutine(LoadFirstScene());
        }

        public void LoadGame(string saveFile)
        {
            SetCurrentSave(saveFile);
            //ContinueGame();
            StartCoroutine(LoadScene(saveFile));
        }

        private IEnumerator LoadMenu()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeInTime);
            yield return SceneManager.LoadSceneAsync(0);
            yield return fader.FadeIn(fadeInTime);
        }



        private string GetCurrentSave()
        {
            //return PlayerPrefs.GetString(currentSaveKey);
            return PlayerPrefs.GetString(latestSaveFileKey, null);
        }

        /*private void SetCurrentSave(string saveFile)
        {
            PlayerPrefs.SetString(currentSaveKey, saveFile);
        }*/

        public void SetCurrentSave(string saveFile)
        {
            PlayerPrefs.SetString(latestSaveFileKey, saveFile);
            PlayerPrefs.Save();
        }

        public IEnumerable<string> GetAllSaves()
        {
            return GetComponent<SavingSystem>().ListSaves();
        }

        /*private IEnumerator LoadLastScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOutTime);
            yield return GetComponent<SavingSystem>().LoadLastScene(GetCurrentSave());
            yield return fader.FadeIn(fadeInTime);
        }*/

        private IEnumerator LoadScene(string saveFile)
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeInTime);
            yield return GetComponent<SavingSystem>().LoadLastScene(saveFile);
            yield return fader.FadeIn(fadeInTime);
        }

        private IEnumerator LoadFirstScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOutTime);
            yield return SceneManager.LoadSceneAsync(firstLevelBuildIndex);
            yield return fader.FadeIn(fadeInTime);
        }

        /*private IEnumerator LoadMenuScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            yield return fader.FadeOut(fadeOutTime);
            yield return SceneManager.LoadSceneAsync(menuLevelBuildIndex);
            yield return fader.FadeIn(fadeInTime);
        }*/

       
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                // Save();
                ManualSave();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {

                //LoadMenu();
                //Load();
                StartCoroutine(LoadScene(GetCurrentSave()));
                /*foreach (var item in GetComponent<SavingSystem>().ListSaves())
                {
                    print(item);
                }*/
                //Load();
                //Load();
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        public string GetLatestSave()
        {
            return PlayerPrefs.GetString(latestSaveFileKey, null);
        }
        public void LoadManualSave()
        {
            GetComponent<SavingSystem>().Load(manualSaveFile);
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(GetCurrentSave());
            
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(GetCurrentSave());
        }
        
        public void ManualSave()
        {
            //GetComponent<SavingSystem>().Save(manualSaveFile);
            var saveFile = $"{manualSaveFile} {System.DateTime.Now.ToString()}";
            saveFile = saveFile.Replace("/", "-").Replace(":", "");
            GetComponent<SavingSystem>().Save(saveFile);
            PlayerPrefs.SetString(latestSaveFileKey, saveFile);
            PlayerPrefs.Save();
        }

        public void LoadAutoSave()
        {
            GetComponent<SavingSystem>().Load(autoSaveFile);
        }


        public void AutoSave()
        {
            //GetComponent<SavingSystem>().Save(autoSaveFile);
            GetComponent<SavingSystem>().Save(autoSaveFile);
            PlayerPrefs.SetString(latestSaveFileKey, autoSaveFile);
            PlayerPrefs.Save();
        }
        
        public void Delete()
        {
            //GetComponent<SavingSystem>().Delete(GetCurrentSave());
            GetComponent<SavingSystem>().Delete(autoSaveFile);
        }

        public IEnumerable<string> ListSaves()
        {
            return GetComponent<SavingSystem>().ListSaves();
        }

        // nowoœci do testów
        public void OpenMenu()
        {
            StartCoroutine(LoadMenu());
        }

        

        public void DeleteAutoSave()
        {
            GetComponent<SavingSystem>().Delete(autoSaveFile);
        }
    }
}