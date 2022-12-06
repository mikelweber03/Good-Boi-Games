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
    
    public BoxCollider playerBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        dmg = 1;

        playerBoxCollider = GameObject.FindWithTag("Player").GetComponent<BoxCollider>();
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
            
            TakeDmg();
            Debug.Log(collision.contactCount);
            //Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
        
        
    }

    IEnumerator TakeDmg()
    {
        
        //GameManager.gameManager._playerHealth.DmgUnit(dmg);
        //Debug.Log(GameManager.gameManager._playerHealth.Health);
       // playerBoxCollider.enabled = false;
        yield return new WaitForSeconds(1);
        //playerBoxCollider.enabled = true;
        Debug.Log(GameManager.gameManager._playerHealth.Health);
    }

}