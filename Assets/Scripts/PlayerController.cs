using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int MAX_HEALTH = 10;
    
    [SerializeField] private Transform gunTransform;
    [SerializeField] private Transform gunNozzle;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifeTime = 5f;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] private AudioSource shootingAudio;
    

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

        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, gunNozzle);
            bullet.transform.localPosition = Vector3.zero;
            bullet.transform.SetParent(null);
            bullet.transform.localScale = Vector3.one;
            bullet.GetComponent<Rigidbody2D>().linearVelocity = aimDirection.normalized * bulletSpeed;
            shootingAudio.Play();
        }
        
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
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     // TODO: teleporting atm, but will be fine
        //     transform.Translate(moveDirection.normalized * 3.0f);
        //     return;
        // }
        rb.linearVelocity = (moveDirection.normalized * (Time.deltaTime * moveSpeed));
    }
}
