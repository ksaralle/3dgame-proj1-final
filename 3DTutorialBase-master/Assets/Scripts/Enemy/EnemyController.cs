using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Enemy's maximum health.")]
    private int m_Maxhealth;

    [SerializeField]
    [Tooltip("Damage health per frame.")]
    private float m_speed;

    [SerializeField]
    [Tooltip("Enemy's health.")]
    private float m_Damage;

    [SerializeField]
    [Tooltip("The explosion for when this enemy dies.")]
    private ParticleSystem m_DealthExplosion;

    [SerializeField]
    [Tooltip("The probability that the enemy drops pills. ")]
    private float m_HealthPillDropRate;

    [SerializeField]
    [Tooltip("The type of health pill this enemy drops ")]
    private GameObject m_HealthPill;

    [SerializeField]
    [Tooltip("Number of points the player get for killing this enemy. ")]
    private int m_Score;

    #endregion

    #region Private Variables
    // current health
    private float p_curHealth;
    #endregion

    #region Cached Component
    private Rigidbody cc_Rb;
    #endregion

    #region Cached References
    private Transform cr_Player;
    #endregion

    #region Initialization
    private void Awake()
    {
        p_curHealth = m_Maxhealth;
        cc_Rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        cr_Player = FindObjectOfType<PlayerController>().transform;
    }
    #endregion

    #region Main Updates
    private void FixedUpdate()
    {
        Vector3 dir = cr_Player.position - transform.position;
        dir.Normalize();
        cc_Rb.MovePosition(cc_Rb.position + dir * m_speed * Time.fixedDeltaTime);
    }
    #endregion

    #region Collision Methods
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Player"))
        {
            DecreaseHealth(m_Damage);
            other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
        }
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        p_curHealth -= amount;

        // if this enemy dies
        if (p_curHealth <= 0)
        {
            ScoreManager.singleton.IncreaseScore(m_Score);
            if (Random.value < m_HealthPillDropRate)
            {
                Instantiate(m_HealthPill, transform.position, Quaternion.identity);
            }
            Instantiate(m_DealthExplosion, transform.position, Quaternion.identity);
            // destroy this game object
            Destroy(gameObject);
        }
    }
    #endregion
}
