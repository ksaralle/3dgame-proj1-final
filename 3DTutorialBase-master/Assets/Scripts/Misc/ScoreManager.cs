using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    #region Private Variables
    private int m_CurScore;
    #endregion

    #region Initialization
    private void Awake()
    {
        // check if this singleton is the only singleton object to exist
        if (singleton == null)
        {
            singleton = this;
        } else if (singleton != this)
        {
            // destroy the new game object instance
            Destroy(gameObject);
        }
        m_CurScore = 0;
    }
    #endregion

    #region Score Methods
    public void IncreaseScore(int amount)
    {
        m_CurScore += amount;
    }

    private void UpdateHighScore()
    {
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", m_CurScore);
            return;
        }

        // get the current highest score
        int hs = PlayerPrefs.GetInt("HS");
        // update it if we have a higher score
        if (m_CurScore > hs)
        {
            PlayerPrefs.SetInt("HS", m_CurScore);
        }

    }
    #endregion

    #region Destruction
    private void OnDisable()
    {
        UpdateHighScore();
    }
    #endregion
}
