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

    private Vector3 start;
   // public BoxCollider playerBoxCollider;
    void Start()
    {
        start.x = transform.position.x;

       // playerBoxCollider = GameObject.FindWithTag("Player").GetComponent<BoxCollider>();
    }

    
    void Update()
    {   //If the enemy is at the target vector, set goal to false
        if (transform.position.x < target.x)
        {
            goal = false;
        }
        //If the nemy isn't at target vector, make him go left towards it
        if (goal == true)
        {
            
            
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            
                
            
        }
        else 
        {
            if (transform.position.x <= start.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
                goal = true;
            
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

}

