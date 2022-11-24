using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    public float starSpeed;
    public float rotationSpeed;
   // public new Vector3(1,0,0) rotation;
    public float rotx;
    public float roty;
    public float rotz;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * starSpeed);
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        //transform.Rotate(new Vector3(rotationSpeed, 0, 0));
        //rotx = transform.rotation.x;
        //roty = transform.rotation.y;
        //rotz = transform.rotation.z;
    }
}
