using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    //public UnitHealth _playerHealth = new UnitHealth(500,500);
    void Awake()
    {
        if(gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
          gameManager = this;
        }
    }

    
}
