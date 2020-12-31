using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDisplayer : MonoBehaviour
{
    private Transform markerParent;
    [SerializeField] [Min(0.5f)] private float distanceBetweenMarkers;
    [SerializeField] private SpriteRenderer positionMarker;
    [SerializeField] private Vector3[] debugPositions;
    private Vector3 lastPosition;
    private LineRenderer line;
    List<Vector3> linePositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        markerParent = GameObject.FindGameObjectWithTag("Marker Parent").transform;
        line = GetComponent<LineRenderer>();
        linePositions.Add(transform.position);
        lastPosition = transform.position;
        line.enabled = true;
        line.alignment = LineAlignment.TransformZ;
        Invoke("StopSimulating", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, lastPosition) >= distanceBetweenMarkers)
        {
            Instantiate(positionMarker, transform.position, Quaternion.identity, markerParent);
            linePositions.Add(transform.position);
            lastPosition = transform.position;
        }

        line.positionCount = linePositions.Count;
        line.SetPositions(linePositions.ToArray());
    }

    void StopSimulating()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        KinematicCannonBall ball = GetComponent<KinematicCannonBall>();
        if (ball)
        {
            ball.enabled = false;
            return;
        }

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
