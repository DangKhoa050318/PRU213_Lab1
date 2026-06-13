using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject laserPrefab;
    public Transform firePoint;

    private float minY = -4.5f;
    private float maxY = 4.5f;
    private float minX = -8f;
    private float maxX = 8f;
    private bool isDead = false;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            0
        );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(laserPrefab, firePoint.position, laserPrefab.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            GameManager.Instance.AddScore(10);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            isDead = true;
            Destroy(gameObject); 
            GameManager.Instance.LoadScene("EndGame"); 
        }
    }
}