using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frobot : MonoBehaviour
{
    public static int count { get; private set; }
    
    public static void IncreaseCount()
    {
        count++;
    }

    public static void DecreaseCount ()
    {
        count--;
    }

    private void Awake()
    {
        IncreaseCount();
    }

    private void OnDestroy()
    {
        DecreaseCount();
    }
}