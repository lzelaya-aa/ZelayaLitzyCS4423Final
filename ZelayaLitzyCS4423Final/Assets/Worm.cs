using UnityEngine;

public class Worm : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeCounter lifeCounter = collision.gameObject.GetComponent<LifeCounter>();
            if (lifeCounter != null)
            {
                lifeCounter.LoseHeart();
            }
        }
    }
}


