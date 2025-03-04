using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
 [Header("Inscribed")]
    public GameObject lifePrefab;
    public int numLives = 9;
    public float lifeBottomY = -8f;
    public float lifeSpacingX = 1f;
    public float lifeStartX = -8f;
    public float lifeZ = 6f;

    public List<GameObject> lifeList;
    // Start is called before the first frame update
    void Start()
    {
        lifeList = new List<GameObject>();
        for(int i = 0; i < numLives; i++){
            GameObject tlifeGO = Instantiate<GameObject>(lifePrefab);
            Vector3 pos = Vector3.zero;
            pos.y = lifeBottomY;
            pos.x = lifeStartX + lifeSpacingX * i;
            pos.z = lifeZ;
            tlifeGO.transform.position = pos;
            lifeList.Add( tlifeGO );
        }
        
    }

//         public void EnemyHit(){
//         GameObject[] enemyArray=GameObject.FindGameObjectsWithTag("Enemy");
//         foreach ( GameObject tempGO in enemyArray ) {
//             Destroy( tempGO );
//         }


//         // Destroy one of the Baskets
//         // Get the index of the last Basket in basketList
//         int lifeIndex = lifeList.Count -1;

//         // Get a reference to that Basket GameObject
//         GameObject lifeGO = lifeList[lifeIndex];


//         // Remove the Basket from the list and destroy the GameObject
//         lifeList.RemoveAt( lifeIndex );
//         Destroy( lifeGO );

// // If there are no Baskets left, restart the game 
//         if ( lifeList.Count == 0 ) {
//             SceneManager.LoadScene( "SampleScene" );


//         }
//     }

 public void RemoveLife()
    {
        if (lifeList.Count > 0)
        {
            int lifeIndex = lifeList.Count - 1;  // Get the index of the last life in the list
            GameObject lifeGO = lifeList[lifeIndex];  // Get the reference to that life GameObject
            lifeList.RemoveAt(lifeIndex);  // Remove the life from the list
            Destroy(lifeGO);  // Destroy the life GameObject
        }

        // If no lives remain, restart the game
        if (lifeList.Count == 0)
        {
            // Optionally, restart the scene or show game over
            SceneManager.LoadScene("SampleScene");
        }
    }
}
