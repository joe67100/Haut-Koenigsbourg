using UnityEngine;
using Mirror;

public class PlayerHit : NetworkBehaviour
{
    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        if(cam == null)
        {
            Debug.LogError("Pas de cam�ra renseign�e sur le syst�me de hit");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hit();
        }
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
        Debug.Log(playerId + " a �t� touch�.");

        Player player = GameManager.GetPlayer(playerId);
        player.TakeDamage(damage);
    }

}
