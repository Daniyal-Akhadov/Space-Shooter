using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyBullet = collision.gameObject.GetComponent<EnemyBullet>();
        if (enemyBullet)
        {
            TakeDamage(enemyBullet.Damage);
            Destroy(enemyBullet.gameObject);
            if (_healthValue <= 0)
            {
                PlayerPrefs.Save();
                SceneManager.LoadScene(0);
            }

        }
    }


}
