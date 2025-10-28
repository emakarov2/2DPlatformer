using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Attack : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private float _range = 1;
    private float _damage = 10;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Strike()
    {
        Enemy enemy = TryGetTarget();

        if (enemy != null)
        {
            enemy.AcceptAttack(_damage);
        }
    }

    private Enemy TryGetTarget()
    {
        float playerHalfWidht = _spriteRenderer.bounds.size.y / 2;

        Vector2 rayStart = transform.position + transform.right * playerHalfWidht;

        RaycastHit2D hit = Physics2D.Raycast(
        rayStart,
        transform.right,
        _range
              );

        if (hit.collider != null && hit.collider.TryGetComponent(out Enemy component))
        {
            return component;
        }

        return null;
    }
}