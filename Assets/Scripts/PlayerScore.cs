using System;

[Serializable]
public struct PlayerScore
{
    public PlayerScore(string name, int maxScore)
    {
        Name = name;
        MaxScore = maxScore;
    }

    public string Name { get; set; }
    public int MaxScore { get; set; }
}