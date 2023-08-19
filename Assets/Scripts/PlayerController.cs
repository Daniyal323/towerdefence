using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyJoystick;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 4f;
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    Animator anim;
    public Button shootButton;

    [SerializeField] private Joystick easyjoystick;


    private void Start()
    {
        anim = this.GetComponent<Animator>();
        shootButton.onClick.AddListener(Shoot);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = easyjoystick.Horizontal();
        float vertical = easyjoystick.Vertical();
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            anim.SetFloat("movement", 1);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(movDir.normalized * speed * Time.deltaTime);
        }
        else if (direction.magnitude == 0)
        {
            anim.SetFloat("movement", 0);
        }
        
    }
    void Shoot()
    {
        anim.SetBool("shoot", true);
    }
}
