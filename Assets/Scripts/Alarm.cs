using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;

    private Thief _thief;
    private AudioSource _audioSource;

    public UnityEvent Opened;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.playOnAwake = false;
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            _thief = thief;
            Opened?.Invoke();
        }
    }

    private IEnumerator Fade(float doorPositionX, float endPositionX)
    {
        while (_thief.transform.position.x > endPositionX)
        {
            _audioSource.volume = (_thief.transform.position.x - endPositionX) / (doorPositionX - endPositionX);

            yield return null;
        }

        _audioSource.volume = 0;
    }

    public void StartFade()
    {
        StartCoroutine(Fade(transform.position.x, _endPoint.position.x));
    }
}