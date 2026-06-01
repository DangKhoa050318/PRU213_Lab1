using UnityEngine;

// Làm vật thể bay từ phải sang trái và tự hủy
public class MoveLeft : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        // Di chuyển sang trái
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Start()
    {
        // Tự hủy sau 10 giây nếu bay ra khỏi màn hình để tránh nặng máy
        Destroy(gameObject, 10f);
    }
}