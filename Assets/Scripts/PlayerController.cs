using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[Header("Player Stats")]
    [SerializeField] private float jump = 5f;
    private float walkingSpeed = 5f;
    private Vector2 move;

    void Start()
    {
        
    }

    private void Awake()
    {
        Inputs.Init(this);
    }

    public void setLook (Vector2 w)
    {

    }

    public void MoveTo(Vector2 s)
    {
        move = s;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (move.y * Time.deltaTime) * walkingSpeed, Space.Self);
        transform.Translate(Vector3.right * (move.x * Time.deltaTime) * walkingSpeed, Space.Self);
    }
}
