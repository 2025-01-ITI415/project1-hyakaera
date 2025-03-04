using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float collideDelay = 2f;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.CompareTag("Enemy")){
            Debug.Log("Enemy hit! Destroying...");
            Destroy(collidedWith, collideDelay);
        }
    }
}
