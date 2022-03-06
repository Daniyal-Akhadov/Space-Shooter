using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Camera _main;

    private void Awake()
    {
        _main = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 offset = _main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, offset, _speed * Time.deltaTime);
        }
    }

}
