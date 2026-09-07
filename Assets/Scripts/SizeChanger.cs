using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    [SerializeField] private PlayerData.ID playerId;

    private const float minWidth = 1f;
    private const float maxWidth = 3f;
    private float width = 2f;

    public float GetWidth() => width;
    public void SetWidth(float newWidth) => width = Mathf.Clamp(newWidth, minWidth, maxWidth);

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetWidth(PlayerData.GetWidth(playerId));
    }

    // Igual que en Movement, suscribe y desuscribe para actualizarse cuando Settings modifique PlayerData
    private void OnEnable()
    {
        PlayerData.OnWidthChanged += HandleWidthChanged;
    }

    private void OnDisable()
    {
        PlayerData.OnWidthChanged -= HandleWidthChanged;
    }

    private void HandleWidthChanged(PlayerData.ID id, float value)
    {
        if (id == playerId)
            SetWidth(value);
    }
}