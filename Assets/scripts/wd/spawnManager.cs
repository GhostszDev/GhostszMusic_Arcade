using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour {

    public GameObject _spawn;
    public GameObject _deathBox;
    public GameObject[] spawnPoint;
    public GameObject[] enemy;
    public GameObject[] deathBox;
    public Vector3[] pos;
    public float maxLeft;
    public float maxRight;
    public float count;
    public float defaultCount;
    public int shipRoll;
    public int spawnRoll;

    // Use this for initialization
    void Start () {

        getObjects();
        setPos();

    }
	
	// Update is called once per frame
	void Update () {

        if(count > 0) {
            count -= Screen.height / 25 * Time.deltaTime;
        } else if(count <= 0) {
            count = 0;
            spawnEnemy();
        }

    }

    void setPos() {

        defaultCount = 50.0f;
        count = defaultCount;

        maxRight = (Screen.width / 4f) - 70;
        maxLeft = -maxRight;

        pos = new Vector3[3];
        pos[0] = new Vector3(maxLeft, 0, 0);
        pos[1] = Vector3.zero;
        pos[2] = new Vector3(maxRight, 0, 0);

        _spawn.transform.localPosition = new Vector3(0, Screen.height / 2 - 75, 0);

        spawnPoint[0].transform.localPosition = pos[0];
        spawnPoint[1].transform.localPosition = (spawnPoint[0].transform.localPosition + spawnPoint[2].transform.localPosition) / 2;
        spawnPoint[2].transform.localPosition = pos[1];
        spawnPoint[3].transform.localPosition = spawnPoint[1].transform.localPosition * -1;
        spawnPoint[4].transform.localPosition = pos[2];

        deathBox[0].transform.localPosition = new Vector3(0, 8f, 0);
        deathBox[1].transform.localPosition = -deathBox[0].transform.localPosition;

    }

    void getObjects() {

        _spawn = GameObject.FindGameObjectWithTag("spawn");
        _deathBox = GameObject.FindGameObjectWithTag("deathBox");

        spawnPoint = new GameObject[_spawn.transform.childCount];
        deathBox = new GameObject[_deathBox.transform.childCount];

        for (int i = 0; i < _spawn.transform.childCount; i++) {

            spawnPoint[i] = _spawn.transform.GetChild(i).gameObject;

        }

        for (int i = 0; i < _deathBox.transform.childCount; i++) {

            deathBox[i] = _deathBox.transform.GetChild(i).gameObject;

        }
    }

    void spawnEnemy() {

        spawnRoll = Random.Range(1, spawnPoint.Length + 1);

        shipRoll = Random.Range(1, (enemy.Length * 3) + 1);

        switch (shipRoll) {
            case 1:
            case 2:
            case 3:
            case 4:
                Instantiate(enemy[0], spawnPoint[spawnRoll - 1].transform.position, Quaternion.identity, spawnPoint[spawnRoll - 1].transform);
                break;

            case 5:
            case 6:
            case 7:
                Instantiate(enemy[1], spawnPoint[spawnRoll - 1].transform.position, Quaternion.identity, spawnPoint[spawnRoll - 1].transform);
                break;

            case 8:
            case 9:
                Instantiate(enemy[2], spawnPoint[spawnRoll - 1].transform.position, Quaternion.identity, spawnPoint[spawnRoll - 1].transform);
                break;
        }


        count = defaultCount;

    }
}
