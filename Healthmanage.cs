using UnityEngine;
using UnityEngine.UI; //làm việc với đối tượng Image
using TMPro; //Dùng để hiển thị chữ bằng TextMeshPro (rõ và đẹp hơn Text thường).

public class Healthmanage : MonoBehaviour
{
    public Image fillBar; //ảnh thanh máu
    public TextMeshProUGUI valueText; //chữ hiển thị số máu


    public void UpdateBar(int currentHealth, int maxHealth) //cập nhật thanh máu và chữ hiển thị mỗi khi nhân vật bị thương hoặc hồi máu
    {
        fillBar.fillAmount = (float)currentHealth / (float)maxHealth;  //thể hiện phần trăm máu  
        valueText.text = currentHealth.ToString() + " / " + maxHealth.ToString(); //hiện số máu hiện tại và máu tối đa
    }
}