using UnityEngine;
using UnityEngine.InputSystem; // Necesario para detectar la tecla W
using System.Collections.Generic; // Necesario para usar Listas

public class Meta : MonoBehaviour
{
    public AudioSource metaSound; //Metemos sonido de meta CAARLYWHY
    public GameManager gameManager;
    
    [Header("Configuración del Salto")]
    [SerializeField] private float fuerzaSalto = 7f;

    // Guardamos las canicas que ya cruzaron para que solo estas salten
    private List<Rigidbody> canicasQueTerminaron = new List<Rigidbody>();

    void Update()
    {
        // Verificamos si se presiona la tecla W
        if (Keyboard.current != null && Keyboard.current.wKey.wasPressedThisFrame)
        {
            SaltarCanicasGanadoras();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            // Si la canica tiene Rigidbody y no la hemos registrado aún
            if (rb != null && !canicasQueTerminaron.Contains(rb))
            {
                canicasQueTerminaron.Add(rb);
                gameManager.CruzarMeta();
                if (metaSound != null && !metaSound.isPlaying)
                {
                    metaSound.Play();
                }
                Debug.Log("Canica registrada para saltar.");
            }
        }
    }

    void SaltarCanicasGanadoras()
    {
        foreach (Rigidbody rb in canicasQueTerminaron)
        {
            if (rb != null)
            {
                // Aplicamos la fuerza hacia arriba (eje Y)
                // ForceMode.Impulse es ideal para saltos instantáneos
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }
        }
    }
}