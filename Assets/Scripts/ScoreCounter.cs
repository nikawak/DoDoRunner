using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _eggCountDisplay;
    [SerializeField] private Text _timeCountDisplay;
    private int _eggCount = 0;
    private int _timeCount = 0;
    public int Score => _eggCount * _timeCount / 2;

    void Update()
    {
        _timeCount = Convert.ToInt32(Time.time);
        _timeCountDisplay.text = _timeCount.ToString();
    }
    public void AddEgg()
    {
        _eggCount++;
        _eggCountDisplay.text = _eggCount.ToString();
    }
}
