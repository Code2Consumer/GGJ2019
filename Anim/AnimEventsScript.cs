using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playFootstep(){
		GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playFootstep();
    }
}
