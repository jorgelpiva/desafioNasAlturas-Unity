using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{

    [SerializeField]
    private GameObject imagemGameOver;


    // Start is called before the first frame update

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
