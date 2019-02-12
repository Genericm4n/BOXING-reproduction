using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_sair : MonoBehaviour {

    public Button btn_S;
    Button btn;

    // Use this for initialization
    void Start() {

        btn = btn_S.GetComponent<Button>();
        btn.onClick.AddListener(ExitGame);

    }

    void ExitGame() {

        Application.Quit();
    }
}
