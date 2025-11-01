using Source.Creatures.Movement;
using UnityEngine;

public abstract class CreatureAnimator : MonoBehaviour
{
    
    [SerializeField] protected Animator _legsAnimator;

    [SerializeField] protected Animator _upperAnimator;
    
    [SerializeField] protected CreatureMovement _movement;

    [SerializeField] protected Transform _rotation;
    
    [SerializeField] protected SpriteRenderer _bodySpriteRenderer;

    public float _rotationIndex;
    
    protected bool _isDead = false;

    protected void Update()
    {
        _legsAnimator.SetFloat("Vertical", _movement.GetVerticalSpeed());
        _legsAnimator.SetFloat("Horizontal", _movement.GetHorizontalSpeed());
        _legsAnimator.SetFloat("Input", _movement.GetSpeed());
        _rotationIndex = _rotation.rotation.z;
        _upperAnimator.SetFloat("Input", _rotation.rotation.z);
        if (_rotationIndex < 0.2f && _rotationIndex > -0.2f)
            _bodySpriteRenderer.sortingOrder = 3;
        else  
            _bodySpriteRenderer.sortingOrder = 1;
    }

    public void Death()
    {
        if(_isDead) return;
        _upperAnimator.SetTrigger("Death");
    }
    public void Revive()
    {
        _upperAnimator.SetTrigger("Revive");
    }
}
