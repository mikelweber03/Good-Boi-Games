using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int _maxHealth;
    private int _currentHealth;
    private bool death = false;
    public CheckHealth _healthBar;
    void Start()
    {
        _currentHealth = _maxHealth;

    }

    private void Update()
    {
        _healthBar.ChangeHealth(_currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_currentHealth > 0) 
            {
                _currentHealth--;
                Debug.Log(_currentHealth);
            }
            else
            {
                death = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthPickup"))
        {
            if(_currentHealth < _maxHealth)
            {
                _currentHealth++;
            }
            
        }
    }


}
