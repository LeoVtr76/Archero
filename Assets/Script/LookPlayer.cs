using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public float rotateSpeed = 20f;
    public float walkSpeed = 10;

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            //if (Input.GetMouseButtonDown(0))
            //{
                while (transform.position != targetPoint)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPoint, walkSpeed * Time.deltaTime);
                }
            //}
        }
    }
}