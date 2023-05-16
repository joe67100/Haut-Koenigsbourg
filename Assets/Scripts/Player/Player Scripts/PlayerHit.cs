using UnityEngine;
using Mirror;
using System.Collections;

public class PlayerHit : NetworkBehaviour
{
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private bool canHit = true; // Traque si le joueur peut attaquer ou pas

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("Pas de caméra renseignée sur le système de hit");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if(!isLocalPlayer ||!canHit)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(HitCooldown());
            Hit();
        }
    }

    private IEnumerator HitCooldown()
    {
        canHit = false; // Désactiver le coup temporairement
        yield return new WaitForSeconds(2f);
        canHit = true;
    }

    [Client]
    private void Hit()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, mask) )
        {
            if (hit.collider.tag == "Player")
            {
                CmdPlayerHit(hit.collider.name, weapon.damage);
            }
        }
    }

    [Command]
    private void CmdPlayerHit(string playerId, float damage)
    {
        Debug.Log(playerId + " a été touché.");

        Player player = GameManager.GetPlayer(playerId);
        player.RpcTakeDamage(damage);
    }

}
