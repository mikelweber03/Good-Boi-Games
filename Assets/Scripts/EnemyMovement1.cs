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
    

    public BoxCollider playerBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        

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

}

