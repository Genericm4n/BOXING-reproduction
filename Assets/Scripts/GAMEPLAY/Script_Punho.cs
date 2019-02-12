using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Punho : MonoBehaviour {

    // variaveis
    private bool singAttack;

    public static bool ataque_confirm = false;

	void Start () {

        singAttack = true;
	}
	
	void Update () {

        // input para o ataque
        if (Input.GetButtonDown("Jump") && singAttack == true) {

            ataque_confirm = true;
            singAttack = false;
            gameObject.GetComponent<Animator>().Play("J_jab");
        }
        else if (Input.GetButtonDown("Jump") && singAttack == false) {

            ataque_confirm = true;
            singAttack = true;
            gameObject.GetComponent<Animator>().Play("J_cross");
        }
	}

    void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag == "Inimigo")
        {

            Script_pontuacao.pontos++;
            Script_Inimigo.E_atacado = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {

        Script_Inimigo.E_atacado = false;
    }
}
