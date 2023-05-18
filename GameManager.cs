using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void EnablePauseMenu() => pauseMenu.SetActive(true);

    public void DisablePauseMenu() => pauseMenu.SetActive(false);

    public void TriggerGameOver ()
    {
        gameState = GameState.GameOver;

        StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_GameOver());
    }

    public void StartRound ()
    {
        gameState = GameState.InProgress;
    }

    private void Update()
    {
        if(ControlInterface.PressedThisFrame_Keyboard_Pause)
        {
            if (gameState == GameState.InProgress)
            {
                StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_PauseGame());
            }
            if(gameState == GameState.Paused)
            {
                StartCoroutine(InGame_GameObjectAnimator.Singleton.Routine_ResumeGame());
            }            
        }
    }
}