using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public GameObject bulledLeft;
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TurredFire", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    void TurredFire()
    {
        
        
         Instantiate(bulledLeft, transform.position, transform.rotation);
        
    }
}
