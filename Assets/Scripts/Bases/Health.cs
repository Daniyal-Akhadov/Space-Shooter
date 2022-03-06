using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _healthValue;
    [SerializeField] protected HealthBar _healthBar;
    [SerializeField] private float _timeToTurnOnCollider = 0.5f;
    public int Value
    {
        get => _healthValue;
        set { }
    }

    private void Start()
    {
        Invoke(nameof(TurnOnCollider), _timeToTurnOnCollider);
        _healthBar.SetMatHealth(_healthValue);
    }
    public virtual void TakeDamage(int damage)
    {
        _healthValue -= damage;
        _healthBar.SetHealth(_healthValue);
        if (_healthValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(int value)
    {
        _healthValue += value;
    }

    public void TurnOnCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
