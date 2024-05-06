using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.5f ;
    [SerializeField] private float variacaoPosicaoY; 

    private void Awake(){
        this.transform.Translate(Vector3.up * Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime );
    }
}
