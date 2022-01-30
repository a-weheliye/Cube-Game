using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformCircular : MonoBehaviour {
    public float timeCount = 0;
    public float speed = 2;
    public float length = 3;
    public float width = 3;
    public float origin;
    
    // Start is called before the first frame update
    // void Start() {
    //     speed = 2;
    //     length = 3;
    //     width = 3;
    // }

    // Update is called once per frame
    void Update() {
        timeCount += Time.deltaTime * speed;

        float x = Mathf.Sin(timeCount) * width;
        float y = 0;
        float z = Mathf.Cos(timeCount) * length;

        transform.position = new Vector3(x, y, z) + new Vector3(0, 0, origin);
    }
}
