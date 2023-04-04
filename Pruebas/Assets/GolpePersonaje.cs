using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GolpePersonaje : MonoBehaviour
{
    public bool daño;
    private int empuje;

    public void Daño()
    {
        if (daño == true)
        {
            transform.Translate(Vector3.right * empuje * Time.deltaTime, Space.World);
        }
    }
    public void FinalizarDaño()
    {
        daño = false;
    }
}
