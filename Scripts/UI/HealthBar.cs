using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Vector3 DeltaPosition;

    private SpriteRenderer _spriteRenderer;
    private BaseCharacterController _character;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnDestroy()
    {
        if (_character)
        {
            _character.OnDamaged -= CharacterOnDamaged;
            _character.OnDied -= CharacterOnDied;
        }
    }

    public void SetCharacter(BaseCharacterController character)
    {
        _character = character;

        _character.OnDamaged += CharacterOnDamaged;
        _character.OnDied += CharacterOnDied;
    }

    private void CharacterOnDied()
    {
        Destroy(gameObject);
    }

    private void CharacterOnDamaged(float healthpercent)
    {
        SetHealthPercent(healthpercent);
    }

    void Update()
    {
        transform.position = _character.transform.position + DeltaPosition;
    }

    void SetHealthPercent(float percent)
    {
        Vector3 currentScale = transform.localScale;

        currentScale.x = percent;

        transform.localScale = currentScale;

        _spriteRenderer.color = percent < 0.4f ? Color.red : Color.white;
    }
}
