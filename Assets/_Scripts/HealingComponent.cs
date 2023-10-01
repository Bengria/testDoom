using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingComponent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Hilingable>().Heal(gameObject);
    }
    
    
}
