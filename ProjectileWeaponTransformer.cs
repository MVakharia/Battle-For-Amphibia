using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponTransformer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character");
    }

    // Update is called once per frame
    void Update()
    {

    }
}