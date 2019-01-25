using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float vitesse;
    // Start is called before the first frame update
    void Start()
    {
        vitesse = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*vitesse , 0, 0);
    }
}
