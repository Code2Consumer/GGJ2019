﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chevalier_Attaque : MonoBehaviour
{

    private bool attaque = false;

    private float attaqueTimer = 0;
    float attaqueCooldown = 0.3f;

    public Collider2D attaqueTrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attaqueTrigger.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") != 0 && !attaque){
            attaque = true;
            // anim.SetTrigger("Attaque");
            attaqueTimer = attaqueCooldown;

            attaqueTrigger.enabled = true;
            playHitSound();
        }

        if (attaque)
        {
            if(attaqueTimer > 0)
            {
                attaqueTimer -= Time.deltaTime;
            }
            else
            {
                attaque = false;
                attaqueTrigger.enabled = false;
            }
        }
        
        
    }
    void playHitSound(){
        GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playAttack();
    }
}
