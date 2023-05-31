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

    [SerializeField] private float leftBounds, rightBounds, upperBounds, lowerBounds;

    public float LeftBounds => leftBounds;
    public float RightBounds => rightBounds;
    public float UpperBounds => upperBounds;
    public float LowerBounds => lowerBounds;

    [SerializeField]    private GameState gameState;

    public GameState GameState => gameState;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] ProjectileWeapon coreWeapon;
    [SerializeField] private int score;

    public int Score => score;
    public void EnablePauseMenu() => pauseMenu.SetActive(true);
    public void DisablePauseMenu() => pauseMenu.SetActive(false);

    public void TriggerGameOver ()
    {
        SetGameState(GameState.GameOver);        

        StartCoroutine(SceneManager_InGame.Singleton.Routine_GameOver());
    }

    public void SetGameState (GameState state)
    {
        gameState = state;
    }

    public void AwardPoints (int amount)
    {
        score += amount;
    }

    public void AddToScore (int amount)
    {
        score += amount;
    }

    private void Update()
    {
        if(ControlInterface.PressedThisFrame_Keyboard1_Pause)
        {
            if (gameState == GameState.InProgress)
            {
                StartCoroutine(SceneManager_InGame.Singleton.Routine_PauseGame());

                return;
            }
            if(gameState == GameState.Paused)
            {
                StartCoroutine(SceneManager_InGame.Singleton.Routine_ResumeGame());

                return;
            }
        }
    }
}