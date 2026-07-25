using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    // ★背景の広さに合わせて、カメラが動ける限界の範囲（設定値）
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // プレイヤーの位置を取得
            float targetX = playerTransform.position.x;
            float targetY = playerTransform.position.y;

            // ★重要：カメラの位置が、設定した限界（背景の端）を超えないように制限する
            targetX = Mathf.Clamp(targetX, minX, maxX);
            targetY = Mathf.Clamp(targetY, minY, maxY);

            // カメラを移動させる
            transform.position = new Vector3(targetX, targetY, -10f);
        }
    }
}
