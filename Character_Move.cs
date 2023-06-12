using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Character _character;

    public int InGame_Y_Movement()
    {
        if (ControlInterface.IsPressed_Keyboard1_Up)
        {
            if (transform.position.y > GameManager.Singleton.UpperBounds)
            {
                return 0;
            }

            return 1;
        }
        if (ControlInterface.IsPressed_Keyboard1_Down)
        {
            if (transform.position.y < GameManager.Singleton.LowerBounds)
            {
                return 0;
            }

            return -1;
        }
        return 0;
    }

    public int InGame_X_Movement()
    {
        if (ControlInterface.IsPressed_Keyboard1_Right)
        {
            if (transform.position.x > GameManager.Singleton.RightBounds)
            {
                return 0;
            }

            return 1;
        }
        if (ControlInterface.IsPressed_Keyboard1_Left)
        {
            if (transform.position.x < GameManager.Singleton.LeftBounds)
            {
                return 0;
            }
            return -1;

        }
        return 0;
    }

    public Vector2 MovementVector()
    {
        Vector2 vec = new Vector2(InGame_X_Movement(), InGame_Y_Movement());

        float mag = vec.magnitude;

        if (mag > 1)
        {
            vec /= mag;
        }

        return vec;
    }

    private void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * MovementVector());
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

        Move(moveSpeed);
    }
}