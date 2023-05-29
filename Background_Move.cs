using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : MonoBehaviour
{
    [Range(0, 2)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Character _character;
    [SerializeField] private Character_Move _characterMove;

    private void Move(float speed)
    {
        transform.Translate(-speed * Time.deltaTime * _characterMove.MovementVector());
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

        Move(moveSpeed);
    }
}
