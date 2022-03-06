using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionY;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionY += _speed * Time.deltaTime;
        _imagePositionY = _imagePositionY > 1 ? 0 : _imagePositionY;
        _image.uvRect = new Rect(0f, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }
}
