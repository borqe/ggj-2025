using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform gunTransform;
    
    [SerializeField] float moveSpeed = 5f;

    private bool isMoving;
    
    void Start()
    {
        
    }

    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePos - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // roll?
        }
        
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        
        transform.Translate(direction.normalized * (Time.deltaTime * moveSpeed));
    }
}
