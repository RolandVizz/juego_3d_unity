using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float maxTime = 60f;

    private float countDown = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countDown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        //El deltaTime es el tiempo en segundos que ha pasado desde que se
        //renderizó en pantalla el último frame anterior.
        countDown -= Time.deltaTime;
        Debug.Log(countDown);

        if(countDown <= 0f)
        {
            Debug.Log("Te has quedado sin tiempo. ¡Has perdido!");

            Moneda.contadorMonedas = 0;

            SceneManager.LoadScene("MainScene");
        }
    }
}
