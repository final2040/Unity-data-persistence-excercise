using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private TMP_InputField playerNameText;
    [SerializeField] private TextMeshProUGUI scoreList;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        ShowScore();
    }

    private void ShowScore()
    {
        if (gameManager.ScoreBoard.Count == 0)
        {
            scoreList.text = "No scores to show.";
        }
        else
        {
            var builder = new StringBuilder();
            foreach (var score in gameManager.ScoreBoard)
            {
                builder.AppendLine($"{score.Name} \t\t\t  {score.MaxScore}");
            }

            scoreList.text = builder.ToString();
        }
    }

    public void OnPlayButtonClicked()
    {
        if (string.IsNullOrWhiteSpace(playerNameText.text))
        {
            DisplayError("You must provide a name.");
        }
        else
        {
            gameManager.PlayerName = playerNameText.text;
            gameManager.Play();
        }
    }

    private void DisplayError(string message)
    {
        messageBox.Show(message);
    }

    public void OnQuitButtonClicked()
    {
        gameManager.Quit();
    }

}
