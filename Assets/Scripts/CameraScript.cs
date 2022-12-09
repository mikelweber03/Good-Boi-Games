using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
       
       player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y);
    }
}
