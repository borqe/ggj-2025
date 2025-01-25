using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform gunTransform;
    [SerializeField] float moveSpeed = 5f;

    private bool isMoving;
    private bool isRolling;
    private Vector2 aimDirection;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - transform.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector2.down;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector2.right;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: teleporting atm, but will be fine
            transform.Translate(moveDirection.normalized * 3.0f);
            return;
        }
        
        transform.Translate(moveDirection.normalized * (Time.deltaTime * moveSpeed));
    }
}
