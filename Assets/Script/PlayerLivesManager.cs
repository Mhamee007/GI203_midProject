using UnityEngine;
using TMPro;

public class PlayerLivesManager : MonoBehaviour
{
    public int totalLives = 3;  // จำนวนชีวิตเริ่มต้น
    private int currentLives;

    public TMP_Text livesText;  // ลิงก์กับ TextMeshPro UI

    private void Start()
    {
        currentLives = totalLives; // เซ็ตค่าชีวิตเริ่มต้น
        UpdateLivesUI();
    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage called");

        if (currentLives > 0)
        {
            Debug.Log("Current Lives before: " + currentLives);

            currentLives--;  // ลดจำนวนชีวิต
            UpdateLivesUI();

            Debug.Log("Current Lives after: " + currentLives);

            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText == null)
        {
            Debug.LogError("LivesText is not assigned in the Inspector!");
            return;
        }

        livesText.text = "Lives: " + currentLives; // อัปเดตข้อความใน UI
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // เพิ่มฟังก์ชัน Game Over เช่น การรีสตาร์ทเกม
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")) // ตรวจสอบแท็ก
        {
            TakeDamage();
        }
    }

}
