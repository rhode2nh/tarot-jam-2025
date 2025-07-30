using Animancer;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    private AnimancerComponent _animancer;
    [SerializeField] private AnimationClip _hover;
    [SerializeField] private AnimationClip _unhover;
    [SerializeField] private AnimationClip _idle;
    [SerializeField] private AnimationClip _flip;

    private void Awake()
    {
        _animancer = GetComponent<AnimancerComponent>();
    }

    public void Hover()
    {
        Debug.Log("hovering");
        _animancer.Play(_hover);
    }

    public void Unhover()
    {
        _animancer.Play(_unhover);
    }

    public void Flip()
    {
        _animancer.Play(_flip);
    }
} 
