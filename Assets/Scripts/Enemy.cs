using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private AudioSource dingAudio;
    [SerializeField] private GameObject visual;
    
    public static Action<Enemy> OnDeath;

    public void Activate()
    {
        isActive = true;
        visual.SetActive(true);

        GetComponent<CircleCollider2D>().enabled = true;

        speed = Random.Range(100, 400);
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
            Destroy(other.gameObject);

            Kill();
        }
    }

    private void Kill()
    {
        deathAudio.Play();
        dingAudio.Play();
        GetComponent<CircleCollider2D>().enabled = false;
        visual.SetActive(false);
        
        OnDeath?.Invoke(this);
    }
}
