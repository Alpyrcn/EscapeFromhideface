using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Walk(float input)
    {
        _animator.SetBool("Walking", input != 0);
       
    }

    

    public void Throw()
    {
        _animator.SetTrigger("throw");
    }
}
