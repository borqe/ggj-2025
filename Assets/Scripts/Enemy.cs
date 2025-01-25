using System;
using System.Collections;
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
    [SerializeField] private GameObject boomVisual;
    
    public static Action<Enemy> OnDeath;

    private PlayerController player;

    public void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    
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
        
        if (player != null)
        {
            direction = player.transform.position - transform.position;
        }

        rb.linearVelocity = direction.normalized * (speed * Time.fixedDeltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(other.gameObject);
            Kill();
        }
    }

    private void Kill()
    {
        StartCoroutine(KillCoroutine());
    }

    private IEnumerator KillCoroutine()
    {
        isActive = false;
        
        deathAudio.pitch = Random.Range(0.7f, 1.3f);
        deathAudio.Play();
        
        dingAudio.pitch = Random.Range(0.95f, 1.05f);
        dingAudio.Play();
        
        GetComponent<CircleCollider2D>().enabled = false;
        visual.SetActive(false);
        boomVisual.SetActive(true);
        rb.linearVelocity = Vector2.zero;
        
        yield return new WaitForSeconds(1.0f);
        
        boomVisual.SetActive(false);
        isActive = true;
        OnDeath?.Invoke(this);
    }
}
