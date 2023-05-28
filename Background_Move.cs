using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : MonoBehaviour
{
    [Range(0, 2)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Character _character;
    [SerializeField] private ActionInterface actionInterface;

    private void Move()
    {
        transform.Translate(-moveSpeed * Time.deltaTime * actionInterface.MovementVector());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Singleton.GameState != GameState.InProgress)
        {
            return;
        }

        if (_character.CurrentState == CharacterState.Dead)
        {
            return;
        }

        Move();
    }
}
