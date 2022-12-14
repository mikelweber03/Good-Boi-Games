using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLantern : MonoBehaviour
{
    public GameObject spawnHP;
    void Start()
    {
        
    }

    //Destroys Lantern if hit by sword or Shuriken and spawns health pickup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Destroy(this.gameObject);

            //float f = Random.Range(1, 2);
            //if(f < 2)
            //{
            Instantiate(spawnHP, transform.position, transform.rotation );
            //}

        }

        if (other.gameObject.tag == "NinjaStern")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            // float f = Random.Range(1, 2);
            // if (f < 2)
            //  {
            Instantiate(spawnHP, transform.position, transform.rotation);
            //Instantiate(spawnHP, this.gameObject.transform);
            // }
        }


    }
}
