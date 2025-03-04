using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static float bottomY = -12f;
    public static float ground = -9f;


    public float destroyDelay = 2f; 
    // Adjustable delete afte x sec




    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY){
            Destroy(gameObject);
            
        }
        else if (transform.position.y < ground){
             Destroy(gameObject,destroyDelay);

        }
    }
}
