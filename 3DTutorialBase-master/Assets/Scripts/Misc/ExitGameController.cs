using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ExitGameController : MonoBehaviour
{
    #region Initialization
    private void Awake()
    {
        // show cursor
        Cursor.lockState = CursorLockMode.None;
        
    }
   
    #endregion

    #region Exit Game Method
    public void ExitGame()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
