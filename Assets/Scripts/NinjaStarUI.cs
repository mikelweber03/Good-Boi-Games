using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaStarUI : MonoBehaviour

{
    Image _star1;
    Image _star2;
    Image _star3;
    void Start()
    {
        //_heart = GetComponent<Image>();
        _star1 = GameObject.Find("Star1").GetComponent<Image>();
        _star2 = GameObject.Find("Star2").GetComponent<Image>();
        _star3 = GameObject.Find("Star3").GetComponent<Image>();
        

    }
    public void ChangeStar(int starAmont)
    {
        //Checks at what star amont the player should be and displays it
        if (starAmont == 1)
        {
            _star1.enabled = true;
            _star2.enabled = false;
            _star3.enabled = false;


        }

        if (starAmont == 2)
        {
            _star1.enabled = false;
            _star2.enabled = true;
            _star3.enabled = false;


        }
        if (starAmont == 3)
        {
            _star1.enabled = false;
            _star2.enabled = false;
            _star3.enabled = true;


        }
        if (starAmont == 0)
        {
            _star1.enabled = false;
            _star2.enabled = false;
            _star3.enabled = false;


        }
    }
}
