using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private const float _lifeTime = 2f;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _speed = 6f;

    [SerializeField] protected float _timeToAttak = 0.15f;

    protected float _timer;

    protected void Shoot()
    {
        var newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * _speed;
        Destroy(newBullet.gameObject, _lifeTime);
    }
}
