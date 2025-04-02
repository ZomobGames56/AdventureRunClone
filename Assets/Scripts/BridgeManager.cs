using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public List<GameObject> leftBridges = new List<GameObject>();
    public List<GameObject> rightBridges = new List<GameObject>();
    public float cooldown;
    public float fallCooldown;
    public bool canFall;
    private float timer;
    private float randomTimer;

    private void Update()
    {
        randomTimer += Time.deltaTime;
        if (canFall)
        {
            StopAllCoroutines();
            StartCoroutine(Fall(leftBridges[0],rightBridges[0]));
            UpdateList(leftBridges);
            UpdateList(rightBridges);
            timer = 0;
            Time.timeScale += 0.01f * Time.timeScale;
            canFall = false;
        }

        if (randomTimer > fallCooldown)
        {
            int random = Random.Range(0, 2);
            if(random == 1)
            {
                StartCoroutine(RandomFall(leftBridges[2]));
            }
            else
            {
                StartCoroutine(RandomFall(rightBridges[2]));
            }
            randomTimer = 0;
        }
    }

    void UpdateList(List<GameObject> bridges)
    {
        for(int i = 0; i < bridges.Count - 1; i++)
        {
            GameObject temp = bridges[i+1];
            bridges[i + 1] = bridges[i];
            bridges[i] = temp;
        }
    }

    IEnumerator RandomFall(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1f);
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    IEnumerator Fall(GameObject obj1, GameObject obj2)
    {
        Rigidbody rb1 = obj1.GetComponent<Rigidbody>();
        Rigidbody rb2 = obj2.GetComponent<Rigidbody>();
        rb1.useGravity = true;
        rb2.useGravity = true;
        yield return new WaitForSeconds(1f);
        rb1.useGravity = false;
        rb2.useGravity = false;
        rb1.velocity = Vector3.zero;
        rb2.velocity = Vector3.zero;
        float oldPos = obj1.transform.position.z;
        while (obj1.transform.position.z != oldPos + 41f || obj2.transform.position.z != oldPos + 41f)
        {
            obj1.transform.position = Vector3.MoveTowards(obj1.transform.position, new Vector3(obj1.transform.position.x, 0, oldPos + 41f), 40f * Time.deltaTime);
            obj2.transform.position = Vector3.MoveTowards(obj2.transform.position, new Vector3(obj2.transform.position.x, 0, oldPos + 41f), 40f * Time.deltaTime);
            yield return null;
        }
    }
}