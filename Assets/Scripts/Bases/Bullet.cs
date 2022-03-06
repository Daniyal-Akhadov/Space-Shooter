using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damage;

    public int Damage
    {
        get => _damage;
        set { }
    }
}
