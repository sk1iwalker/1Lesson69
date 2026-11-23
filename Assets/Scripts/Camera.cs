using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        Vector3 targetPos = _target.position + _offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, _speed * Time.deltaTime);
    }
}