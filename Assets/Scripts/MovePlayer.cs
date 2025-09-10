using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;

    //MOVIMIENTO
    [SerializeField] private float velocidadMovimiento = 5;   //etiqueta para ver la variable velocidadMovimiento dentro de Unity
    private float h, v; //h=horizontal v=vertical
    private Vector3 direccion; //variable donde se guarda el vector del movimiento
    [SerializeField] private float velocidadRotacion = 5;
    private Quaternion rotacion;

    public static bool boostVelocidad = false;//indica si el boost de velociada esta activo o no 
    public static float aumentoVel = 1;//aumento la velocidad (en porcentaje) 
    public static float duracionBoostVel;


    //SALTO
    [SerializeField] private float fuerzaSalto = 1;
    private bool quiereSaltar = false;

    public LayerMask capaSuelo;
    public Transform detectorSuelos;
    private float radioDetectorsuelos = 0.01f;
    private bool tocandoSuelo = false;

    [SerializeField] private float tiempoInicioSalto = 0.25f; //cuanto timepo queremos mantener el salto
    private float tiempoSaltando = 0; //medir el tiempo desde que se comenzo el salto
    //private bool estaSaltando; //saber si el usario esta saltando                                 //

    [SerializeField] public static int maxSaltos = 2;    //cuantos saltos podemos hacer antes de tocar el suelo
    private int numeroSalto; //cuantos saltos ha hecho el personaje antes de tocar el suelo

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   //Busca el componente en el mismo nivel/inspector del obejor en el que se encuentra  
    }

    // Update is called once per frame
    void Update() //LOGICA
    {
        //detccion del movimiento horizontal y vertical
        h = Input.GetAxisRaw("Horizontal"); // lee los controles que el usuario pulsa vlaores de 0 a 1/-1 en un framae
        v = Input.GetAxisRaw("Vertical");// los valores van incrementando poco a poco 


        //salto
        quiereSaltar = Input.GetButton("Jump");  // GetButtonDown ---> registra true cuanado se pulsa el boton solo una vez cada que se pulsa

        //tocando suelo
        tocandoSuelo = Physics.CheckSphere( //crea una esfera que avisa cuanod esta en contactocon algo
                detectorSuelos.position,    //posicion del centro de la esfera 
                radioDetectorsuelos,        //radio de detecion del suelo
                capaSuelo);                 //solo regresa respuesta si la esfera toca algo       

        if (Input.GetButtonUp("Jump")) // registra cuando el boton de salto dejo de ser pulsado
        {
            tiempoSaltando = 0;
            if (numeroSalto < maxSaltos) //si el numero de saltos que dio el personaje es nemor a la cantidad de saltos maximos pertidos antes de tocar el suelo (evita que se agregen saltos extra a los permitidos)
            {
                numeroSalto++;  //aumenta el numero de saltos dados por el usuario 
            }
        }
        if (tocandoSuelo == true)
        {  //reinicia la cantidad de saltos dados por el usuario cuando toca el suelo
            numeroSalto = 0;
        }


    }

    private void FixedUpdate()//FISICAS
    {
        //moviminto horizontal y vertical
        direccion = new Vector3       //asigan la velocidad a jugador en los distintos ejes
            (h,   //eje x
             0,   //eje y 
             v);  //eje z

        if (boostVelocidad) {
            StartCoroutine(BoostVelocidadCuroutine());
        }
        
        rb.MovePosition( rb.position + direccion.normalized * (velocidadMovimiento * aumentoVel) * Time.fixedDeltaTime);//el movimiento instantaneo
        //Rotacion del jugador en la direccion que se mueve
        if (direccion.magnitude > 0.1f) //si la magnitud del vector de direccion es mayor que 0.1f el personaje rotara es esa direccion, manteniedo la rotacion
        {
            rotacion = Quaternion.LookRotation(direccion);  //obtiene la rotacion ue tendra el presonaje en base a al vector generado en el movimiento
            rb.transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.fixedDeltaTime); //suavica la animacion de rotacion del personaje 
;        }


        //salto
        if (quiereSaltar)
        {
            if (tocandoSuelo || numeroSalto < maxSaltos)
            {
                saltoCargado();
            }
        }
        

        
    }

    private void saltoCargado() 
    {
        if (tiempoSaltando < tiempoInicioSalto)
        {
            rb.velocity = new Vector3 (0, fuerzaSalto, 0);   //salto
            tiempoSaltando += Time.fixedDeltaTime;  //se le suma el timepo que se lleva desde que se inicio el salto
        }

    }

    private IEnumerator BoostVelocidadCuroutine()
    {
        Debug.Log("aumneto, velociadad al " + aumentoVel*100 + "%");

        yield return new WaitForSeconds(duracionBoostVel);

        aumentoVel = 1;
        boostVelocidad = false;
        Debug.Log("velociad actual al " + aumentoVel *100 + "%");
    }
}
