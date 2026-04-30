using UnityEngine;

public class Boost : MonoBehaviour
{
    public AudioSource boostSound; // Referencia al AudioSource del boost
    [SerializeField] private float force = 20f;

    // Usamos OnTriggerEnter porque mencionaste que es un Trigger
    private void OnTriggerEnter(Collider other)
    {
        // 1. Verificamos si es el jugador
        if (other.CompareTag("Player"))
        {
            // 2. Obtenemos el Rigidbody de la CANICA (other), no del boost
            Rigidbody rbPlayer = other.GetComponent<Rigidbody>();

            if (rbPlayer != null)
            {
                // 3. Aplicamos la fuerza en la dirección frontal del BOOST (transform.forward)
                // Usamos ForceMode.Impulse para que sea un estallido de energía inmediato
                rbPlayer.AddForce(transform.right * force, ForceMode.Impulse);
                // 4. Reproducimos el sonido de boost
                if (boostSound != null)                {
                    boostSound.Play();
                }
                
                Debug.Log("¡Boost aplicado en dirección: " + transform.right + "!");
            }
        }
    }
}