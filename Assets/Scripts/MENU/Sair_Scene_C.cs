using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair_Scene_C : MonoBehaviour {

	void Update () {

        if (Input.anyKey) {

            SceneManager.LoadScene("MENU_S");
        }
    }
}
