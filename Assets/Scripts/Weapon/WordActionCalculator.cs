using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine;

class WordActionCalculator
{
    public static PhraseActions GetPhraseType(string phrase)
    {
        string text = phrase.ToUpper();

        Regex dieRe = new Regex( @"(?:[^n][^t][ ])die\b|^die\b", RegexOptions.IgnoreCase);

        if (dieRe.IsMatch(text, 0))
        {
            return PhraseActions.Die;
        }

        Regex exploadeRe = new Regex(@"(?:[^n][^t][ ])explode\b|^explode\b", RegexOptions.IgnoreCase);

        if (exploadeRe.IsMatch(text, 0))
        {
            return PhraseActions.Explode;
        }

        Regex rageRe = new Regex(@"(?:[^n][^t][ ])rage\b|^rage\b", RegexOptions.IgnoreCase);

        if (rageRe.IsMatch(text, 0))
        {
            return PhraseActions.Rage;
        }

        return PhraseActions.Confused;
    }
}

public enum PhraseActions
{
    Die,
    Rage,
    Run,
    Confused,
    Explode,
    GoGreen,
    GoRed,
    GoBlue
}

public enum EnemyTypes
{
    Normal,
    Pyromaniac,
    Explosive,
    Brute
}