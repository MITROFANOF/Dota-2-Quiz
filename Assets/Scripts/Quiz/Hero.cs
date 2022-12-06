using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Dota/New Hero")]
public class Hero : ScriptableObject
{
    [SerializeField] private Sprite portrait;
    [SerializeField] private Sprite[] skills;

    public Sprite Portrait => portrait;

    public Sprite GetSkill(int id) => skills[id];

    public int SkillsCount => skills.Length;
}
