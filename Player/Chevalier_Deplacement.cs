using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chevalier_Deplacement : MonoBehaviour
{
    public float vitesse                        = 10f;
    public float scorePerEnemyKilled            = 100;
    public float enemyNecessairePourFullRage    = 2;
    
    public float score                          = 0;
    public float scoreDejaUtilise               = 0;
    
    private bool echelleaporte                  = false;
    private bool canUseAbility                  = false;
    private Vector3 spawnPosition               = new Vector3(-13, 1.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * vitesse *-1;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * vitesse *-1;

        if (Input.GetAxis("Horizontal") < 0) { transform.eulerAngles = new Vector3(0, 180, 0); x = -x; }
        else transform.eulerAngles = new Vector3(0, 0, 0); x = -x ;

        if (echelleaporte) {
            transform.Translate( x, y, 0);
        }else{
            transform.Translate(x, 0, 0);
        }


        if((score-scoreDejaUtilise)/scorePerEnemyKilled >= enemyNecessairePourFullRage){
            canUseAbility = true ;
        }else{
            canUseAbility = false;
        }

        if(canUseAbility && Input.GetKeyDown("space")){
            teleportToSpawn();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Echelle")
        {
            echelleaporte = true;
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Echelle")
        {
            echelleaporte = false;
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
    }

    public void addPointsToScore(){
        score = score + scorePerEnemyKilled;
    }

    void teleportToSpawn(){
        scoreDejaUtilise = score;
        GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playTeleportSound();
        gameObject.transform.position = spawnPosition;
        GameObject.Find("Canvas").GetComponent<HUDScript>().updateScore();
    }
}
