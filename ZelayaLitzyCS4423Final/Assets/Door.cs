using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextLevelName;
    public Sprite doorOpenSprite; // Reference to the open door sprite
    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        spriteRenderer.sprite = doorOpenSprite; // Change sprite to open door

    
    }

    private void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }

    private void CloseDoor()
    {
        isOpen = false;
    }


}