using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; // ←NetworkBehaviourのために必要

public class Player01 : NetworkBehaviour // ←NetworkBehaviourを継承する
{
    CharacterController m_CharacterController;
    // 移動速度（m/s）
    [SerializeField] float m_WalkSpeed = 4f;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ローカルプレイヤー（つまり自分のキャラクター）の場合のみ
        // 移動処理を実施する。
        if (isLocalPlayer)
        {
            // 移動量を求める
            Vector3 motion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
                * m_WalkSpeed * Time.deltaTime;

            if (motion.magnitude > 0f)
            {
                // Commandにより、移動の依頼をサーバーに発行
                CmdMove(motion);
            }
        }
    }

    // 移動処理。これはサーバーで実行される
    [Command]
    void CmdMove(Vector3 motion)
    {
        m_CharacterController.Move(motion);
    }
}