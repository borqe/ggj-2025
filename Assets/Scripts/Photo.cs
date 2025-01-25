using UnityEngine;
using Random = UnityEngine.Random;

public class Photo : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), 0);
        // transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer($"Player"))
        {
            GameManager.Instance.WinGame();
        }
    }
}
