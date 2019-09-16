using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("All information about this particular ability.")]
    protected AbilitiesInfo m_Info;
    #endregion

    #region Cached Components
    protected ParticleSystem cc_PS;
    #endregion

    #region Initialization
    private void Awake()
    {
        Debug.Log("ability initialized.");
        cc_PS = GetComponent<ParticleSystem>();
    }
    #endregion

    #region Use Methods
    // from where spawn is located
    public abstract void Use(Vector3 spawnPos);
    #endregion
}
