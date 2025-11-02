using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100.0f;

    private float _minHealth = 0.0f;
    private float _currentHealth;

    public event Action DamageTaken;

    public bool IsAlive => _currentHealth > _minHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Increase(float heal)
    {
        if (heal > 0)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + heal, _minHealth, _maxHealth);
        }
    }

    public void Decrease(float damage)
    {
        if (damage > 0)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);

            DamageTaken?.Invoke();
        }
    }
}