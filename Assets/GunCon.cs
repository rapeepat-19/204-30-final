using UnityEngine;

public class Guncon: MonoBehaviour
{
    public GameObject bulletPrefab; // กระสุน
    public Transform muzzle; // จุดยิงกระสุน
    public float bulletSpeed = 20f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f; // ความเร็วในการหมุน

    private float rotationX = 0f; // เก็บค่ามุมเงย-ก้ม

    void Update()
    {
        // ขยับปืนซ้าย-ขวา (ใช้ปุ่มลูกศรหรือ A/D)
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // หมุนปืนขึ้น-ลงตามเมาส์
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationX -= mouseY; 
        rotationX = Mathf.Clamp(rotationX, -30f, 30f); // จำกัดองศาการเงย-ก้ม
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // ยิงกระสุนเมื่อคลิกซ้าย
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = muzzle.forward * bulletSpeed;
        Destroy(bullet, 2f);
    }
}





