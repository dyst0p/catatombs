using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMover : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;

    private Transform _movementTarget;
    private Vector3 _forwardTarget;

    private void Start()
    {
        _forwardTarget = transform.forward;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            GoForward();
        if (Input.GetKey(KeyCode.S))
            GoBackward();
        if (Input.GetKey(KeyCode.A))
            TurnLeft();
        if (Input.GetKey(KeyCode.D))
            TurnRight();
        if (Input.GetKey(KeyCode.Q))
            StrafeLeft();
        if (Input.GetKey(KeyCode.E))
            StrafeRight();

        if (_movementTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _movementTarget.position,
                _movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _movementTarget.position) < 0.01f)
            {
                transform.position = _movementTarget.position;
                _movementTarget = null;
            }
        }

        if (transform.forward != _forwardTarget)
        {
            transform.forward = Vector3.RotateTowards(transform.forward, _forwardTarget,
                _rotationSpeed * Time.deltaTime, 0);
            if (Vector3.Angle(transform.forward, _forwardTarget) < 1)
                transform.forward = _forwardTarget;
        }
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

    private void GoForward()
    {
        if (_movementTarget != null)
            return;
        
        Debug.Log("Start movement");
        var direction = transform.forward;
        var hits = Physics.RaycastAll(transform.position, direction, 2f);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Start collider {hit.transform}");
            if (hit.transform.gameObject != gameObject)
            {
                _movementTarget = hit.transform;
                Debug.Log($"Collided with {hit.transform}");
            }
        }
    }
    
    private void GoBackward()
    {
        if (_movementTarget != null)
            return;
        
        Debug.Log("Start movement");
        var direction = -transform.forward;
        var hits = Physics.RaycastAll(transform.position, direction, 2f);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Start collider {hit.transform}");
            if (hit.transform.gameObject != gameObject)
            {
                _movementTarget = hit.transform;
                Debug.Log($"Collided with {hit.transform}");
            }
        }
    }
    
    private void StrafeLeft()
    {
        if (_movementTarget != null || transform.forward != _forwardTarget)
            return;
        
        Debug.Log("Start movement");
        var direction = transform.forward;
        Quaternion rotation = Quaternion.Euler(0,-60,0);
        direction = rotation * direction;
        var hits = Physics.RaycastAll(transform.position, direction, 2f);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Start collider {hit.transform}");
            if (hit.transform.gameObject != gameObject)
            {
                _movementTarget = hit.transform;
                Debug.Log($"Collided with {hit.transform}");
            }
        }
        
        if (_movementTarget == null)
            return;
        TurnRight();
    }
    
    private void StrafeRight()
    {
        if (_movementTarget != null || transform.forward != _forwardTarget)
            return;
        
        Debug.Log("Start movement");
        var direction = transform.forward;
        Quaternion rotation = Quaternion.Euler(0,60,0);
        direction = rotation * direction;
        var hits = Physics.RaycastAll(transform.position, direction, 2f);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log($"Start collider {hit.transform}");
            if (hit.transform.gameObject != gameObject)
            {
                _movementTarget = hit.transform;
                Debug.Log($"Collided with {hit.transform}");
            }
        }
        
        if (_movementTarget == null)
            return;
        TurnLeft();
    }

    private void TurnLeft()
    {
        if (transform.forward != _forwardTarget)
            return;

        Quaternion rotation = Quaternion.Euler(0,-60,0);
        _forwardTarget = rotation * _forwardTarget;
    }
    
    private void TurnRight()
    {
        if (transform.forward != _forwardTarget)
            return;

        Quaternion rotation = Quaternion.Euler(0,60,0);
        _forwardTarget = rotation * _forwardTarget;
    }
}
