using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chevalier_Deplacement : MonoBehaviour
{
    public float vitesse = 10f;
    private bool echelleaporte = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (echelleaporte) {
            transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*vitesse , Input.GetAxis("Vertical") * Time.deltaTime * vitesse, 0);
        }else{
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * vitesse, 0, 0);
        }
        // GetComponent<Rigidbody2D>().isKinematic = echelleaporte;
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
}
