using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public Lives lives;

    public float jumpForce = 5f;  // The force applied for jumping
    private bool isGrounded = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find( "ScoreCounter" );
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        GameObject livesGO = GameObject.Find("Main Camera");  
        // lives = livesGO.GetComponent<Lives>();
         if (livesGO != null)
        {
            lives = livesGO.GetComponent<Lives>();  // Get the reference to the Lives script
        }
        else
        {
            Debug.LogError("Main Camera GameObject not found or Lives script not attached!");
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;

        pos.x = mousePos3D.x;
        this.transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        
    }

    void Jump()
        {
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            
            isGrounded = false;
        }
    
    void OnCollisionEnter(Collision coll){
        GameObject collidedWith=coll.gameObject;
        if(collidedWith.CompareTag("Point")){
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
        }
        else if(collidedWith.CompareTag("Enemy")){

             // Remove one life from the Lives script
            if (lives != null)
            {
                lives.RemoveLife();  // Call the method to remove a life
            }
             else
            {
                Debug.LogError("Lives reference is null! Cannot remove life.");
            }
            scoreCounter.score -= 50;
            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
        }
        if (coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // The cat is on the ground and can jump again
        }


    }
    void OnCollisionExit(Collision coll)
    {
        // Check if the Cat has exited the ground
        if (coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // The cat is no longer on the ground, so it can't jump
        }
    }
}
