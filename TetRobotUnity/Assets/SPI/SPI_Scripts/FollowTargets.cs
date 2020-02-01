using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowTargets : MonoBehaviour
{
    public List<Transform> targets;

    private Camera cam;

    public Vector3 offset;
    public float smoothTime = .5f;
    public Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    public float size = 6f;

    public void Start()
    {
        cam = GetComponent<Camera>();
        cam.orthographicSize = size;
    }
    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;
        Move();
        Zoom();
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, getGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,newZoom,Time.deltaTime);
    }
    float getGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        if (bounds.size.x >= bounds.size.y)
            return bounds.size.x; 
        else
            return bounds.size.y;

    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}