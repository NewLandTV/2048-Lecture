using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Block blockPrefab;
    [SerializeField]
    private Transform blockParent;
    [SerializeField, Range(1, 100)]
    private int blockMakeCount = 10;
    private List<Block> blockPooling;

    [SerializeField]
    private Spawnpoint spawnpoint;

    private const float G = 9.81f;

    private void Awake()
    {
        SetupBlocks();
    }

    private void Start()
    {
        SpawnBlock();
        SpawnBlock();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Physics.gravity = Vector3.left * G;

            SpawnBlock();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Physics.gravity = Vector3.right * G;

            SpawnBlock();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Physics.gravity = Vector3.forward * G;

            SpawnBlock();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics.gravity = Vector3.back * G;

            SpawnBlock();
        }
    }

    private void SetupBlocks()
    {
        blockPooling = new List<Block>(blockMakeCount);

        for (int i = 0; i < blockMakeCount; i++)
        {
            MakeBlock();
        }
    }

    private Block MakeBlock()
    {
        Block instance = Instantiate(blockPrefab, blockParent);

        instance.gameObject.SetActive(false);

        blockPooling.Add(instance);

        return instance;
    }

    private Block GetBlock()
    {
        for (int i = blockPooling.Count - 1; i >= 0; i--)
        {
            if (!blockPooling[i].gameObject.activeSelf)
            {
                return blockPooling[i];
            }
        }

        return MakeBlock();
    }

    private void SpawnBlock()
    {
        Block block = GetBlock();

        block.transform.position = spawnpoint.GetRandomPoint();

        block.gameObject.SetActive(true);
    }
}
