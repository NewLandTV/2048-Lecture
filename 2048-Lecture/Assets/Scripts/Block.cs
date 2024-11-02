using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private int value = 2;
    public int Value => value;

    private Vector2 origin = new Vector2(-640f, 640f);

    public int Level { get; private set; }

    private RectTransform rectTransform;
    private Image image;
    private TextMeshProUGUI text;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        image = GetComponent<Image>();
        image.sprite = sprites[Level];

        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = value.ToString();
    }

    public void SetPosition(int x, int y)
    {
        float xPos = origin.x + (x + 1) * 256f;
        float yPos = origin.y - (y + 1) * 256f;

        Vector2 position = new Vector2(xPos, yPos);

        rectTransform.anchoredPosition = position;
    }
}
