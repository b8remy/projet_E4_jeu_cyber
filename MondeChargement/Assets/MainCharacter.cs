using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    // Animation du perso

    Animation animations;

    //Vitesse de déplacement

    public float walkSpeed;
    public float runspeed;
    public float turnspeed;

    //inputs

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //si on avance
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            animations.Play("walk");
        }
        //si on court
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runspeed * Time.deltaTime);
            animations.Play("run");
        }
        //si on recule
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -(walkSpeed) / 2 * Time.deltaTime);
            animations.Play("walk");
        }
        //rotation à gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, (-turnspeed) * Time.deltaTime, 0);
        }
        //rotation à gauche
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, turnspeed * Time.deltaTime, 0);
        }

        // si on ne fait rien
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            animations.Play("idle");
        }
    }
}
