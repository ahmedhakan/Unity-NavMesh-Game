using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    private AttackRadius AttackRadius;
    [SerializeField]
    private Animator Animator;
    private Coroutine LookCoroutine;
    [SerializeField] private Healthbar _healthbar;
    [SerializeField] private LoseMenu loseMenu;

    [SerializeField]
    private int Health = 300;

    private int _maxHealth;
    private int _currentHealth;

    private const string ATTACK_TRIGGER = "Attack"; // Trigger animation


    private void Awake()
    {
        _maxHealth = Health; 
        _currentHealth = Health; 

        AttackRadius.OnAttack += OnAttack;
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth); // Updates the healthbar UI
    }

    private void OnAttack(IDamageable Target)
    {
        Animator.SetTrigger(ATTACK_TRIGGER); // Animation

        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt(Target.GetTransform())); // Rotate
    }

    private IEnumerator LookAt(Transform Target) // Smoothly rotation
    {
        Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

            time += Time.deltaTime * 2;
            yield return null;
        }

        transform.rotation = lookRotation;
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        _currentHealth = Mathf.Max(0, Health); // Update current health
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth); // Update Healthbar
        if (Health <= 0)
        {
            Health = 0;
            loseMenu.ShowLoseMenu(); // Shows Lose Screen when dies
            gameObject.SetActive(false);
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
