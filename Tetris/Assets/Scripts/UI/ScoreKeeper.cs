using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnEnable()
    {
        EventManager.instance.onLineCleared += UpdateScore;
    }
    private void OnDisable()
    {
        EventManager.instance.onLineCleared -= UpdateScore;
    }

    private void UpdateScore(Player player)
    {
        if (player == Player.player1)
            player1Score += 1;
        else
            player2Score += 1;

        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        player1ScoreText.text = $"{player1Score} pts.";
        player2ScoreText.text = $"{player2Score} pts.";
    }
}
