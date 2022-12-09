using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxScript : MonoBehaviour
{
    private int health = 3;
    public AudioSource Boxhit;
    public GameObject crate_Des;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Sword")
            {
                Debug.Log("healthSword");
                //Boxhit.Play();
                health--;




                    if (health == 0)
                    {
                    
                    
                    Destroy(gameObject);
                    Debug.Log("Death");
                    }

            }
            if (other.gameObject.tag == "NinjaStern")
            {
                    Debug.Log("healthStern");
                    //Boxhit.Play();
                    health--;
                    Destroy(other.gameObject);



                    if (health == 0)
                    {

                        BoxSwap();
                        Destroy(gameObject);
                        
                        Debug.Log("Death");
                    }

            }
    }
    private void BoxSwap()
    {
        Instantiate(crate_Des, transform.position, transform.rotation);
    }

    }

