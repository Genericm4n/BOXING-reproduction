using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Inimigo : MonoBehaviour {

    // variavel para quando for atacado
    public static bool E_atacado = false;

    // alvo e sensor para detectar o corpo do oponente
    public GameObject personagem;

    // variaveis para a movimentacao
    public float velocidade = 2.0f;
    public float limite = 0.0f;

    // variaveis para o ataque
    private bool ataque_1 = false;

    // variavel para o inimigo virar
    public static bool virar_P2 = false;

    // variavel de som
    public AudioClip P2_som_ataque;
    private AudioSource P2_som;

    void Start() {

        personagem = GameObject.Find("P1_J");

        StartCoroutine(Golpear());

        P2_som = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update(){

        // Calcula a distancia entre a camera e o personagem
        float distancia = Vector3.Distance(personagem.transform.position, transform.position);

        if (distancia > limite) {

            Vector3 posicao = new Vector3(personagem.transform.position.x, personagem.transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, posicao, velocidade * Time.deltaTime);
        }

        P2_Atacado();
        P2_Virando();
    }

    IEnumerator Golpear() {

        yield return new WaitForSeconds(1.0f);

        gameObject.GetComponent<Animator>().Play("P2_jab");
        ataque_1 = true;

        if (ataque_1) {

            yield return new WaitForSeconds(1.0f);
            ataque_1 = false;
            gameObject.GetComponent<Animator>().Play("P2_cross");
        }

        StartCoroutine(Golpear());
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "SENSOR_P1") {

            // condições de contagem de pontos a favor do P2
            Script_pontuacaoI.pontosI++;
            Script_Personagem.atacado = true;
            P2_som.clip = P2_som_ataque;
            P2_som.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {

        Script_Personagem.atacado = false;
    }

    void P2_Atacado() {

        // Jogador P2 levando dano
        if (E_atacado) {

            gameObject.GetComponent<Animator>().Play("P2_damage");
        }
    }

    void P2_Virando () {

        if (transform.position.x < -2) {

            virar_P2 = true;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }
        else if (transform.position.x > 2 && virar_P2) {

            virar_P2 = false;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}