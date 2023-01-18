using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[Serializable]
public class gamesList : IComparable<gamesList> {

    public int id;
    public string name;
    public string desc;
    public string scene;

    public gamesList(int id, string name, string desc, string scene)
    {
        this.id = id;
        this.name = name;
        this.desc = desc;
        this.scene = scene;
    }

    public int CompareTo(gamesList other)
    {
        if (other == null) {
            return 1;
        }

        return id;
    }
}

public class arcadeGames : MonoBehaviour {

    //public vars
    public List<gamesList> game = new List<gamesList>();
    public gamesList gl;

    //private vars
    private uiManager uim;

    void Start() {

        if(uim == null) {

            uim = GetComponent<uiManager>();

        }

        addGameToList(1, "World Def'er", "<b>World Def'er</b> \n This is the game", uim.wdScene);
        
    }

    public void addGameToList(int id, string name, string desc, string scene)
    {

        game.Add(new gamesList(id, name, desc, scene));

    }

    public void changeGame(int id) {

        switch (id) {

            case 1:
            case 0:
                uim.changeDescDetail(uim.wdTxt, uim.wdImg, uim.wdClip);
                break;

        }

    }
}
