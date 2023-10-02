using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.GetComponent<IHealable>().Heal(gameObject);
    }
    
    
}
