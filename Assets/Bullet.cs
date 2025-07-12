using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    void Start() {
        bulletRigidbody = GetComponent<Rigidbody>();
        // Set the bullet's velocity
        bulletRigidbody.linearVelocity = transform.forward * speed;
        
        Destroy(gameObject, 3f);
    }
}
