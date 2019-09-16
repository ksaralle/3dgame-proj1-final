using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    public override void Use(Vector3 spawnPos)
    {
        Debug.Log("invoked fireball's class.");
        RaycastHit[] hits = Physics.SphereCastAll(spawnPos, 2f, transform.forward, m_Info.Range);
        Debug.Log("how many fireball hits:" + hits.Length);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyController>().DecreaseHealth(m_Info.Power);
            }
        }
        var emitterShape = cc_PS.shape;
        emitterShape.length = m_Info.Range;
        cc_PS.Play();
    }

    
}
