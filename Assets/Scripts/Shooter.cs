
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPoint_1;
    public Transform gunPoint_2;

    [SerializeField] private Transform _playerTransform;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Bullet bulletGO = Instantiate(bulletPrefab, gunPoint_1.transform.position, Quaternion.identity).GetComponent<Bullet>();

            Vector3 direction = gunPoint_2.position - gunPoint_1.position;
            direction.Normalize();

            bulletGO.Launch(direction);

            Destroy(bulletGO, 2);
        }
    }
}
