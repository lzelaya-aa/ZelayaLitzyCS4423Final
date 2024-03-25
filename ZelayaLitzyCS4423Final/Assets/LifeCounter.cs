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
        currentHearts = maxHearts;
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
            SceneManager.LoadScene("Menu");
        }
    }
}

