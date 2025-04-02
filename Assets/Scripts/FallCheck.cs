using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    public BridgeManager bridgeManager;
    public BridgeSpawner bridgeSpawner;

    private void Start()
    {
        bridgeSpawner = GameObject.Find("BridgeManager").GetComponent<BridgeSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            //bridgeManager.canFall = true;
            bridgeSpawner.deactived = true;
        }
    }
}
