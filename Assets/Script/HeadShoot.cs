using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // prefab của đạn
    public Transform firePoint; // vị trí bắn đạn
    [SerializeField]
    private float destroyTime;
    [SerializeField]
    private float nextShootTime = 1.5f; // thời điểm bắn đạn tiếp theo


    void Update()
    {
        // Kiểm tra xem có thể bắn đạn hay không
        if (Time.time >= nextShootTime)
        {
            // Bắn đạn
            ShootBullet();

            // Cập nhật thời điểm bắn đạn tiếp theo
            nextShootTime = Time.time + 2f; // Chu kỳ 1 giây 1 lần
        }
    }

    void ShootBullet()
    {
        // Tạo đối tượng đạn mới từ prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Thiết lập tốc độ di chuyển của đạn

        // Huỷ đối tượng đạn sau khi bay đến đích
        Destroy(bullet, destroyTime); // Huỷ sau 5 giây nếu không va chạm gì
    }
}
