using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] PickupType itemType;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CollectPickup(collision, itemType);

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CollectPickup(Collider collision, PickupType type)
    {
        Destroy(this.gameObject);
        switch (type)
        {
            case PickupType.healthpickup:
                Debug.Log("Hit");
                Debug.Log(collision.gameObject.name);
                break;
            case PickupType.damagepickup:
                break;
            default:
                Debug.Log("Wtf");
                break;
        }
        

    }
    public enum PickupType
    {
        healthpickup, damagepickup
    }
        
      
        

}