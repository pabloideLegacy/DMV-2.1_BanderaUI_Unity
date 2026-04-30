using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject BtnReiniciar; // Referencia al botón de reiniciar, asignada desde el Inspector
    [Header("Lista de todas las canicas")]
    public Rigidbody[] todasLasCanicas; 
    [Header("Audio")]
    public AudioSource backgroundSound; // Referencia al AudioSource del BackgroundSound
    public AudioSource hintSound; // Referencia al AudioSource del hint

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
        BtnReiniciar.SetActive(false); // Aseguramos que el botón de reiniciar esté oculto al inicio
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
        
        
        // Reproducir sonido de hint
        if (hintSound != null)
        {
            hintSound.Play();
        }
        
        // Esperar 5 segundos antes de soltar las canicas
        StartCoroutine(SoltarCanicasConDelay(5f));

        // Reproducir la canción de fondo después de un delay para que el hint suene primero
        StartCoroutine(CancionFondo(5f));
        
        Debug.Log("¡Carrera iniciada con " + todasLasCanicas.Length + " canicas!");
    }

    IEnumerator SoltarCanicasConDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        // Soltamos todas las canicas después del delay
        foreach (Rigidbody rb in todasLasCanicas)
        {
            if (rb != null) rb.isKinematic = false;
        }
    }

    IEnumerator CancionFondo(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (backgroundSound != null)
        {
            backgroundSound.Play();
        }
    }

    public void CruzarMeta()
    {
        // En este caso, el primero que llegue activa el estado "Terminado"
        if (estadoActual == EstadoJuego.Jugando)
        {
            estadoActual = EstadoJuego.Terminado;
            Debug.Log("¡Ganador detectado! Presiona Espacio para reiniciar.");
            backgroundSound.Stop(); // Detenemos la música de fondo
            BtnReiniciar.SetActive(true); // Mostramos el botón de reiniciar
        }
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}