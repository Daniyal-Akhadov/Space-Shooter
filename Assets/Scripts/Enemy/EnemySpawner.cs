using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyPrefab;
    [SerializeField] private SpawnPoint[] _points;
    [SerializeField] private float _minSpawnTime = 2.5f;
    [SerializeField] private float _maxSpawnTime = 4f;

    private float _time;
    private float _spawnTimer;

    private void Start()
    {
        _time = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _time)
        {
            _time = Random.Range(_minSpawnTime, _maxSpawnTime);
            _spawnTimer = 0;
            CreateEnemy();
        }


    }
    private SpawnPoint GetRandomPoint()
    {
        var point = _points[Random.Range(0, _points.Length)];
        return point;
    }

    private void CreateEnemy()
    {

        var pointPosition = GetRandomPoint();

        var newEnemy = Instantiate(
            _enemyPrefab,
            pointPosition.transform.position,
            transform.rotation
           );

    }

}


