using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_pontuacaoI : MonoBehaviour {

    // variaveis
    public static int pontosI;

    public Text pont_textI;

    void Start() {

        // comecar a partida com a pontuacao zerada
        pontosI = 0;
    }

    void Update(){

        pont_textI.text = pontosI.ToString();
    }
}

