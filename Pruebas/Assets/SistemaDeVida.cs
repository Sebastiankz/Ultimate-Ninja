using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeVida : MonoBehaviour
{
    public GameObject[] corazon;
    int vida;
    
    void Start()
    {
       vida = corazon.Length;
    }

    void ConsultarVida()
    {
        if (vida < 1)
        {
            Destroy(corazon[0].gameObject);
            Destroy(this.gameObject);
        }
        else if (vida < 2)
        {
            Destroy(corazon[1].gameObject);
        }
        else if (vida < 3)
        {
            Destroy(corazon[2].gameObject);
        }
    }
    private void daño()
    {
        ConsultarVida();
    }
}
