using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Value { get; private set; } = 2;

    private TextMeshPro text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.collider.CompareTag("Block"))
        {
            return;
        }

        Block other = collision.collider.GetComponent<Block>();

        if (Value != other.Value)
        {
            return;
        }

        Value += other.Value;
        text.text = Value.ToString();

        other.gameObject.SetActive(false);
    }
}
