using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Jugaad/Question")]
public class QuestionData : ScriptableObject
{
    public Sprite itemImage;
    public string questionText;

    [System.Serializable]
    public class Option
    {
        public string optionText;
        public int score;
    }

    public Option[] options = new Option[3];
}