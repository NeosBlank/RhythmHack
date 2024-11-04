using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    private List<Transform> enemyTriggers = new List<Transform>();
    public float moveSpeed = 5f;
    public float targetYPosition = 0f;
    private Vector3 centerPosition;

    private void Start()
    {
        beatTempo = beatTempo / 60f;
        centerPosition = new Vector3(0, -3.5f, 0);
        enemyTriggers.AddRange(GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (hasStarted)
        {
            foreach (var trigger in enemyTriggers)
            {
                if (trigger != transform)
                {
                    MoveTriggersToCenter(trigger);
                }
            }
        }
    }

    private void MoveTriggersToCenter(Transform trigger)
    {
        trigger.position = Vector3.MoveTowards(trigger.position, centerPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(trigger.position, centerPosition) < 0.1f)
        {
            Renderer triggerRenderer = trigger.GetComponent<Renderer>();
            if (triggerRenderer != null)
            {
                triggerRenderer.enabled = false;
            }

            Collider triggerCollider = trigger.GetComponent<Collider>();
            if (triggerCollider != null)
            {
                triggerCollider.enabled = false;
            }
        }
    }
}
