using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateTowardsMouse2D : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchOffset;
    public float arrowspeed;
    [FormerlySerializedAs("rotationOffset")] public float zRotationOffset = 0f; // Offset angle in degrees
    public float zAxisValue = 0; // Z-axis value where the game action happens

    public bool canFire;
    public float fireRate;

    private void Start()
    {
        canFire = true;
    }
    void Update()
    {
        Vector2 direction = GetMouseDirection();
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        

        if (Input.GetButtonDown("Fire") && canFire == true)
        {
            Fire();          
        }

        Vector2 GetMouseDirection()
        {
            Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            // Adjust the Z-axis to the fixed value
            mouseWorldPosition.z = zAxisValue;

            return mouseWorldPosition - transform.position;
        }


         void Fire()
        {
            canFire = false;
            if (projectilePrefab != null && launchOffset != null)
            {
                // Calculate the rotated fire direction with offset
                Quaternion fireRotation = Quaternion.Euler(0, 0, launchOffset.eulerAngles.z + zRotationOffset - 90);

                // Instantiate the projectile at the firePoint with offset rotation
                GameObject projectile = Instantiate(projectilePrefab, launchOffset.position, fireRotation);

                // Get the Rigidbody2D component of the projectile and apply a force
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    // Apply velocity in the direction of the firePoint's right, adjusted by the offset
                    rb.velocity = fireRotation * Vector2.right * arrowspeed;
                    rb.transform.rotation = Quaternion.Euler(0, 0, angle);
                }

                StartCoroutine(FireRateHandle());
            }
        }

        IEnumerator FireRateHandle()
        {
            float fireRateTime = 1 / fireRate;
            yield return new WaitForSeconds(fireRateTime);
            canFire = true;
        }
        
    }
}
