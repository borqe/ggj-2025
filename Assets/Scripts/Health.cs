using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 10;
    
    public static Action<int> OnHealthChanged;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer($"Enemy"))
        {
            Debug.Log(health);
            health--;
            OnHealthChanged?.Invoke(health);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer($"Health"))
        {
            health++;
            OnHealthChanged?.Invoke(health);
        }

        if (health <= 0)
        {
            GameManager.Instance.EndGame();
        }
    }
}
