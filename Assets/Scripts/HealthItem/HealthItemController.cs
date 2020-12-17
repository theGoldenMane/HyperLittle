using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemController : MonoBehaviour
{
    public float healAmount = 0.25f;
    public static float healPoints;

    void Start()
    {
        healPoints = healAmount;
    }
}
