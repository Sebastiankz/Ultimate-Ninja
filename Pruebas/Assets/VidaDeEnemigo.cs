using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDeEnemigo : MonoBehaviour
{
    private Animator animacion;
    [SerializeField] private float vida;

    private void Start()
    {
        animacion = GetComponent<Animator>();
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Muerte()
    {
      //animación de muerte cuando la vida llega a 0.
    }
}
