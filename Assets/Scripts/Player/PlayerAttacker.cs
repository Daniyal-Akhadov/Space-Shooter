using UnityEngine;

public class PlayerAttacker : Shooter
{
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToAttak && Input.GetMouseButton(0))
        {
            Shoot();
            _timer = 0f;
        }
    }

}
