using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int _maxHealth = 3;
    private int _currentHealth;
    public DeathMenu deathmenu;
    public CheckHealth _healthBar;
    void Start()
    {
        _currentHealth = _maxHealth;

    }
    //Check if player can loose health
    //if he can then make them loose one and update healthbar
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_currentHealth > 1) 
            {
                _currentHealth--;
                _healthBar.ChangeHealth(_currentHealth);
                Debug.Log(_currentHealth);
            }
            else
            {
                _currentHealth--;
                _healthBar.ChangeHealth(_currentHealth);
                deathmenu.ToggleEndMenu();
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
