using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_script : MonoBehaviour
{
    public GameObject player;
    public GameObject arrow;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //pivote l'image (uniquement valeur z de l'image) en fonction de la rotation de la caméra du joueur
        arrow.transform.rotation = Quaternion.Euler(0, 0, -player.transform.rotation.eulerAngles.y - 23);
    }
}
