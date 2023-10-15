using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public GameObject projectile;
    public Transform projectilePos;

    private Vector2 _move;
    private Vector2 rotate;
    //private Vector2 currentAngle;

    //[Header("Player Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float sensitivity;

    [SerializeField, Range(0, 180)] private float viewAngleClamp = 40f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform camFollowTarget;

    /*[SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;

    [SerializeField, Range(-90, 0)] private float minViewAngle;
    [SerializeField, Range(0, 90)] private float maxViewAngle;*/
    bool isGrounded;

    void Start()
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
        Rigidbody rbBullet = Instantiate(projectile, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        rbBullet.AddForce(Vector3.forward*32f,ForceMode.Impulse);

        Destroy(rbBullet.gameObject, 4);
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
}
