using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
    public GameObject[] agents;
    public GameObject[] obstacles;
    void Start() {
        agents = GameObject.FindGameObjectsWithTag("Agent");
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                foreach (GameObject agent in agents) {
                    if (agent.GetComponent<Unit>().selected == true) {
                        agent.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                    }
                }
            }
        }
	}

}
