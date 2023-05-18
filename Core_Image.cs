using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core_Image : MonoBehaviour
{
    [SerializeField]
    private float scaleSpeed, moveSpeed;

    private void Update()
    {
        if (GameManager.Singleton.GameState == GameState.GameOver)
        {
            scaleSpeed = 0.3F;
            moveSpeed = 0.2F;
        }

        transform.localScale += Vector3.one * Time.deltaTime * scaleSpeed;

        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
    }
}
