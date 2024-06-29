using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { Setup, Playing, RoundEnd }
    public GameState CurrentState { get; private set; }

    public int CurrentRound { get; private set; }
    public int TotalRounds { get; private set; } = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        CurrentRound = 1;
        SetGameState(GameState.Playing);
    }

    public void EndRound()
    {
        SetGameState(GameState.RoundEnd);
        CurrentRound++;
        if (CurrentRound > TotalRounds)
        {
            Debug.Log("Game Over");
            // Implement game over logic here
        }
        else
        {
            SetGameState(GameState.Playing);
        }
    }

    private void SetGameState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"Game State changed to: {CurrentState}");
    }
}