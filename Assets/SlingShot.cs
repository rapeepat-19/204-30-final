using UnityEngine;
using UnityEngine.VFX;

public class SlingShot : MonoBehaviour
{
    public Transform launchPoint; // ตำแหน่งเริ่มต้นของ projectile
    public GameObject projectilePrefab; // Prefab ของลูกกระสุน
    public float forceMultiplier = 10f; // ค่าคูณแรงยิง

    private Vector3 startDragPosition;
    private GameObject currentProjectile;
    private Rigidbody projectileRb;

    void OnMouseDown()
    {
        // สร้าง projectile ใหม่
        currentProjectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        projectileRb = currentProjectile.GetComponent<Rigidbody>();
        projectileRb.isKinematic = true; // ปิด physics ชั่วคราว

        // บันทึกจุดเริ่มลาก
        startDragPosition = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        if (currentProjectile == null) return;

        // คำนวณตำแหน่งที่ลากไป
        Vector3 dragPosition = Input.mousePosition;
        Vector3 difference = startDragPosition - dragPosition;

        // อัปเดตตำแหน่ง projectile ตามการลาก
        Vector3 newProjectilePosition = launchPoint.position + difference * 0.01f;
        currentProjectile.transform.position = newProjectilePosition;
    }

    void OnMouseUp()
    {
        if (currentProjectile == null) return;

        // คำนวณแรงยิง
        Vector3 forceDirection = (startDragPosition - Input.mousePosition).normalized;
        float forceMagnitude = (startDragPosition - Input.mousePosition).magnitude * forceMultiplier;

        // ปล่อย projectile
        projectileRb.isKinematic = false;
        projectileRb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

        // ล้างค่าตัวแปร
        currentProjectile = null;
    }
}


