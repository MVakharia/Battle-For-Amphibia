using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Character _character;

    private int yMovement()
    {
        if (ControlInterface.IsPressed_Keyboard_Up)
        {
            if (transform.position.y > GameManager.Singleton.UpperBounds)
            {
                return 0;
            }

            return 1;
        }
        if (ControlInterface.IsPressed_Keyboard_Down)
        {
            if (transform.position.y < GameManager.Singleton.LowerBounds)
            {
                return 0;
            }

            return -1;
        }
        return 0;
    }

    private int xMovement()
    {
        if (ControlInterface.IsPressed_Keyboard_Right)
        {
            if (transform.position.x > GameManager.Singleton.RightBounds)
            {
                return 0;
            }

            return 1;
        }
        if (ControlInterface.IsPressed_Keyboard_Left)
        {
            if (transform.position.x < GameManager.Singleton.LeftBounds)
            {
                return 0;
            }
            return -1;

        }
        return 0;
    }

    private void Move()
    {
        Vector2 movementVector = new Vector2(xMovement(), yMovement());

        float mag = movementVector.magnitude;

        if (mag > 1)
        {
            movementVector /= mag;
        }

        transform.Translate(movementVector * Time.deltaTime * moveSpeed);
    }

    private void Update()
    {
        if(GameManager.Singleton.GameState != GameState.InProgress)
        {
            return;
        }

        if(_character.CurrentState == CharacterState.Dead)
        {
            return;
        }

        Move();
    }
}