using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorMisseis : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerar;
    [SerializeField]
    private GameObject manualDeInstrucoes;
    private float cronometro;
    private GameObject aviao;

    private void Start()
    {
        aviao = GameObject.Find("aviao1");
    }

    private void Awake(){
        this.cronometro = this.tempoParaGerar;
    }

    void Update()
    {
        bool isPlaneAlive = aviao.GetComponent<Aviao>().isAlive();

        if (isPlaneAlive)
        {
            //Quando que eu quero gerar? Tempo
            this.cronometro -= Time.deltaTime;
            if (this.cronometro < 0)
            {
                //Onde eu vou gerar? Na posição do meu gerador
                GameObject.Instantiate(this.manualDeInstrucoes, this.transform.position, Quaternion.identity);
                this.cronometro = this.tempoParaGerar;
            }
            //Como Gerar Obstaculos?
        }
    }
}