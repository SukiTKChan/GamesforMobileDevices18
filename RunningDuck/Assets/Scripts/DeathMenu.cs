using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour 
{
     
        
   //public string mainMenu;
    void Start()
    {
        
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().ResetPlayer();

    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

 }
