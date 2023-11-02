using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{
    Rigidbody rb;

    //public GameObject projectile;
    //public Transform projectilePos;

    private Vector2 _move;
    private Vector2 rotate;

    //[Header("Player Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float sensitivity;
    [SerializeField] private int ammo;

    [SerializeField] private Weapon weapon;
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
            weapon.StartAttack();
        }
        else
        {
            weapon.EndAttack();
        }
        /*if (ammo > 0)
        {
            Rigidbody rbBullet = Instantiate(projectile, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
            rbBullet.AddForce(camFollowTarget.forward * 32f, ForceMode.Impulse);

            Destroy(rbBullet.gameObject, 4);
            ammo--;
        }*/
    }

    public void Reload()
    {
        ammo = 5;
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

    public void Die()
    {

    }

    public void TakeDamage(float damageTaken)
    {

    }
}
