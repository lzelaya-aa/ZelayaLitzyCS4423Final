using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        // Load current hearts from PlayerPrefs or set to maxHearts if not found
        currentHearts = PlayerPrefs.GetInt("CurrentHearts", maxHearts);
        UpdateHeartsUI();
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
    {
        if (i < currentHearts)
        {
            hearts[i].sprite = fullHeart;
        }
        else
        {
            hearts[i].sprite = emptyHeart;
            hearts[i].enabled = true; // Enable the empty heart UI image
        }
    }
    }

    public void LoseHeart()
    {
        currentHearts--;
        UpdateHeartsUI();

        if (currentHearts <= 0)
        {
            // Save current hearts to PlayerPrefs before loading the menu scene
                    // Delete playerprefs for life counter
            PlayerPrefs.DeleteKey("CurrentHearts");

            // Delete playerprefs for point counter
            PlayerPrefs.DeleteKey("PointsCollected");
            SceneManager.LoadScene("Menu");
        }
        else
        {
            // Save current hearts to PlayerPrefs after losing a heart
            PlayerPrefs.SetInt("CurrentHearts", currentHearts);
        }
    }
}

