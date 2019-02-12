using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair_Scene : MonoBehaviour {

    private bool continuar = false;            // variavel para o jogador esperar alguns segundos para poder sair da cena

    void FixedUpdate() {

        StartCoroutine(Espera());

        if (Input.anyKey && continuar) {

            SceneManager.LoadScene("CREDITS_S");
        }
    }

    IEnumerator Espera() {

        yield return new WaitForSeconds(6.0f);

        continuar = true;
    }
}
