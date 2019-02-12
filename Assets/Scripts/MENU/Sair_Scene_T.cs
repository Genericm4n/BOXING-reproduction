using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair_Scene_T : MonoBehaviour {
	
	void Update () {
		
        if (Input.anyKey) {

            SceneManager.LoadScene("GAME_S");
        }
	}
}
