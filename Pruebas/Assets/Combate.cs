using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
   private Animator animacion;
   [SerializeField] private Transform controladorGolpe;
   [SerializeField] private float distanciaGolpe;
   [SerializeField] private float dañoGolpe;
   [SerializeField] private float tiempoEntreAtaque;
   [SerializeField] private float tiempoLuegoDeAtaque;

    private void Start()
    {
        animacion = GetComponent<Animator>();
    }
    private void Update()
    {
        if(tiempoEntreAtaque > 0)
        {
            tiempoLuegoDeAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("AtaqueEspada") && tiempoLuegoDeAtaque <= 0)
        {
            Golpear();
            tiempoLuegoDeAtaque = tiempoEntreAtaque;
        }   
    }
    private void Golpear()
    {
        animacion.SetTrigger("atacar");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, distanciaGolpe);
        foreach(Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<VidaDeEnemigo>().TomarDaño(dañoGolpe);
            }
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, distanciaGolpe); 
    }
}
