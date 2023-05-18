using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorePivot : MonoBehaviour
{
    [SerializeField]
    private GameObject character;

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.down);

        transform.LookAt(character.transform);
    }
}