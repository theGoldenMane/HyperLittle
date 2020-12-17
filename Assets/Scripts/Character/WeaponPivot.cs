using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{
    private void FixedUpdate()
    {
    	if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0){
     		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        	diff.Normalize();
        	float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        	transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
     	} else if (Input.GetAxis("Controller X") < 0 || Input.GetAxis("Controller X") > 0 || Input.GetAxis("Controller Y") < 0 || Input.GetAxis("Controller Y") > 0){
     		float joyx_pos = Input.GetAxis("Controller X");
     		float joyy_pos = Input.GetAxis("Controller Y");
     		float angle = Mathf.Atan2(joyy_pos, joyx_pos) * Mathf.Rad2Deg;
     		transform.rotation = Quaternion.Euler(0f, 0f, -angle);
     	}
    }
}
