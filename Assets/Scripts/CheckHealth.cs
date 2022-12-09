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
    Image _eheart;
    void Start()
    {
        _heart = GameObject.Find("FullHeart").GetComponent<Image>();
        _heart1 = GameObject.Find("FullHeart1").GetComponent<Image>();
        _heart2 = GameObject.Find("FullHeart2").GetComponent<Image>();
        _heart3 = GameObject.Find("FullHeart3").GetComponent<Image>();
        _eheart = GameObject.Find("EmptyHeart").GetComponent<Image>();
    }
    public void ChangeHealth(int currentHealth)
    {
        //Checks at what health the player should be and displays it
        if(currentHealth == 3)
        {
            _heart1.sprite = _heart.sprite;
            _heart2.sprite = _heart.sprite;
            _heart3.sprite = _heart.sprite;
            
        }

        if (currentHealth == 2)
        {
            _heart1.sprite = _heart.sprite;
            _heart2.sprite = _heart.sprite;
            _heart3.sprite = _eheart.sprite;

        }
        if (currentHealth == 1)
        {
            _heart1.sprite = _heart.sprite;
            _heart2.sprite = _eheart.sprite;
            _heart3.sprite = _eheart.sprite;

        }
        if (currentHealth == 0)
        {
            _heart1.sprite = _eheart.sprite;
            _heart2.sprite = _eheart.sprite;
            _heart3.sprite = _eheart.sprite;

        }
    }
}
