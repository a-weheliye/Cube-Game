using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwing : MonoBehaviour {
    
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    public float direction = 1;
    private Quaternion startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.rotation;
        // print("StartPos = " + startPos);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion a = startPos;
        a.w += direction * (delta * Mathf.Sin(Time.time * speed));
        transform.rotation = a;
        // print(a.eulerAngles);
    }
}


// transform.rotation = Quaternion.Lerp (qStart, qEnd,(Mathf.Sin(startTime * speed + Mathf.PI/2) + 1.0f)/ 2.0f);