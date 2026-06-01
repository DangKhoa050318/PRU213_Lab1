using UnityEngine;

// Xử lý di chuyển, bắn súng và va chạm của Player
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject laserPrefab;
    public Transform firePoint;

    // Giới hạn màn hình để phi thuyền không bay ra ngoài
    private float minY = -4.5f;
    private float maxY = 4.5f;
    private float minX = -8f;
    private float maxX = 8f;

    void Update()
    {
        // Di chuyển bằng phím mũi tên hoặc WASD
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Ép vị trí không vượt qua giới hạn màn hình
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            0
        );

        // Bắn khi nhấn phím Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
    }

    // Xử lý khi đâm vào Ngôi sao (Trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            GameManager.Instance.AddScore(10); // Cộng 10 điểm
            Destroy(collision.gameObject);    // Biến mất ngôi sao
        }
    }

    // Xử lý khi đâm vào Thiên thạch (Collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject); // Hủy phi thuyền
            GameManager.Instance.LoadScene("EndGame"); // Thua game
        }
    }
}