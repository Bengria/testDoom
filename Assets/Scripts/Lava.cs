using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Lava : MonoBehaviour
{
    [SerializeField] private int damagePerSecond;
    public int DamagePerSecond => damagePerSecond;

    private void OnCharacterStay(PlayerController playerController)
    {
        print($"Stay on Lava: {playerController.name}");
    }

    private void OnCharacterEnter(PlayerController playerController)
    {
        print("Enter Lava");
    }

    private void OnCharacterExit(PlayerController playerController)
    {
        print("Exit Lava");
    }
}
