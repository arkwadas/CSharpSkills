using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{
    public void PrzywrocDoScenyZero()
    {
        // Za�aduj scen� o indeksie 0
        SceneManager.LoadScene(0);
    }
}