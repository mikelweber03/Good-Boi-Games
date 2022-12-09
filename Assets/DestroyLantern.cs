using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLantern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
