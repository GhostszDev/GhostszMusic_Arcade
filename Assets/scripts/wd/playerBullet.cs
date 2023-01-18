using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerBullet : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;

    void bulletMove() {
        rb.velocity = new Vector2(0, (speed * Screen.height / 30) * Time.deltaTime);
    }

    // Use this for initialization
    void Start () {

        if(rb == null) {
            rb = gameObject.GetComponent<Rigidbody2D>();

            if(rb == null) {
                gameObject.AddComponent<Rigidbody2D>();
                rb = gameObject.GetComponent<Rigidbody2D>();
            }
        }

        rb.gravityScale = 0.0f;
        speed = 7f;
		
	}
	
	// Update is called once per frame
	void Update () {
        bulletMove();

    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.tag == "enemy") {
            coll.gameObject.SendMessageUpwards("hurt", 1);
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "deathBoxTop") {
            Destroy(gameObject);
        }

    }
}
