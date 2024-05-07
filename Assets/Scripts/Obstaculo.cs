using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.5f ;
    [SerializeField] private float variacaoPosicaoY;
    private GameObject aviao;

    private void Start()
    {
        aviao = GameObject.Find("aviao1");
    }

    private void Awake(){
        this.transform.Translate(Vector3.up * Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
    }

    private void Update()
    {
        bool isPlaneAlive = aviao.GetComponent<Aviao>().isAlive();

        if (isPlaneAlive)
        {
            this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        this.Destruir();
    }

    private void Destruir(){
        GameObject.Destroy(this.gameObject);
    }
}
