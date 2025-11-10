//Namespace
using UnityEngine;

//Clase : Monobehaviour (comportamiento único)
public class Moneda : MonoBehaviour
{
    //Variables y métodos
    //Variable global y estática (una para todas las monedas)
    public static int contadorMonedas = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Moneda.contadorMonedas++;
        Debug.Log($"El juego ha comenzado y ahora hay {Moneda.contadorMonedas} monedas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Método que se llama automáticamente cuando
     Otro collider entra en contacto con el
    que tiene este script (en particular la moneda)*/
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player") == true)
        {
            //Como el jugador choca contra la moneda, ahora hay una menos.
            Moneda.contadorMonedas--;

            //En el caso de que el contador de monedas llegue a cero, hemos recogido todo.
            if (Moneda.contadorMonedas == 0)
            {
                Debug.Log("El juego ha terminado.");

                GameObject gameManager = GameObject.Find("GameManager");

                Destroy(gameManager);

                GameObject[] fireworksSystem = GameObject.FindGameObjectsWithTag("Fireworks");

                foreach (GameObject fireworks in fireworksSystem)
                {
                    fireworks.GetComponent<ParticleSystem>().Play();
                }
            }

            Destroy(gameObject);
        }
    }
}
