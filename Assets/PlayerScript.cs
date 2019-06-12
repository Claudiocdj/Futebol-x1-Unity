using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float speed = 5f;

    public float jumpForce = 5f;

    public float kickForce = 5f;

    private Rigidbody2D myRb;

    private bool canJump = true;

    void Start() {
        myRb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate() {
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
        
        if(Input.GetAxis("Vertical") > 0 && canJump) {
            myRb.AddForce(Vector2.up * jumpForce * 1000000);

            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
            canJump = true;
    }
}
