using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Rigidbody2D rb;

    public void Activate()
    {
        isActive = true;
    }

    private void FixedUpdate()
    {
        if (isActive == false)
            return;

        Vector3 direction = Vector3.zero - transform.position;
        rb.linearVelocity = direction.normalized * (speed * Time.fixedDeltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Debug.Log("Oh no");
            
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
