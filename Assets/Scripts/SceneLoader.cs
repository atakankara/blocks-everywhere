using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentIndex);
        SceneManager.LoadScene(currentIndex + 1);
    }
     
    public void LoadStartScene()  
    {
        FindObjectOfType<GameStatus>().DestroyYourself();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
}
