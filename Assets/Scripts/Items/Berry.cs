using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Berry : Coin
{
    [SerializeField] private float _hpCount = 25;

    public float HpCount => _hpCount;
}