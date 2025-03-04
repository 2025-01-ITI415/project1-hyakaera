using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropper : MonoBehaviour
{

    [Header("Set In Inspector")]
    public GameObject EnemyPrefab;

    //dropper speed
    public float speed = 1f;

    //Distance dropper turns around
    public float leftAndRightEdge = 20f;

    //Chance that the dropper will chance direction
    public float changeDirChance = 0.1f;

// Second between point drop instantiations
    public float enemyDropDelay = 1f;

    // public GameObject PointPrefab { get => PointPrefab; set => PointPrefab = value; }


    // Start is called before the first frame update
    void Start()
    {
        //Apples dropping every second
        Invoke("DropEnemy", 2f);
    }

    void DropEnemy(){
        GameObject Enemy = Instantiate<GameObject>( EnemyPrefab );
        Enemy.transform.position = transform.position;
        Invoke( "DropEnemy", enemyDropDelay );
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        } 
    }
    void FixedUpdate(){
        if (Random.value < changeDirChance){
            speed *= -1;
        }
    }
}
