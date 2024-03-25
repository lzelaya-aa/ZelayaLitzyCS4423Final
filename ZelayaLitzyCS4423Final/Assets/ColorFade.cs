using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private Color fadeColor = Color.clear;
    [SerializeField] private float fadeTime = 1;
    [SerializeField] private Button buttonStart; 
    private bool hasStartedFade = false;
    // Start is called before the first frame update
    void Start()
    {
        if (buttonStart != null)
        {
            buttonStart.onClick.AddListener(StartFade);
        }
    }

    void StartFade()
    {
        if (!hasStartedFade)
        {
            fadeToBlack();
            hasStartedFade = true;
        }
    }
    void fadeToBlack(){
        fadeImage.color = fadeColor;
        StartCoroutine(fadeToClearRoutine());
        IEnumerator fadeToClearRoutine(){
            float timer = 0;
            while(timer < fadeTime){
                yield return null;
                timer+=Time.deltaTime;
                fadeImage.color = new Color(fadeColor.r,fadeColor.g,fadeColor.b,1f - (timer/fadeTime));
            }
            fadeImage.color = Color.black;
        }
    }
}
