using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConstantFire : MonoBehaviour
{
    //Varible used to control when the enenmies' "can fire"  
    public bool canFire = true;
    //Varible used to control when the enenmies' "can fire"  
    public bool canMove;
    //Varible used to identify the "Arrow Prefab" 
    public GameObject projectilePrefab;
    //Varible used to identify the "Launch Offset"  
    public Transform launchOffset;
    //Varible used to control the enenmies' "Fire Rate" 
    public float fireRate;
    //Varible used to control the enenmies' "Arrow Speed" 
    public float arrowSpeed;
    //Varible used for the rotation of where the arrow needs to be facing 
    [FormerlySerializedAs("rotationOffset")] public float zRotationOffset = 0f;

    public AudioSource source;
    public AudioClip shootClip;
    //Runs this function every fixed framerate frame
    private void FixedUpdate()
    {   

        //If statement checking if the fire rate has meet the required time before firing 
        if (canFire)
        {
            source.PlayOneShot(shootClip);

            //Call the "Fire" method 
            Fire(); 
        }

        
        
    }
    void Fire()
    {       
        //Set can fire bool to false so the enenmy cannot fire
        canFire = false;

        //Set the Quaternion variable to a defined rotation
        Quaternion fireRotation = Quaternion.Euler(0, 0, - zRotationOffset);

        //Import a new game object  using (the arrow prefab, at the launch position, facing the demermined rotation)
        GameObject projectile = Instantiate(projectilePrefab, launchOffset.position, fireRotation);
        
        //rigidbody vairable set to the projectile gamobject's rigid body  
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Apply velocity in the direction of the right axis, adjusted by the arrow speed 
        rb.velocity += Vector2.right * -arrowSpeed;

        //Begins the IEnumerator method which alows it to count time 
        StartCoroutine(FireRateHandle());
    }

    IEnumerator FireRateHandle()
    {
        //These lines are used to determine how long the fire rate should wait before allowing to fire again  
        float fireRateTime = 1 / fireRate;
        yield return new WaitForSeconds(fireRateTime);
        canFire = true;
    }
}
