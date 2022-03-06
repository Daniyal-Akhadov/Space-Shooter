using UnityEngine;

public class EnemyHealth : Health
{
    public override void TakeDamage(int damage)
    {
        _healthValue -= damage;
        _healthBar.SetHealth(_healthValue);
        if (_healthValue <= 0)
        {
            Shop.AddCredits(1);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerBullet = collision.GetComponent<PlayerBullet>();
        if (playerBullet)
        {
            TakeDamage(playerBullet.Damage);
            Destroy(playerBullet.gameObject);
        }
    }
}
