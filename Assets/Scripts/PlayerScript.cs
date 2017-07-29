using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Mouse hit");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out  hitInfo))
            {
                //Debug.Log("Out data --> " + hitInfo.collider.tag);
                if (hitInfo.collider.tag.Equals("WhitePawn"))
                {
                    //Debug.Log("White pawn was hit! :D");
                }
            }
        }
    }
}
