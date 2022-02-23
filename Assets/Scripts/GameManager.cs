using Assets.Scripts.DataAccess;
using Assets.Scripts.Factories;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    private IPlayerScoreDataAccess scoreBoardDataAccess;
    public static GameManager Instance { get; private set; }
    public ScoreBoard ScoreBoard { get; set; }
    public string PlayerName { get; set; }
    public PlayerScore TopScore => ScoreBoard.MaxScore;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this);
        scoreBoardDataAccess = DataAccessFactory.ScoreBoard();
        LoadScoreBoard();
    }

    public void AddScore(int score)
    {
        ScoreBoard.Add(new PlayerScore(PlayerName, score));
    }

    public void SaveScoreBoard()
    {
        scoreBoardDataAccess.Save(ScoreBoard);
    }

    public void LoadScoreBoard()
    {
        ScoreBoard = scoreBoardDataAccess.Load() ?? new ScoreBoard(10);
    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}