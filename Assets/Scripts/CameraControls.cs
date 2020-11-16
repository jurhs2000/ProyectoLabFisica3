using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);

        if (Input.GetKey(KeyCode.RightArrow))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);

        if (Input.GetKey(KeyCode.UpArrow))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);

        if (Input.GetKey(KeyCode.DownArrow))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);

        if (Input.GetKey(KeyCode.W)
            && gameObject.GetComponent<Camera>().orthographicSize > 1)
            gameObject.GetComponent<Camera>().orthographicSize = gameObject.GetComponent<Camera>().orthographicSize - 1;

        if (Input.GetKey(KeyCode.S)
            && gameObject.GetComponent<Camera>().orthographicSize < 100)
            gameObject.GetComponent<Camera>().orthographicSize = gameObject.GetComponent<Camera>().orthographicSize + 1;
    }
}
