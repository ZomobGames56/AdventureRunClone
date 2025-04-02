using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    public List<GameObject> bridges = new List<GameObject>();
    public List<GameObject> activeBridges = new List<GameObject>();
    public List<GameObject> deactiveBridges = new List<GameObject>();
    public bool deactived = false;
    private int count = 8;
    private int i = 0;

    private void Start()
    {
        //foreach (GameObject a in bridges)
        //{
        //    GameObject t = (GameObject)Instantiate(a, );
        //    activeBridges.Add(t);
        //}
        activeBridges.Add(Instantiate(bridges[0]));
        for (int i = 1; i < bridges.Count; i++)
        {
            GameObject t = Instantiate(bridges[i], activeBridges[activeBridges.Count - 1].transform.GetChild(3));
            t.transform.SetParent(null);
            activeBridges.Add(t);
        }
    }

    private void Update()
    {
        if (deactived)
        {
            GameObject temp = activeBridges[0];
            //deactiveBridges.Add(bridges[bridges.IndexOf(activeBridges[0])]);
            deactiveBridges.Add(bridges[i]);
            //deactiveBridges.Add(temp);
            Destroy(temp);
            activeBridges.RemoveAt(0);
            deactived = false;
            i++;
            if (i > 7) i = 0;
            int random = Random.Range(1, 101);
            if (random % 2 == 0)
            {
                StartCoroutine(RandomFall(activeBridges[1].transform.GetChild(1).gameObject));
            }
            else
            {
                StartCoroutine(RandomFall(activeBridges[1].transform.GetChild(2).gameObject));
            }
        }

        if(activeBridges.Count < 7)
        {
            // 5f + (count * 10f)
            GameObject t = Instantiate(deactiveBridges[0], activeBridges[activeBridges.Count - 1].transform.GetChild(3));
            t.transform.SetParent(null);
            activeBridges.Add(t);
            deactiveBridges.Remove(deactiveBridges[0]);
            count++;
            if (count % 5 == 0)
            {
                Time.timeScale += 0.1f * Time.timeScale;
                Debug.Log(Time.timeScale);
            }
        }
    }

    IEnumerator RandomFall(GameObject obj)
    {
        yield return new WaitForSeconds(1.15f);
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1f);
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
