using UnityEngine;

public class CannonController : MonoBehaviour
{
    // START HERE
    public GameObject Barrel;
    public GameObject ShotSpawn;
    public GameObject Shot;

    public float RateofFire = 2f;
    public float ShotSpeed = 800f;

    float FireDelay;

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(0f, rotation, 0f);

        float pitch = Input.GetAxis("Vertical") + Barrel.transform.rotation.eulerAngles.x;

        pitch = Mathf.Clamp(pitch, 320f, 359f);
        Quaternion BarrelRotation = Quaternion.Euler(pitch, 0f, 0f);
        Barrel.transform.localRotation = BarrelRotation;

        if (Input.GetButton("Fire3") && Time.time > FireDelay)
        {
            FireDelay = Time.time + RateofFire;
            GameObject ShotInstance = Instantiate(Shot, ShotSpawn.transform.position, ShotSpawn.transform.rotation);

            ShotInstance.GetComponent<Rigidbody>().AddForce(ShotSpawn.transform.forward * ShotSpeed);
        }
    }
}
