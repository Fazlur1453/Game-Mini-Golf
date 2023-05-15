using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayManager : MonoBehaviour
{
    [SerializeField] Controller controller;

    [SerializeField] CameraController camController;

    [SerializeField] GameObject finishWindow;

    [SerializeField] TMP_Text finishText;

    [SerializeField] TMP_Text shootCountText;

    bool isBallOutside;

    bool isBallTeleporting;

    bool isGoal;

    Vector3 lastBallPosition;

    private void OnEnable()
    {
        controller.onBallShooted.AddListener(UpdateShootCount);
    }

    private void OnDisable()
    {
        controller.onBallShooted.RemoveListener(UpdateShootCount);
    }

    private void Update()
    {
        if(controller.ShootingMode)
        {
            lastBallPosition = controller.transform.position;
        }

        var inputActive = Input.GetMouseButton(0) 
            && controller.IsMove() == false
            && controller.ShootingMode == false
            && isBallOutside == false;

        camController.SetInputActive(inputActive);
    }

    public void OnBallGoalEnter()
    {
        isGoal = true;
        controller.enabled = false;

        finishWindow.gameObject.SetActive(true);
        finishText.text = "Finished !!!\n" + "Shoot Count :" + controller.ShootCount; 
    }
    public void OnBallOutside()
    {
        if (isGoal)
            return;

        if(isBallTeleporting == false)
            Invoke("TeleportBallLastPosition", 0.5f);
        
        controller.enabled = false;
        isBallOutside = true;
        isBallTeleporting = true;

        Debug.Log(isBallTeleporting + "    Keluar    ");
        
    }
    public void TeleportBallLastPosition()
    {
        TeleportBall(lastBallPosition);
    }
    public void TeleportBall(Vector3 targetPosition)
    {
        var rb = controller.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        controller.transform.position = lastBallPosition;
        rb.isKinematic = false;

        controller.enabled = true;
        isBallOutside = false;
        isBallTeleporting = false;
    }
    public void UpdateShootCount(int shootCount)
    {
        shootCountText.text = shootCount.ToString();
    }
} 
