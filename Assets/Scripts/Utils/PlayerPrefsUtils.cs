using UnityEngine;

public static class PlayerPrefsUtils
{
    private const string MaxScoreKey = "MaxScore";
    public static void SetMaxPlayerScore(int score)
        => PlayerPrefs.SetInt(MaxScoreKey, score);
    
    public static int GetMaxPlayerScore()
        => PlayerPrefs.GetInt(MaxScoreKey);
}