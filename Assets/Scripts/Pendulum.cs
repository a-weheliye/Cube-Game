using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {
    public Rigidbody axe;
    public float leftPushRange;
    public float rightPushRange;
    public float velocityThreshold;
    private void Start() {
        // axe = GetComponent<Rigidbody>()
        axe = GetComponent<Rigidbody>();
    }

    private void Update() {
        
        
    }
}
