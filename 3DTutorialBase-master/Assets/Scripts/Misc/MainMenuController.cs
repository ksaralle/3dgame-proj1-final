using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The text showing the highest score. ")]
    private Text m_HighScore;
    #endregion

    #region Private Variables
    private string p_DefaultHighScoreText;
    #endregion

    #region Initialization
    private void Awake()
    {
        // show cursor
        Cursor.lockState = CursorLockMode.None;
        p_DefaultHighScoreText = m_HighScore.text;
    }
    private void Start()
    {
        UpdateHighScore();
    }
    #endregion

    #region Play Button Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("Arena");
    }
    #endregion

    #region General Application Button Methods
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region High Score Methods
    // updating the highest score in UI
    private void UpdateHighScore()
    {
        // player has played before
        if (PlayerPrefs.HasKey("HS"))
        {
            m_HighScore.text = p_DefaultHighScoreText.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        // player never played before
        {
            PlayerPrefs.SetInt("HS", 0);
            m_HighScore.text = p_DefaultHighScoreText.Replace("%S", "0");
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        UpdateHighScore();
    }
    #endregion
}
