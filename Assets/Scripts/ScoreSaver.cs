using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    public int MaxScore => PlayerPrefs.GetInt("MaxScore");
    
    public void SaveScore(int value)
    {
        PlayerPrefs.SetInt("MaxScore", value);
        PlayerPrefs.Save();
    }
}
