using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public new Transform camera;
    public Collider hitBox;
    public PlayerInfo playerStatus;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    public float grav = -0.9f;
    private bool rolling;
    float turnSmoothVelocity;

    //Sound Cooldowns
    private float rollSoundCooldown = 1.8f;
    private float rollSoundNext = 0f;

    private float attackSoundCooldown = 1f;
    private float attackSoundNext = 0f;

    private float stepSoundCooldown = 0.3f;
    private float stepSoundNext = 0f;


    void Update()
    {
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        int attack1 = (int) Input.GetAxisRaw("Fire1");
        int roll = (int)Input.GetAxisRaw("Jump");
        Vector3 direction = new Vector3(horz, 0f, vert).normalized;
        if(transform.position.y <= 0)
        {
            FindObjectOfType<AudioManager>().StopPlaying("Music");
        }

        if (roll != 0 && playerStatus.stamina > 0 && (horz != 0 || vert !=0))
        {
            anim.SetBool("Roll", true);
            if (Time.time > rollSoundNext)
            {
                FindObjectOfType<AudioManager>().Play("Roll");
                rollSoundNext = Time.time + rollSoundCooldown;
            }
        }
        else
        {
            anim.SetBool("Roll", false);

        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Roll") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.25f && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.55f)
        {
            rolling = true;

        }
        else
        {
            rolling = false;

        }

        if (direction.magnitude >= 0.1f)
        {
            if (Time.time > stepSoundNext && !isRolling())
            {
                FindObjectOfType<AudioManager>().Play("Step");
                stepSoundNext = Time.time + stepSoundCooldown;
            }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            Gravity();
        }
        anim.SetFloat("Forward", direction.magnitude, 0.1f, Time.deltaTime);

        if (playerStatus.stamina > 0 && attack1 == 1)
        {
            anim.SetInteger("Attack", attack1);
            if (Time.time > attackSoundNext && !isRolling())
            {
                FindObjectOfType<AudioManager>().Play("Swing");
                attackSoundNext = Time.time + attackSoundCooldown;
            }
        }
        else
        {
            anim.SetInteger("Attack", 0);
        }
    }

    //cause rigidbody breaks everything
    void Gravity()
    {
        transform.Translate(new Vector3(0f, grav, 0f));
    }

    public bool isRolling()
    {
        return rolling;
    }
}
