using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    int currentHealth; //lượng máu hiện tại
    public int maxHealth; //lượng máu tối đa
    public Healthmanage healthmanage; //lấy cái Healthmanage để cập nhật thanh máu và chữ hiển thị của người chơi
    public UnityEvent Detroyself; //sự kiện hủy đối tượng


    void Start()
    {
        currentHealth = maxHealth;
        healthmanage.UpdateBar(currentHealth, maxHealth); //cập nhật thanh máu và chữ hiển thị lúc bắt đầu
    }

    private void death()
    {
        Detroyself.AddListener(Death);
    }

    public void Death()
    {
        Destroy(gameObject); //hủy đối tượng
    }

    public void TakeDamage(int damage) //hàm nhận sát thương
    {
        currentHealth -= damage; //trừ máu hiện tại đi sát thương nhận vào

        healthmanage.UpdateBar(currentHealth, maxHealth); //cập nhật thanh máu và chữ hiển thị sau khi nhận sát thương

        if (currentHealth <= 0)
        {
            Detroyself.Invoke(); //nếu máu hiện tại nhỏ hơn hoặc bằng 0 thì gọi hàm hủy đối tượng
        }

        healthmanage.UpdateBar(currentHealth, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
            TakeDamage(20);
        else if (collision.CompareTag("Enemy"))
            TakeDamage(20);
    }

}
