using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PointCounterUI;
    public static PointCounter singleton; 
    int pointsCollected = 0;

    void Awake()
    {
        if(singleton != null)
        {
            Destroy(this.gameObject);
        }
        singleton = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // Load current points from PlayerPrefs 
        pointsCollected = PlayerPrefs.GetInt("PointsCollected", 0);
        UpdatePointsUI();
    }

    void UpdatePointsUI()
    {
        PointCounterUI.text = pointsCollected.ToString();
    }

    public void RegisterPoint(int points = 1)
    {
        pointsCollected += points;
        UpdatePointsUI();

        // Save current points to PlayerPrefs after registering a point
        PlayerPrefs.SetInt("PointsCollected", pointsCollected);
    }
}
