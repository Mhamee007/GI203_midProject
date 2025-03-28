using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PlayerLivesManager : MonoBehaviour
{
    public int totalLives = 3;  // จำนวนชีวิตเริ่มต้น
    private int currentLives;

    public TMP_Text livesText;  // เปลี่ยนชนิดจาก Text เป็น TMP_Text

    private void Start()
    {
        // กำหนดค่าชีวิตเริ่มต้น
        currentLives = totalLives;
        UpdateLivesUI();
    }

    public void TakeDamage()
    {
        if (currentLives > 0)
        {
            currentLives--;  // ลดจำนวนชีวิตลง
            UpdateLivesUI();

            if (currentLives <= 0)
            {
                GameOver();
            }
        }
    }

    private void UpdateLivesUI()
    {
        // อัปเดตข้อความใน UI
        livesText.text = "Lives: " + currentLives;
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // เพิ่มการจัดการเกมโอเวอร์ที่นี่ เช่น Restart Scene
    }
}
