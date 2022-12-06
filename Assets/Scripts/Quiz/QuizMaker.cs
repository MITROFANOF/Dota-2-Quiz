using System.Collections.Generic;
using UnityEngine;

public class QuizMaker : MonoBehaviour
{
    [SerializeField] private Hero[] heroes;

    public Hero GetRandomHero()
    {
        int randomId = Utilities.Random.Next(heroes.Length);
        return heroes[randomId];
    }

    public Sprite GetHeroPortrait(Hero hero)
    {
        return hero.Portrait;
    }

    public Sprite GetHeroRandomSkill(Hero hero)
    {
        int skillsCount = hero.SkillsCount;
        int randomId = Utilities.Random.Next(skillsCount);

        return hero.GetSkill(randomId);
    }

    public Hero[] GetRandomHeroPool(int poolSize)
    {
        var heroPool = new List<Hero>();

        while(heroPool.Count != poolSize)
        {
            Hero hero = GetRandomHero();
            if (!heroPool.Contains(hero))
                heroPool.Add(hero);
        }

        return heroPool.ToArray();
    }

    public Quiz MakeQuiz()
    {
        Hero[] heroPool = GetRandomHeroPool(4);
        int poolSize = heroPool.Length;
        int correctHero = Utilities.Random.Next(poolSize);
        Hero correctAnswer = heroPool[correctHero];

        int randomSkill = Utilities.Random.Next(correctAnswer.SkillsCount);
        
        Sprite[] heroPortraits = new Sprite[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            heroPortraits[i] = heroPool[i].Portrait;
        }

        return new Quiz(correctAnswer.GetSkill(randomSkill), heroPortraits, correctHero);
    }
}
