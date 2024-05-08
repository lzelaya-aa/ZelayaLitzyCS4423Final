using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GoldenApple : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public GameObject particleSystemObject;
    public float delayBeforeReturnToMenu = 3f; // Delay before returning to the main menu
    private bool isPlayerFrozen = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Freeze the player's movement
            FreezePlayer(true);
            // Update the message
            messageText.text = "You found the Golden Apple! You win!";

             if (particleSystemObject != null)
            {
                particleSystemObject.SetActive(true);
            }

            gameObject.SetActive(false);
            gameObject.SetActive(true);
            // Start coroutine to return to main menu after the specified delay
            StartCoroutine(ReturnToMainMenuAfterDelay(delayBeforeReturnToMenu));
        }
    }

    void FreezePlayer(bool freeze)
    {
        Rigidbody2D playerRigidbody = FindObjectOfType<Libriarian>().GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            if (freeze)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.angularVelocity = 0f;
            }
            playerRigidbody.isKinematic = freeze;
        }
        isPlayerFrozen = freeze;
    }

    IEnumerator ReturnToMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Delete playerprefs for life counter
        PlayerPrefs.DeleteKey("CurrentHearts");

        // Delete playerprefs for point counter
        PlayerPrefs.DeleteKey("PointsCollected");

        // Load the main menu scene
        SceneManager.LoadScene("Menu");
    }


}



