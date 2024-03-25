using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class ScaleTransform : MonoBehaviour
{
    public float scaleFactor = 80.0f;
    public float maxScale = 200.0f;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Calculate the new scale based on time and scaleFactor
        float newScale = rectTransform.localScale.x + scaleFactor * Time.deltaTime;

        newScale = Mathf.Clamp(newScale, rectTransform.localScale.x, maxScale);

        // Set the new scale
        rectTransform.localScale = new Vector3(newScale, newScale, 1.0f);
    }
}

