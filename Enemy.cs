using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f; //kiểm soát tốc độ của Enemy
    private float distance = 5f; //khoảng cách di chuyển tối đa từ vị trí ban đầu của enemy
    private Vector3 startPos; //vị trí ban đầu của enemy
    private bool movingRight = true; //trạng thái di chuyển của enemy


    void Start()
    {
        startPos = transform.position; //lưu vị trí ban đầu của enemy
    }


    void Update()
    {
        float leftBoundary = startPos.x - distance; //tính toán biên trái
        float rightBoundary = startPos.x + distance; //tính toán biên phải
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); //di chuyển sang phải
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false; //đổi hướng khi chạm biên phải
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); //di chuyển sang trái
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true; //đổi hướng khi chạm biên trái
            }
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale; //lấy kích thước hiện tại
        scale.x *= -1; //đảo ngược chiều ngang
        transform.localScale = scale; //cập nhật kích thước mới
    }
}
