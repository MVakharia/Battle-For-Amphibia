using UnityEngine;

public enum GameState { Standby, InProgress, Paused, GameOver }

public class GameManager : MonoBehaviour
{
    private static GameManager singleton;

    public static GameManager Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
            }
            return singleton;
        }
    }

    [SerializeField]
    private float leftBounds, rightBounds, upperBounds, lowerBounds;

    public float LeftBounds => leftBounds;
    public float RightBounds => rightBounds;
    public float UpperBounds => upperBounds;
    public float LowerBounds => lowerBounds;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    private GameState gameState;

    public GameState GameState => gameState;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    ProjectileWeapon coreWeapon;

    public int WaveNumber => coreWeapon.SetNumber;

    [SerializeField]
    private int score;

    public int Score => score;

    public void EnablePauseMenu() => pauseMenu.SetActive(true);

    public void DisablePauseMenu() => pauseMenu.SetActive(false);

    public void TriggerGameOver ()
    {
        gameState = GameState.GameOver;

        StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_GameOver());
    }

    public void SetGameState (GameState state)
    {
        gameState = state;
    }

    public void ChangeScore (int amount)
    {
        score += amount;
    }

    private void Update()
    {
        if(ControlInterface.PressedThisFrame_Keyboard_Pause)
        {
            if (gameState == GameState.InProgress)
            {
                StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_PauseGame());

                return;
            }
            if(gameState == GameState.Paused)
            {
                StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_ResumeGame());

                return;
            }
        }
    }
}