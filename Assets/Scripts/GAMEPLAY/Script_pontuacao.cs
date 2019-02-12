using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_pontuacao : MonoBehaviour {

    // variaveis
    public static int pontos;

    public Text pont_text;

    void Start() {

        // iniciar a partida com a pontuacao zerada

        pontos = 0;
    }

    void Update() {

        pont_text.text = pontos.ToString();
    }
}
