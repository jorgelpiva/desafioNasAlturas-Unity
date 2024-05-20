using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviao : MonoBehaviour
{
    private Rigidbody2D fisica;
    [SerializeField]
    private float forca = 20;
    private bool alive = true;
    private int pontuacao = 0;

    public bool isAlive()
    {
        return alive;
    }

    private void Awake(){
        fisica = this.GetComponent<Rigidbody2D>();
        
    }

    public void pontuar() { pontuacao += 100; }

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
        }
    }

    private void Impulsionar(){
        fisica.velocity = Vector2.zero;
        fisica.AddForce(Vector2.up * this.forca , ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "chao" ||
            collision.gameObject.name == "Obstaculo(Clone)")
        {
            alive = false;
        }
    }
}
