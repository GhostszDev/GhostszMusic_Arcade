using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class enemy : MonoBehaviour {

    public string ship;
    public float speed;
    public int health;
    public int score;
    public bool dmg;
    public Rigidbody2D rb;
    public GameObject explode;
    public AudioClip audExplode;
    public scoreManager sm;

	// Use this for initialization
	void Start () {

        if(sm == null) {
            sm = GameObject.FindGameObjectWithTag("manager").GetComponent<scoreManager>();
        }

        ship = this.gameObject.name;
        scaleShip();
        speed = 7f;
        neededItems();

        switch (ship) {

            case "goldShip":
            case "goldShip(Clone)":
                health = 1;
                score = 100;
                break;

            case "fuchsiaShip":
            case "fuchsiaShip(Clone)":
                health = 2;
                score = 200;
                break;

            case "redShip":
            case "redShip(Clone)":
                health = 3;
                score = 300;
                break;

        }

    }
	
	// Update is called once per frame
	void Update () {

        switch (ship) {

            case "goldShip":
            case "goldShip(Clone)":
                goldShip();
                break;

            case "fuchsiaShip":
            case "fuchsiaShip(Clone)":
                fuchsiaShip();
                break;

            case "redShip":
            case "redShip(Clone)":
                redShip();
                break;

        }

    }

    void scaleShip() {
        this.gameObject.transform.localScale = new Vector3(Screen.width/50, Screen.width / 50, 0);
    }

    void goldShip() {
        rb.isKinematic = false;
        rb.velocity = new Vector2(0f, (speed * Screen.height / 40 * -1) * Time.deltaTime);
    }

    void fuchsiaShip() {
        rb.isKinematic = false;
        rb.velocity = new Vector2(0f, (speed * Screen.height / 42 * -1) * Time.deltaTime);
    }

    void redShip() {
        rb.isKinematic = false;
        rb.velocity = new Vector2(0f, (speed * Screen.height / 44 * -1) * Time.deltaTime);
    }

    void neededItems() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        if (rb == null) {
            this.gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0;

    }

    void death() {

        Instantiate(explode, transform.position, Quaternion.identity, this.gameObject.transform.parent.gameObject.transform);
        Destroy(this.gameObject);

    }

    public void hurt(int h) {

        health -= h;

        if (health <= 0) {
            sm.updateScore(score);
            death();
        }

    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "Player") {
            death();
            other.gameObject.GetComponent<player_controller>().death();
        }

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "deathBoxBottom") {
            death();
        }

    }
}
