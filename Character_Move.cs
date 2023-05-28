using UnityEngine;

public class Character_Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Character _character;
    [SerializeField] private ActionInterface actionInterface;

    private void Move()
    {
        transform.Translate(moveSpeed * Time.deltaTime * actionInterface.MovementVector());
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