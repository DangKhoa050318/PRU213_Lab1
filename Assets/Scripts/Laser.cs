using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Laser bắn sang phải
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void Start()
    {
        Destroy(gameObject, 3f); // Tự hủy sau 3 giây
    }

    // Tiêu diệt thiên thạch nếu bắn trúng
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject); // Phá hủy thiên thạch
            Destroy(gameObject);           // Phá hủy tia laser
        }
    }
}