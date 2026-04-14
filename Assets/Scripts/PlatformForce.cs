using UnityEngine;

public class PlatformForce : MonoBehaviour
{
    [SerializeField]
    private float boostAmount = 10f;
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 boostDirection = transform.up; // Boost in the upward direction
                rb.AddForce(boostDirection * boostAmount, ForceMode.Impulse);
                Debug.Log("Boost applied to player!");
            }
        }
    }
}
