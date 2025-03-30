using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // กระสุนที่ใช้ยิง
    public Transform muzzle; // จุดยิงกระสุน
    public float bulletSpeed = 20f;
    public float moveSpeed = 5f;

    void Update()
    {
        // ขยับปืนซ้าย-ขวา
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // ยิงกระสุนเมื่อกด Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(muzzle.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet, 2f); // ทำลายกระสุนหลัง 2 วินาที
    }
}
