using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [SerializeField] private Rigidbody _body;

    public void Launch(Vector3 startDirection)
    {
        _body.AddForce(speed * startDirection, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("Bullet colllision");
            enemy.TakeDamage(1);
        }
        
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }   

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Bullet stopped touching something! - " + collision.gameObject.name);
    }
}