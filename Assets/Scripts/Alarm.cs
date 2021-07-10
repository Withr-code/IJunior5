using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;

    public UnityEvent Opened;

    private Thief _thief;
    private AudioSource _audioSource;

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
        if(collision.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            _thief = thief;
            Opened?.Invoke();
        }
    }

    private void Update()
    {
        if (_thief != null)
            Fade(_thief.transform.position.x, transform.position.x, _endPoint.position.x);
    }

    private void Fade(float thiefPositionX, float target, float endPositionX)
    {
        if (thiefPositionX < target)
            _audioSource.volume = (thiefPositionX - endPositionX) / (target - endPositionX);
        else
            _audioSource.volume = (target * 2 - endPositionX - thiefPositionX) / (target - endPositionX);

        if (_audioSource.volume < 0)
            _audioSource.volume = 0;
    }
}
