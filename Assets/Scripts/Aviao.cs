using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{
    private Rigidbody2D fisica;
    [SerializeField]
    private Rigidbody2D fisicaInicial;
    private Vector3 posicaoInicial;
    private float forca = 3;
    private bool alive = true;
    private int pontuacao = 0;

    [SerializeField]
    private GameObject imagemGameOver;
    private GameObject scoreTextObj;
    private AudioSource audioPontuacao;
    

    public bool isAlive()
    {
        return alive;
    }

    private void Awake(){
        fisica = this.GetComponent<Rigidbody2D>();

        this.posicaoInicial = this.transform.position;
        scoreTextObj = GameObject.FindWithTag("Score");
        this.audioPontuacao = this.GetComponent<AudioSource>();
        
        
    }

    public void pontuar() { 
        pontuacao += 100; 
        this.audioPontuacao.Play();
        }

    public int checarPontuacao() { return pontuacao; }

    // Update is called once per frame
    private void Update()
    {
       if (fisica.bodyType != RigidbodyType2D.Static && isAlive())
       {
            if (Input.GetButtonDown("Fire1"))
            {
                this.Impulsionar();
            }
       }

        else
        {
            fisica.constraints = RigidbodyConstraints2D.FreezePosition;
            this.imagemGameOver.SetActive(true);

        }
    }

    private void Impulsionar(){
        fisica.velocity = Vector2.zero;
        fisica.AddForce(Vector2.up * this.forca , ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "chao" ||
            collision.gameObject.name == "Obstaculo(Clone)" || 
            collision.gameObject.name == "projetil(Clone)" || 
            collision.gameObject.name == "missile(Clone)" 
            ) 
        {
            alive = false;
        }
    }

        public void Reiniciar()
        {
            pontuacao = 0;
            alive = true;
            this.DestruirObstaculos();
            this.imagemGameOver.SetActive(false);
            this.transform.position = this.posicaoInicial;
            fisica.constraints = RigidbodyConstraints2D.None;
            transform.rotation = Quaternion.identity;
            fisica.velocity = Vector2.zero;
            fisica.velocity = Vector3.zero;
            fisica.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            TMPro.TextMeshProUGUI scoreTextMesh = scoreTextObj.GetComponent<TMPro.TextMeshProUGUI>();
            scoreTextMesh.text = "Score: " +  this.checarPontuacao() ;
        }

        private void DestruirObstaculos(){
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach(Obstaculo obstaculo in obstaculos){
            obstaculo.Destruir();
        }

        Missile[] missiles = GameObject.FindObjectsOfType<Missile>();
        foreach(Missile missile in missiles){
            missile.Destruir();
        }

        Projetil[] projeteis = GameObject.FindObjectsOfType<Projetil>();
        foreach(Projetil projetil in projeteis){
            projetil.Destruir();
        }
    }
}
