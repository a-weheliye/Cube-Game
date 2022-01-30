using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public GameManager gameManager;
    
    void OnCollisionEnter(Collision collision) {
        // // print("Landed on the " + collision.gameObject.name);
        // if (collision.collider.CompareTag("Platform")) {
        //     movement.enabled = false;
        // }
        // movement.enabled = true;
    }

    void OnCollisionStay(Collision collision) {
        // print("On the " + collision.gameObject.name);
    }


    void OnCollisionExit(Collision collision) {
        // print("Leaving the " + collision.gameObject.name);
    }
}
