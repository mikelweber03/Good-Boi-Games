using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    public float starSpeed;
    public float rotationSpeed;
    private Rigidbody ninjaStar;
 

    // Start is called before the first frame update
    void Start()
    {
        ninjaStar = GetComponent<Rigidbody>();
        ninjaStar.AddRelativeForce(starSpeed, 0, 0, ForceMode.Impulse);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(Vector3.forward * Time.deltaTime * starSpeed);
        //transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        
    }

    

}
