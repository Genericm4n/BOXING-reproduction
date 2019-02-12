using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Personagem : MonoBehaviour {

    public float vel = 4.0f;                    // Velocidade do caminhar do personagem
    float MoveX, MoveY;                         // Variavel para o movimento do personagem

    public static bool atacado = false;         // Variavel para detectar o ataque do inimigo
    private bool singAttack;                    // variavel para ataque unico
    public static bool virar_P1 = false;        // variavel para o personagem virar

    public AudioClip som_ataque;                // variavel de som para caso o jogador acerte o inimigo


    // Componentes
    private Rigidbody2D rb2d;
    private AudioSource som;

    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        som = GetComponent<AudioSource>();
	}
	
	void Update () {

        // input para movimentação do jogador
        MoveX = vel*Input.GetAxisRaw("Horizontal");
        MoveY = vel*Input.GetAxisRaw("Vertical");

        // input para o ataque do jogador
        if (Input.GetButtonDown("Jump") && singAttack == true) {

            singAttack = false;
            gameObject.GetComponent<Animator>().Play("P1_jab");
        }
        else if (Input.GetButtonDown("Jump") && singAttack == false) {

            singAttack = true;
            gameObject.GetComponent<Animator>().Play("P1_cross");
        }

        P1_Atacado();
        P1_Virar();
    }

    void FixedUpdate(){

        //mover
        rb2d.velocity = new Vector2 (MoveX, MoveY);
 
    }

    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "SENSOR_P2")  {

            // condições de contagem de pontos a favor do P1
            Script_pontuacao.pontos++;
            Script_Inimigo.E_atacado = true;
            som.clip = som_ataque;
            som.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {

        Script_Inimigo.E_atacado = false;
    }

    void P1_Atacado() {

        // Jogador levando dano
        if (atacado) {

            gameObject.GetComponent<Animator>().Play("P1_damage");
        }
    }

    void P1_Virar() {

        if (transform.position.x > 2) {

            virar_P1 = true;

            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }
        else if (transform.position.x < -2 && virar_P1) {

            virar_P1 = false;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
