using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Transform _thiefPosition;
    [SerializeField] private UnityEvent _opened;

    private void Update()
    {
        if (transform.position.x < _thiefPosition.position.x)
            _opened?.Invoke();
    }
}
