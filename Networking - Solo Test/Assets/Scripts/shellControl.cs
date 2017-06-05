using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class shellControl : NetworkBehaviour {

    public float shellLifetime = 2f;
    public float age;

    [ServerCallback]public void Update()
    {
        age += Time.deltaTime;
        if (age > shellLifetime)
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}
