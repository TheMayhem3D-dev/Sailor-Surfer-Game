using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerGraphics;

    [SerializeField] private Animator playerAnimator;
    public Animator PlayerAnimator { get => playerAnimator; }
    

    [SerializeField] private GameObject playerBoxPrefab;
    [SerializeField] private float prefabStep = 1.0f;

    [SerializeField] private List<GameObject> boxObjects = new List<GameObject>();

    private Movement movement;
    private Rotate rotate;

    private Invulnerable invulnerable;
    public Invulnerable Invulnerable { get => invulnerable; }

    void Start()
    {
        movement = GetComponent<Movement>();
        rotate = GetComponent<Rotate>();
        invulnerable = GetComponent<Invulnerable>();
    }

    public void EnablePlayer(bool value)
    {
        movement.enabled = value;
        movement.DisableRigidBody();
    }

    public void TurnPlayer(float angle, Turn turn)
    {
        movement.SetLimit(turn.MinLimitX, turn.MaxLimitX, turn.MinLimitZ, turn.MaxLimitZ, turn.BorderSideLimit);

        rotate.targetAngle = angle;
        rotate.StartCoroutine(rotate.RotateNow());
    }

    public void AddBoxes(int count)
    {
        GameManager.instance.boxes += count;

        for (int i = 0; i < count; i++)
        {
            GameObject box = Instantiate(playerBoxPrefab, playerGraphics.position, playerGraphics.rotation, transform);
            boxObjects.Add(box);

            playerGraphics.position = new Vector3(playerGraphics.position.x, playerGraphics.position.y + prefabStep, playerGraphics.position.z);
        }
    }

    public void SubtractBoxes(int count)
    {
        if (GameManager.instance.boxes <= count)
        {
            int _boxes = GameManager.instance.boxes;
            for (int i = 0; i < _boxes; i++)
            {
                RemoveBox();
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                RemoveBox();
            }
        }
    }

    void RemoveBox()
    {
        Destroy(boxObjects[GameManager.instance.boxes - 1]);
        boxObjects.RemoveAt(GameManager.instance.boxes - 1);
        GameManager.instance.boxes--;

        playerGraphics.position = new Vector3(playerGraphics.position.x, playerGraphics.position.y - prefabStep, playerGraphics.position.z);
    }

    public void AddCoins(int count)
    {
        GameManager.instance.coins += count;
        GameManager.instance.UIManager.RefreshCoinText();
    }
}
