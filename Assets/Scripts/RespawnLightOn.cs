using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLightOn : MonoBehaviour
{
    Light respawnLight;
    // Start is called before the first frame update
    void Start()
    {
        respawnLight = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawnLight.enabled = true;

        }
    }
}
