using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projetil : MonoBehaviour
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
        this.transform.Translate(Vector3.up * UnityEngine.Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
    }

    private void Update()
    {
        Aviao aviaoComp = aviao.GetComponent<Aviao>();


        bool isPlaneAlive = aviaoComp.isAlive();

        if (isPlaneAlive)
        {
            this.transform.Translate(Vector3.left * this.velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        this.Destruir();
    }

    public void Destruir(){
        GameObject.Destroy(this.gameObject);
    }
}