using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement1 : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 target;
    bool goal = true;
    int dmg;
    // Start is called before the first frame update
    void Start()
    {
        dmg = 1;
    }
    
     //Update is called once per frame
    void Update()
    {
        if (transform.position.x < target.x)
        {
            goal = false;
        }

        if (goal == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
          
        }
        
        
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Destroy(this.gameObject);

            

        }

        if (other.gameObject.tag == "NinjaStern")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }

        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.gameManager._playerHealth.DmgUnit(1);
            Debug.Log("fick dich");
        }

    }

}
