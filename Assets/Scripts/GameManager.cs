using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Lista de todas las canicas")]
    public Rigidbody[] todasLasCanicas; 

    private enum EstadoJuego { Esperando, Jugando, Terminado }
    private EstadoJuego estadoActual = EstadoJuego.Esperando;

    void Start()
    {
        // Usamos un ciclo 'foreach' para congelar cada canica de la lista
        foreach (Rigidbody rb in todasLasCanicas)
        {
            if (rb != null) rb.isKinematic = true;
            Debug.Log("Esperando presiona Espacio para iniciar la carrera...");
        }
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (estadoActual == EstadoJuego.Esperando)
            {
                IniciarCarrera();
            }
            else if (estadoActual == EstadoJuego.Terminado)
            {
                ReiniciarNivel();
            }
        }
    }

    void IniciarCarrera()
    {
        estadoActual = EstadoJuego.Jugando;
        
        // Soltamos todas las canicas al mismo tiempo
        foreach (Rigidbody rb in todasLasCanicas)
        {
            if (rb != null) rb.isKinematic = false;
        }
        
        Debug.Log("¡Carrera iniciada con " + todasLasCanicas.Length + " canicas!");
    }

    public void CruzarMeta()
    {
        // En este caso, el primero que llegue activa el estado "Terminado"
        if (estadoActual == EstadoJuego.Jugando)
        {
            estadoActual = EstadoJuego.Terminado;
            Debug.Log("¡Ganador detectado! Presiona Espacio para reiniciar.");
        }
    }

    void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}