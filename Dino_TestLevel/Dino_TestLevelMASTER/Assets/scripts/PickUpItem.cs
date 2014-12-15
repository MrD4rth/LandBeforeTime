using UnityEngine;
using System.Collections;

public class PickUpItem : MonoBehaviour {
	GameObject MainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;

	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry(carriedObject);
			checkDrop();
		} else {
			pickup();
		}
	}

	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, MainCamera.transform.position + MainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}
	
	void pickup() {
		if(Input.GetKeyDown(KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = MainCamera.camera.ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
					if(p != null) {
						carrying = true;
						carriedObject = p.gameObject;
						p.gameObject.rigidbody.isKinematic = true;
					}
				}
			}
		}
	
		void checkDrop() {
			if(Input.GetKeyDown(KeyCode.E)) {
				dropObject();
		}
	}

	void dropObject() {
		carrying = false;
		carriedObject.gameObject.rigidbody.isKinematic = false;
		carriedObject = null;
	}
}