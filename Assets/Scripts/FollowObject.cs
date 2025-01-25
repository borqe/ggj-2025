using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private Transform target;
    
    void Update()
    {
        if (isActive)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
