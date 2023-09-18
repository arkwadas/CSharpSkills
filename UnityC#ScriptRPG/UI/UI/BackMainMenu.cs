using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMainMenu : MonoBehaviour
{
    public void PrzywrocDoScenyZero()
    {
        // Za³aduj scenê o indeksie 0
        SceneManager.LoadScene(0);
    }
}