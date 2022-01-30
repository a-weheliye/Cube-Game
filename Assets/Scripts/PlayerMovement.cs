using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public bool playerOnGround = true;
    public bool playerOnPlatform = false;
    public float repositionSpeed;
    
    public bool hitByWeapon = false;
    public bool reachedEnd = false;


    private float max_z;
    public Transform parent;
 

    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        max_z = 0;
    }

    // Update is called once per frame
    void Update() {
        
        if (Input.GetKey("w") && (playerOnGround || playerOnPlatform)) {
            rb.AddForce(0, 5.5f,5, ForceMode.VelocityChange);
            playerOnGround = false;
            playerOnPlatform = false;
        }
        
        if (Input.GetKey("s") && (playerOnGround || playerOnPlatform)) {
            rb.AddForce(0, 5.5f,-5, ForceMode.VelocityChange);
            playerOnGround = false;
            playerOnPlatform = false;
        }
        
        if (Input.GetKey("a") && (playerOnGround || playerOnPlatform)) {
            rb.AddForce(-5, 5.5f,0, ForceMode.VelocityChange);
            playerOnGround = false;
            playerOnPlatform = false;
        }
        
        
        if (Input.GetKey("d") && (playerOnGround || playerOnPlatform)) {
            rb.AddForce(5, 5.5f,0, ForceMode.VelocityChange);
            playerOnGround = false;
            playerOnPlatform = false;
        }


        if (Input.GetKeyDown("space") && (playerOnGround || playerOnPlatform)) {
            rb.AddForce(0, 5.5f,5, ForceMode.VelocityChange);
            playerOnGround = false;
            playerOnPlatform = false;
        }
        
        StartCoroutine(Reposition());
        CheckIfGameOver();

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            playerOnGround = true;
        } else if (collision.collider.CompareTag("Platform")) {
            playerOnPlatform = true;
        }
        else if (collision.collider.CompareTag("Weapon")) {
            print("Hit Weapon" + collision.gameObject.name);
            hitByWeapon = true;
            return;
        } else if (collision.collider.CompareTag("Finish")) {
            ScoreScript.ScoreValue += 15;
            reachedEnd = true;
        }


        float distance = Vector3.Distance (collision.collider.transform.position,rb.transform.position);


        if (Math.Abs(1-distance) < 0.5 && collision.collider.CompareTag("Platform")) {
            // rb.transform.parent = collision.transform;
            if (transform.position.z > max_z) {
                ScoreScript.ScoreValue += 10;
                max_z = transform.position.z;
            }
            
        }
        // print("Adjusting Position:" + rb.transform.localPosition);
        
    }


    private void OnCollisionExit(Collision collision) {
        playerOnGround = false;
        playerOnPlatform = false;
        rb.transform.parent = null;
    }


    void CheckIfGameOver() {
        if (rb.position.y < 0 || hitByWeapon) {
            FindObjectOfType<GameManager>().EndGame();
        }
        
        if (reachedEnd) {
            FindObjectOfType<GameManager>().CompletedLevel();
        }
    }


    IEnumerator Reposition() {
        float totalMovementTime = 5f; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed

        while (Vector3.Distance(transform.position, parent.position) > 0.05  &&  playerOnPlatform) {
            currentMovementTime += Time.deltaTime;
            rb.transform.localPosition = Vector3.MoveTowards(rb.transform.localPosition,new Vector3(0, 1, 0), currentMovementTime / totalMovementTime);
            yield return null;
        }
    }
    
}
