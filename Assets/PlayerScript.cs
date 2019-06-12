using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed = 5f;

    public float jumpForce = 0.1f;

    public float kickForce = 5f;

    private Rigidbody2D myRb;

    void Start() {
        myRb = GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
        
        if(Input.GetAxis("Vertical") > 0) {
            myRb.AddForce(Vector2.up * jumpForce);
        }
    }
}
