using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Missile : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.5f ;
    [SerializeField] private float variacaoPosicaoY;
    private GameObject aviao;
    private bool pontuou = false;
    private GameObject scoreTextObj;

    private void Start()
    {
        aviao = GameObject.Find("aviao1");
        scoreTextObj = GameObject.FindWithTag("Score");
    }

    private void Awake(){
        this.transform.Translate(Vector3.up * UnityEngine.Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
    }

    private void Update()
    {
        Aviao aviaoComp = aviao.GetComponent<Aviao>();

        float x2Aviao = aviao.transform.position.x;
        float x1Aviao = x2Aviao - aviao.GetComponent<SpriteRenderer>().bounds.size.x;

        if (!pontuou && x1Aviao >= this.transform.position.x + 2.00 && x1Aviao < this.transform.position.x + 4.00) {
            TMPro.TextMeshProUGUI scoreTextMesh = scoreTextObj.GetComponent<TMPro.TextMeshProUGUI>();
            aviaoComp.pontuar();
            scoreTextMesh.text = "Score: " + aviaoComp.checarPontuacao();
            pontuou = true;
        }

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
