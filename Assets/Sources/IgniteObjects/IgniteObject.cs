using UnityEngine;
using UnityEngine.Events;

public class IgniteObject : MonoBehaviour
{
    private const float ReductionValue = 0.003f;
    private const float MagnificationValue = 0.002f;

    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private ParticleSystem _smoke;

    private float _cooldown;
    private float _currentTime;
    private float _startSize;
    private bool _isExtinguishing;

    public event UnityAction Extinguished;

    public void Extinguish()
    {
        _currentTime = _cooldown;
        _fire.startSize -= ReductionValue;
    }

    private void Start()
    {
        _cooldown = 1f;
        _currentTime = 0;
        _startSize = _fire.startSize;
        _isExtinguishing = false;
    }

    private void Update()
    {
        if (_fire.startSize <= 0 && _isExtinguishing == false)
        {
            _isExtinguishing = true;
            _smoke.Play();
            _fire.Clear();
            _fire.Stop();
            Extinguished?.Invoke();
        }

        if (CheckTimer())
            ResumeBurning();

        _currentTime -= Time.deltaTime;
    }

    private void ResumeBurning()
    {
        if (_fire.startSize >= 0 && _fire.startSize < _startSize)
            _fire.startSize += MagnificationValue;
    }

    private bool CheckTimer()
    {
        if (_currentTime <= 0 && _isExtinguishing == false)
            return true;

        return false;
    }
}
