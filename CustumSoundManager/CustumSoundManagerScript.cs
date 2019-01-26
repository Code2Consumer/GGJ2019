using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustumSoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.RegisterGameObj(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    	//AK GAME OBJECT
        //AkSoundEngine.PostEvent( "Attack_Miss", gameObject);
    }

    public void playAttack(){
    	AkSoundEngine.PostEvent( "Attack", gameObject);
    }

    public void playKill(){
		AkSoundEngine.PostEvent( "Kill", gameObject);
    }

    public void playGameOver(){
		AkSoundEngine.PostEvent( "Game_Over", gameObject);
    }

    public void playGameStart(){
		AkSoundEngine.PostEvent( "Game_Start", gameObject);
    }

    public void playHealthLoss(){
		AkSoundEngine.PostEvent( "Health_Loss", gameObject);
    }

    public void playMenu(){
		AkSoundEngine.PostEvent( "Menu", gameObject);
    }

    public void playFootstep(){
		AkSoundEngine.PostEvent( "Player_Footstep", gameObject);
    }

    public void playTeleportSound(){
		AkSoundEngine.PostEvent( "Teleport", gameObject);
    }
}