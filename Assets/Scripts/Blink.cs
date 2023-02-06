using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Blink : MonoBehaviour
{
    private bool _needDecrease = true;
    void Update()
    {
        var coef = 1.002f;
        
        if(transform.localScale.x > 0.5 && _needDecrease)
        {
            transform.localScale /= coef;
           
        }
        else if (transform.localScale.x < 1)
        {
            transform.localScale *= coef;
            _needDecrease = false;
        }
        else _needDecrease = true;
    }

}
