using UnityEngine;

[CreateAssetMenu(fileName = "New Cheese Data", menuName = "Cheese Data")]

public class CheeseData : ScriptableObject
{
    [SerializeField] private int index;
    [SerializeField] private string type;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;

    #region GETTERS Y SETTERS
    public int Index { get => index; set => index = value; }
    public string Type { get => type; set => type = value; }
    public string Description { get => description; set => description = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
    #endregion

    public void PrintData()
    {
        Debug.Log($"Index: {index}");
        Debug.Log($"Type: {type}");
        Debug.Log($"Description: {description}");
    }
}
