using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private Slider _slider;

    private int _health;

    private void Start()
    {
        _health = _maxHealth;
        _slider.value = 1;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        _slider.value = (float)_health / (float)_maxHealth;

        if (_health <= 0)
        {
            Destroy(gameObject);

      
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet component))
        {
            Destroy(component.gameObject);
        }
    }
}