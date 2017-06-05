using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class shoot : NetworkBehaviour {

    public float power = 800f;
    public GameObject shellPrefab;
    public Transform gunBarrel;

    public void Reset()
    {
        gunBarrel = transform.FindChild("GunBarrel");
    }

    public void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            CmdSpawnShell();
        }
    }

    [Command]
    public void CmdSpawnShell()
    {
        GameObject instance = Instantiate(shellPrefab, gunBarrel.position, gunBarrel.rotation) as GameObject;
        instance.GetComponent<Rigidbody>().AddForce(gunBarrel.forward * power);
        NetworkServer.Spawn(instance);
    }
}
