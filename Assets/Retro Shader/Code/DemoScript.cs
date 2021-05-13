using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {

    public GameObject[] ObjectPool;
    public GameObject Sun;
    public float floatSpeed = 1f;
    public Transform RefreshPivot;
    public Transform TerrainRefreshPivot;
    public float speed  = 1f;
    
	// Make them closer each second
	void Update () {
        foreach(GameObject ob in ObjectPool)
        {
            ob.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        Sun.transform.Translate(Vector3.up * Time.deltaTime * floatSpeed * Mathf.Sin(Time.time) * 0.2f); 
    }

    // Make sure that your terrain marked with layer 'Terrain' - Number 24
    // Position changing stuff
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 24)
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, TerrainRefreshPivot.transform.position.z);
        }
        else
        {
            other.gameObject.transform.position = RefreshPivot.transform.position;
        }
    }

}
