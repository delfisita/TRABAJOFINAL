using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public Transform shootpoint;
    public Transform bulletPrefab;
    public int damageAmount = 20;
    Transform sight;

    private void start()
    {
        sight = GetComponentInChildren<Canvas>().transform;
    }
    public void Shoot()
    {
        // Obtenemos la rotación actual de shootpoint
        Quaternion shootRotation = shootpoint.transform.rotation;

        // Instanciamos la bala con la posición y rotación de shootpoint
        Instantiate(bulletPrefab, shootpoint.transform.position, shootRotation);
    }

  

    public void DrawSight(Transform camera)
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit)) 
        {
            shootpoint.LookAt(hit.point);   
        }
        else
        {

            Vector3 end = camera.position + camera.forward;
            shootpoint.LookAt (end);
        }


    }
}
