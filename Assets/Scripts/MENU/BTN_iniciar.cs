using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BTN_iniciar : MonoBehaviour {

    public Button btn_I;
    Button btn;

    // Use this for initialization
    void Start() {

        btn = btn_I.GetComponent<Button>();
        btn.onClick.AddListener(EnterGame);
    }
	
    void EnterGame() {

        SceneManager.LoadScene("TUTORIAL_S");
    }
}
