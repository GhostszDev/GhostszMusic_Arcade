using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    public int score;
    public float us;
    public int life;
    public GameObject ship;
    public Text scoreTXT;
    public Text lifeTXT;

	// Use this for initialization
	void Start () {

        score = 0;
        life = 0;

    }
	
	// Update is called once per frame
	void Update () {

        if (life > 1) {
            us += 1 * Time.deltaTime;
        }

        score = Mathf.FloorToInt(us);
        scoreTXT.text = score.ToString();
        lifeTXT.text = "*" + life;
    }

    public void updateScore(int s) {

        us += s;

    }

    public void updateLife(int l) {

        life += l;

    }

    public void currentLives(int l) {

        life = l;

    }
}
