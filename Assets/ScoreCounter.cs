using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private ScoreSaver _scoreSaver;
    [SerializeField] private Text _eggCountDisplay;
    [SerializeField] private Text _timeCountDisplay;
    private int _eggCount = 0;
    private int _timeCount = 0;
    public int Score => _eggCount + _timeCount / 10;

    private void Start()
    {
        var player = FindObjectOfType<Player>();
        player.PlayerDied += SaveScore;
    }

    private void Update()
    {
        _timeCount = Convert.ToInt32(Time.time);
        _timeCountDisplay.text = _timeCount.ToString();
    }
    private void SaveScore()
    {
        if(Score > _scoreSaver.MaxScore)
        {
            _scoreSaver.SaveScore(Score);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void AddEgg()
    {
        _eggCount++;
        _eggCountDisplay.text = _eggCount.ToString();
    }
    
}
