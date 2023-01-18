using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controls : MonoBehaviour {

    //public vars
    public string sceneName;
    public float inputCounter;
    public float inputLength = 0.5f;
    public int currGame;
    public bool hasController;
    public string[] currentControllers;
    public GameObject[] touch;

    //private vars
    private int gameNum;
    private arcadeGames acg;
    private uiManager uim;

    void Awake() {

        if(acg == null) {

            acg = GetComponent<arcadeGames>();

        }

        if (uim == null) {

            uim = GetComponent<uiManager>();

        }

    }

	// Use this for initialization
	void Start () {

        //Get current scene name
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        for (int i = 0; i < touch.Length; i++) {
            touch[i].SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {

        hasController = checkForController();

#if UNITY_ANDROID 
        
        for (int i = 0; i < touch.Length; i++) {
            touch[i].SetActive(!hasController);
        }
#endif
        
        switch (sceneName) {

            //testing scene
            case "test":

                scrollThruArcadeMenu();

                break;

        }
		
	}

    //scroll thru the list of arcade games
    void scrollThruArcadeMenu(){

        gameNum = acg.game.Count;
        acg.changeGame(currGame);

        if (inputCounter <= 0) {
            if (currGame <= gameNum) {
                if (Input.GetAxisRaw("Horizontal") == 1) {

                    currGame += 1;
                    inputCounter = inputLength;
                    if (currGame > gameNum){
                        currGame = gameNum;
                    }else if (currGame < 1){
                        currGame = 1;
                    }

                    acg.changeGame(currGame);

                }
                else if (Input.GetAxisRaw("Horizontal") == -1) {

                    currGame -= 1;
                    inputCounter = inputLength;

                    if (currGame > gameNum){
                        currGame = gameNum;
                    }else if (currGame < 1){
                        currGame = 1;
                    }

                    acg.changeGame(currGame);

                }

            }
        } else {

            inputCounter -= Time.deltaTime;

        }

        if (Input.GetButtonDown("Fire1")) {

            SceneManager.LoadScene(acg.game[currGame].scene);

        }

    }

    //access the game

    //check for the controller
    bool checkForController() {

        System.Array.Clear(currentControllers, 0, currentControllers.Length);
        System.Array.Resize<string>(ref currentControllers, Input.GetJoystickNames().Length);

        for (int i = 0; i < Input.GetJoystickNames().Length; i++) {
            currentControllers[i] = Input.GetJoystickNames()[i].ToLower();

            if (currentControllers[i].Length <= 0) {
                return false;
            }

        }

        if (currentControllers.Length > 0) {
            return true;
        } else {
            return false;
        }


    }

}
