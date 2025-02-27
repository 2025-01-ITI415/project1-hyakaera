using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update
    public static float bottomY = -9f;
    public float destroyDelay = 2f; // Adjustable delete afte x sec



    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) {
            Destroy(gameObject, destroyDelay);
        }
    }
}
