using UnityEngine;

public class conade : MonoBehaviour
{
   private Rigidbody _rb;
   private float force = 10f;
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
        if (collision.gameObject.tag == "Pinardo")
        {
           // Destroy(collision.gameObject);
        }
    }
}
