using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chevalier_Attaque : MonoBehaviour
{

    public bool attaque = false;

    private float attaqueTimer = 0;
    public float attaqueCooldown = 0.3f;

    public Collider2D attaqueTrigger;
    public GameObject bassinAnnimation;

    //private Animator anim;

    void Awake()
    {
        //anim = gameObject.GetComponent<Animator>();
        attaqueTrigger.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        attaque = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") != 0 && !attaque){
            Debug.Log("fiya");
            attaque = true;

            attaqueTimer = attaqueCooldown;
            
            attaqueTrigger.enabled = true;
            playAnnimationBassin();
            playHitSound();
        }

        if (attaque)
        {
            if (attaqueTimer > 0)
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

    public void playAnnimationBassin()
    {
        //    gameObject.GetComponent<ChevalierAnnimationsScript>().GetComponent<Animator>().SetTrigger("Attaque");
        Debug.Log("debut anim");
        bassinAnnimation.GetComponent<Animator>().SetTrigger("Attaque");
        Debug.Log("fin anim");
    }
}
