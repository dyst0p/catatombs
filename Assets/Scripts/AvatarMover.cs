using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            TeleportForward();
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
    }

    private void TeleportForward()
    {
        Debug.Log("Start teleport");
        var direction = transform.forward;
        var hits = Physics.RaycastAll(transform.position, direction, 2f);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Start collider {hit.transform}");
            if (hit.transform.gameObject != gameObject)
            {
                transform.position = hit.transform.position;
                Debug.Log($"Collided with {hit.transform}");
                return;
            }
        }
    }
}
