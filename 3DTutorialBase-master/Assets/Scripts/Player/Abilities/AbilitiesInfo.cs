using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilitiesInfo
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("How much power this ability has.")]
    private int m_Power;
    public int Power
    {
        get
        {
            return m_Power;
        }
    }

    [SerializeField]
    [Tooltip("How far is this ability's attack range.")]
    private float m_Range;
    public float Range
    {
        get
        {
            return m_Range;
        }
    }

    #endregion
}
