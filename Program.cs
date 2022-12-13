using ProjetConsole;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

enum Suit
{
    Clover,
    Spade,
    Tile,
    Heart
}
enum Value
{
    Ace = 01,
    Two = 02,
    Three = 03,
    Four = 04,
    Five = 05,
    Six = 06,
    Seven = 07,
    Eight = 08,
    Nine = 09,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
}

class Program
{
    static void Main(string[] args)
    {
        List<Card> drawcard = new List<Card>();
        foreach (Value value in Value.GetValues(typeof(Value)))
        {
            foreach (Suit suit in Suit.GetValues(typeof(Suit)))
            {
                drawcard.Add(new Card(value, suit));
            }
        }

        List<Card> pile1 = new List<Card>();
        List<Card> pile2 = new List<Card>();
        List<Card> pile3 = new List<Card>();
        List<Card> pile4 = new List<Card>();
        List<Card> pile5 = new List<Card>();
        List<Card> pile6 = new List<Card>();
        List<Card> pile7 = new List<Card>();

        Shuffle(drawcard);
        pile1.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
        drawcard.RemoveAt(drawcard.Count() - 1);

        List<Card>[] pile = new List<Card>[7];

        //Shuffle(drawcard);
        //for (int i = 0; i < pile.Length; i++)
        //{
        //    for (int j = 0; j <= i; j++)
        //    {
        //        Console.WriteLine(i + " " + j);
        //        pile1.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
        //        drawcard.RemoveAt(drawcard.Count()-1);
        //    }
        //}

        for (int i = 0; i < 2; i++)
        {
            Shuffle(drawcard);
            pile2.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
            drawcard.RemoveAt(drawcard.Count() - 1);
        }
        for (int i = 0; i < 3; i++)
        {
            Shuffle(drawcard);
            pile3.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
            drawcard.RemoveAt(drawcard.Count() - 1);
        }
        for (int i = 0; i < 4; i++)
        {
            Shuffle(drawcard);
            pile4.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
            drawcard.RemoveAt(drawcard.Count() - 1);
        }
        for (int i = 0; i < 5; i++)
        {
            Shuffle(drawcard);
            pile5.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
            drawcard.RemoveAt(drawcard.Count() - 1);
        }
        for (int i = 0; i < 6; i++)
        {
            Shuffle(drawcard);
            pile6.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
            drawcard.RemoveAt(drawcard.Count() - 1);
        }
        for (int i = 0; i < 7; i++)
        {
            Shuffle(drawcard);
            pile7.Add(new Card(drawcard.Last().value, drawcard.Last().suit));
            drawcard.RemoveAt(drawcard.Count() - 1);
        }

        HidePick(pile1, pile2, pile3, pile4, pile5, pile6, pile7);

        string enter = Console.ReadLine();
        if (Console.ReadLine() == "p")
        {
            ShowPick(pile1, pile2, pile3, pile4, pile5, pile6, pile7, drawcard);
        }
    }
    //A optimiser !!
    public static void ShowPick(List<Card> pile1, List<Card> pile2, List<Card> pile3, List<Card> pile4, List<Card> pile5, List<Card> pile6, List<Card> pile7, List<Card> drawcard)
    {
        Console.Clear();
        Console.WriteLine("\t\t  1 " + "\t  2 " + "\t  3 " + "\t  4 " + "\t  5 " + "\t  6 " + "\t  7 ");
        Console.WriteLine("\t\t    " + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐");
        Console.WriteLine("\t\t┌──┐" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│");
        Console.WriteLine("\t\t│" + translateCard(pile1.Last().value, pile1.Last().suit) + "│" + "\t│" + translateCard(pile2.Last().value, pile2.Last().suit) +
            "│" + "\t│" + translateCard(pile3.Last().value, pile3.Last().suit) + "│" + "\t│" + translateCard(pile4.Last().value, pile4.Last().suit) +
            "│" + "\t│" + translateCard(pile5.Last().value, pile5.Last().suit) + "│" + "\t│" + translateCard(pile6.Last().value, pile6.Last().suit) +
            "│" + "\t│" + translateCard(pile7.Last().value, pile7.Last().suit) + "│");
        Console.WriteLine("\t\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘\n");
        Console.WriteLine("\t 1 │██│");
        Console.WriteLine("\t\t\t\t\t\t\t\t\t┌──┐");
        Console.WriteLine("\t 2 │██│\t\t\t\t\t\t\t\t│" + translateCard(drawcard.Last().value, drawcard.Last().suit) + "│\t 'p' : Pioche + n°?");
        Console.WriteLine("\t\t\t\t\t\t\t\t\t└──┘");
        Console.WriteLine("\t 3 │██│\n");
        Console.WriteLine("\t 4 │██│\n\n");

        Console.WriteLine("\tPour déplacer une carte, saisisez le numéro de la colonne dont vous voulez déplacer la carte puis " +
            "saisissez le numéro de la colonne finale ou vous voulez l'insérer.\n");
        Console.WriteLine("\tPour piocher une carte, saisisez 'p' puis le numéro de la colonne ou vous voulez que la carte se déplace\n");
    }
    public static void HidePick(List<Card> pile1, List<Card> pile2, List<Card> pile3, List<Card> pile4, List<Card> pile5, List<Card> pile6, List<Card> pile7)
    {
        Console.Clear();
        Console.WriteLine("\t\t  1 " + "\t  2 " + "\t  3 " + "\t  4 " + "\t  5 " + "\t  6 " + "\t  7 ");
        Console.WriteLine("\t\t    " + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐");
        Console.WriteLine("\t\t┌──┐" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│");
        Console.WriteLine("\t\t│" + translateCard(pile1.Last().value, pile1.Last().suit) + "│" + "\t│" + translateCard(pile2.Last().value, pile2.Last().suit) +
            "│" + "\t│" + translateCard(pile3.Last().value, pile3.Last().suit) + "│" + "\t│" + translateCard(pile4.Last().value, pile4.Last().suit) +
            "│" + "\t│" + translateCard(pile5.Last().value, pile5.Last().suit) + "│" + "\t│" + translateCard(pile6.Last().value, pile6.Last().suit) +
            "│" + "\t│" + translateCard(pile7.Last().value, pile7.Last().suit) + "│");
        Console.WriteLine("\t\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘" + "\t└──┘\n");
        Console.WriteLine("\t 1 │██│");
        Console.WriteLine("\t\t\t\t\t\t\t\t\t┌──┐");
        Console.WriteLine("\t 2 │██│\t\t\t\t\t\t\t\t│██│\t 'p' : Pioche + n°?");
        Console.WriteLine("\t\t\t\t\t\t\t\t\t└──┘");
        Console.WriteLine("\t 3 │██│\n");
        Console.WriteLine("\t 4 │██│\n\n");

        Console.WriteLine("\tPour déplacer une carte, saisisez le numéro de la colonne dont vous voulez déplacer la carte puis " +
            "saisissez le numéro de la colonne finale ou vous voulez l'insérer.\n");
        Console.WriteLine("\tPour piocher une carte, saisisez 'p' puis le numéro de la colonne ou vous voulez que la carte se déplace\n");
    }

    public static string translateCard(Value value, Suit suit)
    {
        string result = "";
        switch (value)
        {
            case (Value.Ace):
                result = "A";
                break;
            case (Value.Two):
                result = "2";
                break;
            case (Value.Three):
                result = "3";
                break;
            case (Value.Four):
                result = "4";
                break;
            case (Value.Five):
                result = "5";
                break;
            case (Value.Six):
                result = "6";
                break;
            case (Value.Seven):
                result = "7";
                break;
            case (Value.Eight):
                result = "8";
                break;
            case (Value.Nine):
                result = "9";
                break;
            case (Value.Ten):
                result = "0";
                break;
            case (Value.Jack):
                result = "J";
                break;
            case (Value.Queen):
                result = "Q";
                break;
            case (Value.King):
                result = "K";
                break;
        }
        switch (suit)
        {
            case (Suit.Clover):
                result += "%";
                break;
            case (Suit.Spade):
                result += "#";
                break;
            case (Suit.Heart):
                result += "$";
                break;
            case (Suit.Tile):
                result += "£";
                break;
        }
        return result;
    }
    public static void Shuffle(List<Card> list)
    {
        Random random = new Random();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Card value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

