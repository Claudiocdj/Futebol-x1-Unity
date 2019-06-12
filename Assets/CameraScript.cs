using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour{

    public float smoothing = 0.2f;

    private GameObject ball;

    void Start(){
        ball = GameObject.FindWithTag("Ball");
    }

    private void Update() {

        Vector3 newPos = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, newPos, smoothing);

    }
}
