using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBulletLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 10 * Time.deltaTime);
    }
}
