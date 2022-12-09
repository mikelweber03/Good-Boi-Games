using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
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
        //If Healthpickup then regen health and destroy pickup
        if (collision.gameObject.CompareTag("HealthPickup"))
        {
            if (_currentHealth < _maxHealth)
            {
                _currentHealth++;
                _healthBar.ChangeHealth(_currentHealth);
                Destroy(collision.gameObject);
            }

        }
    }

 

}
