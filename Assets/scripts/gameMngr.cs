using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMngr : MonoBehaviour {

    public static gameMngr gm;

    void Awake() {

        if (gm == null) {

            DontDestroyOnLoad(gameObject);
            gm = this;

        } else if(gm != this) {

            Destroy(gameObject);

        }

    }
}
