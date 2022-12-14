using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHealth : MonoBehaviour
{
    Image _heart;
    Image _heart1;
    Image _heart2;
    Image _heart3;  
    void Start()
    {
        //_heart = GetComponent<Image>();
        _heart = GameObject.Find("Heart1").GetComponent<Image>();
        _heart1 = GameObject.Find("Heart2").GetComponent<Image>();
        _heart2 = GameObject.Find("Heart3").GetComponent<Image>();
        _heart3 = GameObject.Find("Heart4").GetComponent<Image>();
        
    }
    public void ChangeHealth(int currentHealth)
    {
        //Checks at what health the player should be and displays it
        if(currentHealth == 3)
        {
            _heart.enabled = true;
            _heart1.enabled = false;
            _heart2.enabled = false;
            _heart3.enabled = false;
            

        }

        if (currentHealth == 2)
        {
            _heart.enabled = false;
            _heart1.enabled = true;
            _heart2.enabled = false;
            _heart3.enabled = false;
            

        }
        if (currentHealth == 1)
        {
            _heart.enabled = false;
            _heart1.enabled = false;
            _heart2.enabled = true;
            _heart3.enabled = false;
            

        }
        if (currentHealth == 0)
        {
            _heart.enabled = false;
            _heart1.enabled = false;
            _heart2.enabled = false;
            _heart3.enabled = true;
            

        }
    }
}
