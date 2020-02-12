using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerBehavior : MonoBehaviour
{
    /// <summary>
    /// le rigidbody du player
    /// </summary>
    Rigidbody2D rgbPlayer;
    /// <summary>
    /// la vitesse qui sera multiplié a get axis raw de l'as x et y (soit speed * entre0 et 1)
    /// </summary>
    public float speedPlayer;
    /// <summary>
    /// variable qui stock le get axis raw horizontal soit entre 0 et 1
    /// </summary>
    float XAxis;
    /// <summary>
    /// variable qui stock el get axis raw vertical soit entre 0 et 1
    /// </summary>
    float YAxis;

    bool hasWeapon = false;

    /// <summary>
    /// animator sur le player
    /// </summary>
    Animator animatorPlayer;
    void Start()
    {
        rgbPlayer = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponentInChildren<Animator>();
    }

    
    void FixedUpdate()
    {

       
            // deplacement basique du personnage
        XAxis = Input.GetAxisRaw("Horizontal");
        YAxis = Input.GetAxisRaw("Vertical");
        if (!animatorPlayer.GetBool("IsAttacking"))
            rgbPlayer.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speedPlayer;
        else
            rgbPlayer.velocity = Vector2.zero;

        // set up des flaot et bool de l'animator pour repérer le déplacement du joueur
        if (rgbPlayer.velocity != Vector2.zero )
        {
            animatorPlayer.SetBool("IsMoving", true);
            animatorPlayer.SetFloat("SpeedX",  XAxis);
            animatorPlayer.SetFloat("SpeedY",YAxis);
        }
        else
            animatorPlayer.SetBool("IsMoving", false);
       


    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            animatorPlayer.SetBool("IsAttacking", true);
            animatorPlayer.SetBool("HasWeapon", hasWeapon);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            animatorPlayer.SetBool("IsAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            hasWeapon = !hasWeapon;
        }


    }
}
