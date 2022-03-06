using UnityEngine;

public class Point : MonoBehaviour
{
    protected bool _occupying;

    public bool Occuping => _occupying;

    public void MakeBusy(bool value)
    {
        _occupying = value;
    }
}
