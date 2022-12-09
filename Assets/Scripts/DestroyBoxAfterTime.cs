using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxAfterTime : MonoBehaviour
{
    private float ShrinkDuration = 5f;
    private Vector3 TargetScale = Vector3.one * 0.1f;
    Vector3 startScale;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        t = 0;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime / ShrinkDuration;
        Vector3 newScale = Vector3.Lerp(startScale, TargetScale, t);
        transform.localScale = newScale;
    }

    //IEnumerator Smalling()
    //{
    //    yield return new WaitForSeconds(1);
    //    transform.localScale
    //}
}
