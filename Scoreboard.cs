using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboard;
    private int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreboard.text = score.ToString();
    }
}