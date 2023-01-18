using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

    //public vars
    public Text descTXT;
    public Image img;
    public AudioSource audSrc;

    //private vars

    //game stuff
        //world defer
        public string wdTxt = "<b>World Def'er</b> \n This is the game";
        public Sprite wdImg;
        public AudioClip wdClip;
        public string wdScene = "WorldDefer";

    public void changeDescDetail(string details, Sprite thumb, AudioClip track) {

        descTXT.text = details;
        img.sprite = thumb;
        audSrc.clip = track;
        audSrc.Play();

    }
}
