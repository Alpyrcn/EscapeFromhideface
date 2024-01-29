using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    #region REFERENCES

    public GameObject projectilePrefab;

    private CharacterAnimator _animator;

    #endregion

    #region VARIABLES

    public float projectileLaunchDelay;

    #endregion


    #region MONOBEHAVIOUR

    private void Awake()
    {
        _animator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.Throw();
            Invoke("Throw", projectileLaunchDelay);
        }
    }

    #endregion

    #region METHODS

    private void Throw()
    {
        Vector3 exitPosition = transform.position + Vector3.up * 1f;

        GameObject projectile = Instantiate(projectilePrefab, exitPosition,  transform.rotation);
    }


    #endregion
}
