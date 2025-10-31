using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int currentHealth; //lượng máu hiện tại
    public int maxHealth; //lượng máu tối đa
    public Healthmanage healthmanage; //lấy cái Healthmanage để cập nhật thanh máu và chữ hiển thị của người chơi


    void Start()
    {
        currentHealth = maxHealth;
        healthmanage.UpdateBar(currentHealth, maxHealth); //cập nhật thanh máu và chữ hiển thị lúc bắt đầu
    }

    public void TakeDamage(int damage) //hàm nhận sát thương
    {
        currentHealth -= damage; //trừ máu hiện tại đi sát thương nhận vào

        healthmanage.UpdateBar(currentHealth, maxHealth); //cập nhật thanh máu và chữ hiển thị sau khi nhận sát thương

        if (currentHealth <= 0)
            Debug.Log("player chết rồi!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
            TakeDamage(20);
        else if (collision.CompareTag("Enemy"))
            TakeDamage(20);
    }

}
