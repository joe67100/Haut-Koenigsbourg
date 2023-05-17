using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public Transform player;

    
    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        // Camera tourne avec le joueur 
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
    
    // n'affiche pas les reflets 
    void OnPreRender()
    {
        GL.invertCulling = true;
    }
}
