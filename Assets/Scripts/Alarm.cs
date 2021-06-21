using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Transform _thiefTransform;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private UnityEvent _opened;
    [SerializeField] private float _timeToFade;

    private AudioSource _audioSource;
    private float _endPoint;
    private float _target;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _endPoint = _endPosition.position.x;
        _target = transform.position.x;
    }

    private void Update()
    {
        if (transform.position.x < _thiefTransform.position.x)
        {
            _opened?.Invoke();
        }

        Fade();
    }

    private void Fade()
    {
        if (_thiefTransform.position.x < _target)
            _audioSource.volume = (_thiefTransform.position.x - _endPoint) / (_target - _endPoint);
        else
            _audioSource.volume = (_target * 2 - _endPoint  - _thiefTransform.position.x) / (_target - _endPoint);

        if (_audioSource.volume < 0)
            _audioSource.volume = 0;
    }
}
