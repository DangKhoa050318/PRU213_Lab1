using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Start()
    {
        Destroy(gameObject, 10f);
    }
}