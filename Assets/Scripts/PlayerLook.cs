using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Transform crosshair;

    Rigidbody2D rb;
    GameSettings gameSettings;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        gameSettings = Game.Instance.Settings;
    }

    void Update()
    {
        TurnPlayer();
        MoveCrosshair();
    }

    void TurnPlayer()
    {
        Vector2 dir = (Vector2)crosshair.position - rb.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        rb.SetRotation(angle);
    }

    void MoveCrosshair()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        Vector3 mouseMovement = new Vector2(mouseX, mouseY) * gameSettings.sensitivity * Time.deltaTime;
        crosshair.position += mouseMovement;
    }
}
