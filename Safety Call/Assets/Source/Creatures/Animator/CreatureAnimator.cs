using Source.Creatures.Movement;
using UnityEngine;

public abstract class CreatureAnimator : MonoBehaviour
{
    
    [SerializeField] protected Animator _legsAnimator;

    [SerializeField] protected Animator _upperAnimator;
    
    [SerializeField] protected CreatureMovement _movement;

    [SerializeField] protected Transform _rotation;
    
    [SerializeField] protected SpriteRenderer _bodySpriteRenderer;

    [SerializeField] private bool EulerZ;

    public float _rotationIndex;
    
    protected bool _isDead = false;

    protected virtual void Update()
    {
        _legsAnimator.SetFloat("Vertical", _movement.GetVerticalSpeed());
        _legsAnimator.SetFloat("Horizontal", _movement.GetHorizontalSpeed());
        _legsAnimator.SetFloat("Input", _movement.GetSpeed());
        _rotationIndex = _rotation.rotation.z;
        if(_rotation.rotation.eulerAngles.z == 0 && _rotation.rotation.eulerAngles.y != 0) EulerZ = false;
        if(_rotation.rotation.eulerAngles.z != 0 && _rotation.rotation.eulerAngles.y == 0) EulerZ = true;
        if (EulerZ)
        {
            _upperAnimator.SetFloat("Input", _rotation.rotation.eulerAngles.z);
        }
        else
        {
            _upperAnimator.SetFloat("Input", _rotation.rotation.eulerAngles.y);
        }
        if (_rotationIndex < 0.2f && _rotationIndex > -0.2f)
            _bodySpriteRenderer.sortingOrder = 5;
        else  
            _bodySpriteRenderer.sortingOrder = 3;
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
