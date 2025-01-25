using System;
using UnityEngine;

public class Kibble : MonoBehaviour
{
    public static Action<Kibble> OnPickup;
    
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
            OnPickup?.Invoke(this);
        }
    }

    public void Activate()
    {
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }
}
