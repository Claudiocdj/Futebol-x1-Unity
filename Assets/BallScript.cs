using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private Rigidbody2D myRb;

    void Start() {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            float kickForce = other.gameObject.GetComponent<PlayerScript>().kickForce;

            Vector2 difference = transform.position - other.transform.position;

            difference = difference.normalized * kickForce;

            myRb.AddForce(difference, ForceMode2D.Impulse);
        }
    }
}
