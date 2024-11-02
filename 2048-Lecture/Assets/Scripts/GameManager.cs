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

    private Block[,] board = new Block[4, 4];

    private void Awake()
    {
        SetupBlocks();
    }

    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            SpawnBlock();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveBlocks(Vector2.up);
            SpawnBlock();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBlocks(Vector2.down);
            SpawnBlock();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveBlocks(Vector2.left);
            SpawnBlock();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveBlocks(Vector2.right);
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

    private void MoveBlocks(Vector2 axis)
    {
        if (axis == Vector2.right)
        {
            MoveBlocksRight();
        }
        else if (axis == Vector2.left)
        {
            MoveBlocksLeft();
        }
        else if (axis == Vector2.up)
        {
            MoveBlocksUp();
        }
        else if (axis == Vector2.down)
        {
            MoveBlocksDown();
        }
    }

    private void MoveBlocksRight()
    {
        Block[] temp = new Block[4];

        for (int y = 0; y < 4; y++)
        {
            int c = 0;

            for (int x = 0; x < 4; x++)
            {
                if (board[x, y] != null)
                {
                    temp[c++] = board[x, y];
                    board[x, y] = null;
                }
            }

            if (c == 0 || c == 4)
            {
                continue;
            }

            for (int x = 3; c > 0; x--)
            {
                board[x, y] = temp[--c];

                board[x, y].SetPosition(x, y);
            }
        }
    }

    private void MoveBlocksLeft()
    {
        Block[] temp = new Block[4];

        for (int y = 0; y < 4; y++)
        {
            int c = 0;

            for (int x = 0; x < 4; x++)
            {
                if (board[x, y] != null)
                {
                    temp[c++] = board[x, y];
                    board[x, y] = null;
                }
            }

            if (c == 0 || c == 4)
            {
                continue;
            }

            for (int x = 0; x < c; x++)
            {
                board[x, y] = temp[x];

                board[x, y].SetPosition(x, y);
            }
        }
    }

    private void MoveBlocksUp()
    {
        Block[] temp = new Block[4];

        for (int x = 0; x < 4; x++)
        {
            int c = 0;

            for (int y = 0; y < 4; y++)
            {
                if (board[x, y] != null)
                {
                    temp[c++] = board[x, y];
                    board[x, y] = null;
                }
            }

            if (c == 0 || c == 4)
            {
                continue;
            }

            for (int y = 0; y < c; y++)
            {
                board[x, y] = temp[y];

                board[x, y].SetPosition(x, y);
            }
        }
    }

    private void MoveBlocksDown()
    {
        Block[] temp = new Block[4];

        for (int x = 0; x < 4; x++)
        {
            int c = 0;

            for (int y = 0; y < 4; y++)
            {
                if (board[x, y] != null)
                {
                    temp[c++] = board[x, y];
                    board[x, y] = null;
                }
            }

            if (c == 0 || c == 4)
            {
                continue;
            }

            for (int y = 3; c > 0; y--)
            {
                board[x, y] = temp[--c];

                board[x, y].SetPosition(x, y);
            }
        }
    }

    private void SpawnBlock()
    {
        Block block = GetBlock();

        int x;
        int y;

        do
        {
            x = Random.Range(0, 4);
            y = Random.Range(0, 4);
        } while (board[x, y] != null);

        board[x, y] = block;

        block.SetPosition(x, y);
        block.gameObject.SetActive(true);
    }
}
