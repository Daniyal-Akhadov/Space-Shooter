using UnityEngine;

public class EnemyAttaker : Shooter
{
    
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToAttak)
        {
            Shoot();
            _timer = 0f;
        }
    }
}
