using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    private Vector3 posicaoInicial ;
    private float tamanhoDaImagem;
    private float tamanhoRealDaImagem;
    private GameObject gObj;

    private void Start()
    {
        gObj = GameObject.Find("aviao1");
    }

    private void Awake(){
        this.posicaoInicial = this.transform.position;
        this.tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x;
        float escala = this.transform.localScale.x;
        this.tamanhoRealDaImagem = tamanhoDaImagem * escala;
    }

    // Update is called once per frame
    void Update()
    {
        bool isPlaneAlive = gObj.GetComponent<Aviao>().isAlive();

        if (isPlaneAlive)
        {
            float deslocamento = Mathf.Repeat(this.velocidade * Time.time, this.tamanhoRealDaImagem);
            this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
        }
    }
}
