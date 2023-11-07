using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{
    Rigidbody rb;

    private Vector2 _move;
    private Vector2 rotate;

    //Weapons
    public GameObject[] guns;
    public bool usingShotgun;
    public bool usingSniper;
    public bool usingSubGun;

    //[Header("Player Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float sensitivity;

    [SerializeField] public Weapon weapon;
    [SerializeField] public Weapon weapon2;
    [SerializeField] public Weapon weapon3;
    private bool isAttacking;

    [SerializeField, Range(0, 180)] private float viewAngleClamp = 40f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform camFollowTarget;

    bool isGrounded;

    public float health { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Inputs.Init(this);
        usingShotgun = true;
        usingSniper = false;
        usingSubGun = false;
    }
    

    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime * _move.y), Space.Self);
        transform.Translate(Vector3.right * (speed * Time.deltaTime * _move.x), Space.Self);
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
    }

    public void Shoot()
    {
        isAttacking = !isAttacking;
        if (isAttacking)
        {
            if (usingShotgun)
            {
                weapon.StartAttack();
            }
            else if (usingSniper)
            {
                weapon2.StartAttack();
            }
            else if (usingSubGun)
            {
                weapon3.StartAttack();
            }
        }
        else
        {
            if (usingShotgun)
            {
                weapon.EndAttack();
            }
            else if (usingSniper)
            {
                weapon2.EndAttack();
            }
            else if (usingSubGun)
            {
                weapon3.EndAttack();
            }
        }
    }

    public void SetLook(Vector2 direction)
    {
        rotate = direction;
        transform.rotation *= Quaternion.AngleAxis(direction.x * sensitivity, Vector3.up);
        camFollowTarget.rotation *= Quaternion.AngleAxis(direction.y * -sensitivity, Vector3.right);

        Vector3 angles = camFollowTarget.eulerAngles;
        float anglesX = angles.x;
        if (anglesX > 180 && anglesX < 360-viewAngleClamp)
        {
            anglesX = 360 - viewAngleClamp;
        }
        else if (anglesX < 180 && anglesX > viewAngleClamp)
        {
            anglesX = viewAngleClamp;
        }
        camFollowTarget.localEulerAngles = new Vector3(anglesX, 0, 0);
    }

    public void Move(Vector2 direction)
    {
        _move = direction;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }

    public void SwitchToShotgun()
    {
        if (usingShotgun)
        {
            Debug.Log("Already holding shotgun.");
        }
        else if (!usingShotgun)
        {
            usingSniper = false;
            usingSubGun = false;
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[0].SetActive(true);
            usingShotgun = true;
        }
    }

    public void SwitchToSniper()
    {
        if (usingSniper)
        {
            Debug.Log("Already holding sniper.");
        }
        else if (!usingSniper)
        {
            usingShotgun = false;
            usingSubGun = false;
            guns[0].SetActive(false);
            guns[2].SetActive(false);
            guns[1].SetActive(true);
            usingSniper = true;
        }
    }

    public void SwitchToSubGun()
    {
        if (usingSubGun)
        {
            Debug.Log("Already holding submachine gun.");
        }
        else if (!usingSubGun)
        {
            usingSniper = false;
            usingShotgun = false;
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
            usingSubGun = true;
        }
    }

    public void Die()
    {

    }

    public void TakeDamage(float damageTaken)
    {

    }
}
