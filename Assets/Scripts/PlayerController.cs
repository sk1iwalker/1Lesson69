using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject[] visuals;
    [SerializeField] private int visualIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        float horisontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction += Vector3.forward * vertical;
        direction += Vector3.right * horisontal;

        direction.Normalize();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed * Time.deltaTime);

        direction *= _speed;

        direction.y = _rigidbody.linearVelocity.y;

        _rigidbody.linearVelocity = direction;
    }
}
