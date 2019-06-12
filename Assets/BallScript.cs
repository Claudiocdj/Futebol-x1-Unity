using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Rigidbody2D myRb;

    void Start() {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        Debug.Log(myRb.velocity);

        if (myRb.velocity.x > 6f)
            myRb.velocity = new Vector2(6f, myRb.velocity.y);

        if (myRb.velocity.y > 10f)
            myRb.velocity = new Vector2(myRb.velocity.x, 10f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            float kickForce = other.gameObject.GetComponent<PlayerScript>().kickForce;

            Vector2 difference = transform.position - other.transform.position;

            difference = difference.normalized * kickForce;

            myRb.AddForce(difference, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            float kickForce = other.gameObject.GetComponent<PlayerScript>().kickForce;

            myRb.AddForce(Vector2.up * kickForce, ForceMode2D.Impulse);
        }
    }
}
