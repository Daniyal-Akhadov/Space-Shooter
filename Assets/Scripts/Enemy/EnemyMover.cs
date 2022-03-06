using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _stopTime = 4;
    [SerializeField] private float _speed = 6;

    private MovePoint[] _movePoints;
    private float _toStopTimer;
    private MovePoint _target;


    private void Awake()
    {
        _movePoints = FindObjectsOfType<MovePoint>();
        _target = GetFreeRandomPoint();
        if (_target)
            _target.MakeBusy(true);
    }
    private void Update()
    {
        if (transform != null && _target != null
            && transform.position == _target.transform.position)
        {
            _toStopTimer += Time.deltaTime;
            if (_toStopTimer >= _stopTime)
            {
                _toStopTimer = 0f;
                _target.MakeBusy(false);
                _target = GetFreeRandomPoint();
                _target.MakeBusy(true);
            }
        }
        else
        {
            MoveTowardsRandomPoint();
        }
    }

    private void MoveTowardsRandomPoint()
    {
        if (_target != null)
        {
            transform.position = Vector2.MoveTowards(
                    transform.position,
                    _target.transform.position,
                    _speed * Time.deltaTime
                );
        }

    }

    private MovePoint GetFreeRandomPoint()
    {
        var point = _movePoints[Random.Range(0, _movePoints.Length)];

        if (point.Occuping)
        {
            point = null;
            for (int i = 0; i < _movePoints.Length; i++)
            {
                if (_movePoints[i].Occuping == false)
                {
                    point = _movePoints[i];
                    break;
                }
            }
        }
        return point;
    }

    private void OnDisable()
    {
        if (_target)
            _target.MakeBusy(false);
    }
}
