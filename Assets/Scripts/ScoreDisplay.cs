using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreDisplay;
    [SerializeField] private ScoreSaver _scoreSaver;
    void Start()
    {
        _scoreDisplay.text = _scoreSaver.MaxScore.ToString();
    }

}
