using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movimiento")]

    private float movimientoHorizontal = 0f;
    private float ataque = 0f;
    [SerializeField] private float velocidadMovimiento = 0f;
    [Range(0, 0.3f)][SerializeField] private float fluidezMovimiento = 0f;
    private Vector3 velocidad = Vector3.zero;
    private bool direccion = false;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto = 0f;
    [SerializeField] private LayerMask identificarSuelo; //Identificará suelos aptos para saltar
    [SerializeField] private Transform controladorSuelo; //Pequeño Gameobject que se le pondrá al personaje en la parte inferior para identificar el suelo
    [SerializeField] private Vector3 dimensionesCaja; //Identificará el tipo de suelo
    [SerializeField] private bool suelo;
    private bool saltar = false; //Para saltar

    [Header("Animacion")]
    private Animator animacion;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }
    private void Update()
    {
        
        animacion.SetFloat("velocidadY",rb.velocity.y);
        //ataque = Input.GetAxisRaw("AtaqueEspada");
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento; //movimiento derecha/izquierda con velocidad determinada
        animacion.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal)); //1er parámetro: Componente a cambiar
        if (Input.GetButtonDown("Jump"))                                   //2do parámetro: Lo que va a causar el cambio
        {
            saltar = true;
        }
    }
    private void FixedUpdate() //Método update adaptable a más dispositivos debido a su fluidez
    {
        suelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, identificarSuelo);
        animacion.SetBool("suelo", suelo);
        Mover(movimientoHorizontal * Time.fixedDeltaTime, saltar);
        saltar = false;
        
    }
    private void Mover(float mover, bool saltar)
    {
       Vector3 velocidadObjetivo = new Vector2(mover,rb.velocity.y);
       rb.velocity = Vector3.SmoothDamp(rb.velocity, velocidadObjetivo, ref velocidad, fluidezMovimiento);

        if (mover < 0 && !direccion)
        {
            Girar();
        }
        else if (mover > 0 && direccion)
        {
            Girar();
        }
        if(suelo && saltar)
        {
            saltar = false;
            rb.AddForce(new Vector2(0f, fuerzaSalto));
        }
    } 
    private void Girar()
    {
        direccion = !direccion;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
