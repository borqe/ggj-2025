using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private GameObject areaPrefab;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer($"Bullet"))
        {
            Instantiate(areaPrefab, other.GetContact(0).point, Quaternion.identity, transform);
            Destroy(other.gameObject);
        }
    }
}
