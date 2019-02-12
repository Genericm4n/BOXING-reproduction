using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_Contador : MonoBehaviour {

    public Text text_min;
    public Text text_seg;

    int min = 1;
    int seg = 0;

    void Start() {

        StartCoroutine(Contar());
    }


    void Update() {

        text_min.text = min.ToString();
        text_seg.text = seg.ToString();

        if (min == 0 && seg == 0 && Script_pontuacao.pontos < Script_pontuacaoI.pontosI) {

            SceneManager.LoadScene("DEFEAT_S");
        }
        if (min == 0 && seg == 0 && Script_pontuacao.pontos > Script_pontuacaoI.pontosI) {

            SceneManager.LoadScene("VICTORY_S");
        }
        if (min == 0 && seg == 0 && Script_pontuacao.pontos == Script_pontuacaoI.pontosI) {

            SceneManager.LoadScene("DEFEAT_S");
        }
    }

    IEnumerator Contar() {

        yield return new WaitForSeconds(1.0f);
        if (min > 0)
        {
            min = min - 1;
        }

        if (seg == 0)
        {
            seg = 59;
        }

        seg = seg - 1;

        StartCoroutine(Contar());
    }
}
