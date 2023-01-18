using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class player_controller : MonoBehaviour {

    public float speed;
    public float fireTimer;
    public float maxTimer;
    public string shipName;
    public float invTimer;
    public int lives;
    public GameObject ship;
    public GameObject cannon;
    public GameObject bulletPrefab;
    public GameObject purpleShip;
    public GameObject bullet;
    public GameObject explode;
    public GameObject ex;
    public BoxCollider2D bc;
    public Rigidbody2D rb;
    public scoreManager sm;
    public AudioClip audExplode;

    //gameover stats screen
    public GameObject _gameOverScreen;
    public Text hsTEXT;

	// Use this for initialization
	void Start () {

        lives = 3;
        maxTimer = 0.3f;
        fireTimer = maxTimer;
        speed = 7f;

        if (sm == null) {
            sm = GameObject.FindGameObjectWithTag("manager").GetComponent<scoreManager>();
        }

        if (rb == null) {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        if(ship == null) {
            spawn("");
        }

        if(bc == null) {
            bc = gameObject.GetComponent<BoxCollider2D>();
        }

        invTimer = 0;
        sm.updateLife(lives);
        _gameOverScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        movement(Input.GetAxis("Horizontal"));

        if(fireTimer > 0) {
            fireTimer -= 1 * Time.deltaTime;
            if(fireTimer <= 0) {
                fireTimer = 0;
            }
        }

        if (Input.GetButtonDown("Fire1") && fireTimer <= 0) {
            fire();
        }

        sm.currentLives(lives);

        if (invTimer > 0 && ship != null) {
            invTimer -= 1 * Time.deltaTime;
        } else if (invTimer <= 0 && ship == null) {
            spawn("");
        }

        if (ship == null) {
            bc.enabled = false;
        } else {
            bc.enabled = true;
        }

        if (_gameOverScreen.activeInHierarchy)  {

            if (Input.GetButtonDown("Jump")) {

                SceneManager.LoadScene("test");

            }

        }

    }

    void spawn(string s) {

        if (lives <= 1) {

            gameOver();

        } else { 

            if (invTimer == 0) {

                Debug.Log("ship spawn");
                switch (s) {

                    default:
                        ship = Instantiate(purpleShip, gameObject.transform);
                        break;

                }

                cannon = ship.transform.GetChild(0).gameObject;
                invTimer = maxTimer;
            }
        }

    }

    void movement(float h) {

        
        rb.velocity = new Vector2(h * speed * (Screen.width / 30) * Time.deltaTime, 0);

    }

    void fire() {
        Instantiate(bulletPrefab, cannon.transform.position, Quaternion.identity, ship.transform);
        fireTimer = maxTimer;
    }

    public void death() {
        lives -= 1;
        ex = Instantiate(explode, transform.position, Quaternion.identity, this.gameObject.transform.parent.gameObject.transform);
        Destroy(ship);

    }

    void gameOver() {
        _gameOverScreen.SetActive(true);
        hsTEXT.text = "\n Your final score: " + sm.score + "\n \n If you enjoy this demo make sure that you check out GhostszMusic.com and sign up for access to the global beta!";

    }
}
