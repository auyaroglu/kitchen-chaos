using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        // Time.deltaTime farklı frameratelerde (Vsync açık veya kapalı) oynayan tüm oyuncularda aynı hızda olmasını sağlamak için kullanılıyor.
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        // Karakterin hangi yöne bakacağını belirtiyoruz. (Slerp fonksiyonu, karakterin ymuşak bir dönüş yapmasını sağlamak için kullanılıyor.)
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking() {
        return isWalking;
    }

}
