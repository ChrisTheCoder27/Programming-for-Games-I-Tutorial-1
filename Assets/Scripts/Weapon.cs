using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private Coroutine timerCoroutine;
    protected float currentChargeTime;
    private bool atkTimerDone = true;
    [SerializeField] protected float ammo;

    protected Rigidbody owner;

    [field: SerializeField] public float contactDamage { get; private set; }
    [field: SerializeField] public float chargeTime { get; private set; }
    [field: SerializeField, Range(0,1)] public float minCharge { get; private set; }
    [field: SerializeField] public float cost { get; private set; }

    public WaitForSeconds CoolDown { get; private set; }
    [SerializeField] private float coolDown;

    private void OnEnable()
    {
        CoolDown = new WaitForSeconds(coolDown);
    }

    public float GetCost()
    {
        return cost;
    }

    protected abstract void Attack(float chargePercent);

    protected virtual bool CanAttack()
    {
        return atkTimerDone;
    }

    protected void Reload()
    {
        ammo = 12;
    }

    private void TryAttack(float percent)
    {
        if(percent < minCharge)
        {
            return;
        }

        Attack(percent);
            StartCoroutine(CoolDownTimer());
    }

    private IEnumerator CoolDownTimer()
    {
        atkTimerDone = false;
        yield return CoolDown;
        atkTimerDone = true;
    }
    
    public void StartAttack()
    {
        timerCoroutine = StartCoroutine(HandleCharge());
    }

    private IEnumerator HandleCharge()
    {
        currentChargeTime = 0;
        print("StartCharge");
        yield return new WaitUntil(() => atkTimerDone);
        print("CoolDownDone");

        while(currentChargeTime < chargeTime)
        {
            currentChargeTime += Time.deltaTime;
            yield return null;
        }
        print("Attack Completed");
        TryAttack(1);
        timerCoroutine = StartCoroutine(HandleCharge());
    }

    public void EndAttack()
    {
        StopCoroutine(timerCoroutine);
        TryAttack(currentChargeTime / chargeTime);
    }
    private void OnTransformParentChanged()
    {
        owner = transform.root.GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        owner = transform.root.GetComponent<Rigidbody>();
    }

}
