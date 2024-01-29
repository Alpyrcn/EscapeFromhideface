using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region REFERENCES

    public ParticleSystem explosion;

    #endregion

    #region VARIABLES

    public float _speed;
    public float _life;
    public float _damage;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _speed;
        Invoke("Die", _life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemyScript))
        {
            enemyScript.UpdateHealth(-_damage);
        }

        explosion.transform.parent = null;
        explosion.Play();

        Destroy(gameObject);
    }

    #endregion

    #region METHODS

    private void Die()
    {
        Destroy(gameObject);
    }


    #endregion

}