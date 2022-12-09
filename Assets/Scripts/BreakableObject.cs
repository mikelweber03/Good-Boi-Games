using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    public GameObject fractured;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
            BreakTheThing();
    }

    private void BreakTheThing()
    {
        Instantiate(fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
