using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float hAxis, vAxis;
    Vector2 direction;

    [SerializeField]
    float speed = 3;
    Animator animator;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Facing();
        Animations();
    }

    void Movement()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        direction = new Vector2 (hAxis, vAxis);
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void Facing()
    {
        if (hAxis < 0 )
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (hAxis > 0 )
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Animations()
    {
        // print(Mathf.Abs(hAxis));
        animator.SetFloat("MovingX", Mathf.Abs(hAxis));
        animator.SetFloat("MovingY", Mathf.Abs(vAxis));
    }
}
