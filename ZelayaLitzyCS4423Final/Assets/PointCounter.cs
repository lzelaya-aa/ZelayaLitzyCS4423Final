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

    void Awake(){
        if(singleton != null){
            Destroy(this.gameObject);
        }
        singleton = this;
    }
    void Start(){

    }

    public void RegisterPoint(int points = 1){
        pointsCollected += points;
        PointCounterUI.text = pointsCollected.ToString();
    }
}
