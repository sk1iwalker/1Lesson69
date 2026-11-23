using UnityEngine;

public class Coins : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Score score = FindObjectOfType<Score>();
            score.AddScore();
            Destroy(gameObject); 
        }
    }
}
