using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthPool : MonoBehaviour
{
    [SerializeField] private GameObject healthPrefab;

    private int healthCount = 20;
    
    void Start()
    {
        for (int i = 0; i < healthCount; i++)
        {
            Instantiate(healthPrefab, new Vector3(Random.Range(-90, 90), 0, Random.Range(-90, 90)), Quaternion.identity);
        }

        Kibble.OnPickup -= OnKibblePickup;
    }

    private void OnDestroy()
    {
        Kibble.OnPickup -= OnKibblePickup;
    }

    private void OnKibblePickup(Kibble obj)
    {
        obj.transform.position = new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), 0);
        obj.transform.rotation = Quaternion.identity;

        obj.Activate();
    }
}
