using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    public int kills;

    void Update () {
        Gun gun = (Gun)FindObjectOfType(typeof(Gun));
        kills = gun.myTargets;
        print(kills);
	}
}
