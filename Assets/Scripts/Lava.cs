using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int damagePerSecond;
    public int DamagePerSecond => damagePerSecond;
}
