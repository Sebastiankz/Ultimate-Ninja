using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GolpePersonaje : MonoBehaviour
{
    public bool da�o;
    private int empuje;

    public void Da�o()
    {
        if (da�o == true)
        {
            transform.Translate(Vector3.right * empuje * Time.deltaTime, Space.World);
        }
    }
    public void FinalizarDa�o()
    {
        da�o = false;
    }
}
