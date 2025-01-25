using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private GameObject areaPrefab;
    [SerializeField] private float wakeupRadius = 2.0f;

    private int enemyLayer;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer($"Enemy");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer($"Bullet"))
        {
            Instantiate(areaPrefab, other.GetContact(0).point, Quaternion.identity, transform);
            
            var enemiesToWakeUp = Physics2D.CircleCastAll(other.contacts[0].point, wakeupRadius, Vector2.up, enemyLayer);

            foreach (var enemy in enemiesToWakeUp)
            {
                enemy.collider.GetComponent<Enemy>()?.Activate();
            }
            
            Destroy(other.gameObject);
        }
    }
}
