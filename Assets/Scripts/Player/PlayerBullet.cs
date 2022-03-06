using UnityEngine;

public class PlayerBullet : Bullet
{
    public void AddDamage(int value)
    {
        _damage += value;
    }
}
