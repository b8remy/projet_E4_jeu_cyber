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
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
            //.Play("walk");
        }
        //si on recule
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -(walkSpeed) / 2 * Time.deltaTime);
            //animations.Play("walk");
        }
        //si on court
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runspeed * Time.deltaTime);
            //animations.Play("run");
        }
        //rotation à gauche
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, (-turnspeed) * Time.deltaTime, 0);
        }
        //rotation à droite
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnspeed * Time.deltaTime, 0);
        }

        /* si on ne fait rien
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            animations.Play("idle");
        }*/
    }
}
