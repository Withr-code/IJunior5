using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _currentStrength;
    [SerializeField] private float _maxStrength;
    [SerializeField] private float _maxDelta;

    private void Update()
    {
        transform.Translate(Mathf.MoveTowards(_currentStrength, _maxStrength, _maxDelta) * Time.deltaTime, 0, 0);
    }

    private void OnValidate()
    {
        if (_currentStrength > _maxStrength)
            _maxStrength = _currentStrength;
    }

    public void ChangeDirection()
    {
        _currentStrength *= -1;
        _maxStrength *= -1;
    }
}
