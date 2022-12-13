using ProjetConsole;
using System;
using System.Collections.Generic;
using System.Globalization;
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

//enum ValueCards
//{
//    AceClover = 14, AceSpade = 14, AceTile = 14, AceHeart = 14,
//    KingClover = 13, KingSpade = 13, KingTile = 13, KingHeart = 13,
//    LadyClover = 12, LadySpade = 12, LadyTile = 12, LadyHeart = 12,
//    JackClover = 11, JackSpade = 11, JackTile = 11, jackHeart = 11,
//    TenClover = 10, TenSpade = 10, TenTile = 10, TenHeart = 10,
//    NineClover = 9, NineSpade = 9, NineTile = 9, NineHeart = 9,
//    EightClover = 8, EightSpade = 8, EightTile = 8, EightHeart = 8,
//    SevenClover = 7, SevenSpade = 7, SevenTile = 7, SevenHeart = 7,
//    SixClover = 6, SixSpade = 6, SixTile = 6, SixHeart = 6,
//    FiveClover = 5, FiveSpade = 5, FiveTile = 5, FiveHeart = 5,
//    FourClover = 4, FourSpade = 4, FourTile = 4, FourHeart = 4,
//    ThreeClover = 3, ThreeSpade = 3, ThreeTile = 3, ThreeHeart = 3,
//    TwoClover = 2, TwoSpade = 2, TwoTile = 2, TwoHeart = 2
//}

//List of stacks to fill

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

        foreach (Card card in drawcard)
        {
            if (card.darkside)
            {
                string value = Value switch
                {
                    Value.Ace => "A",
                    Value.Ten => "10",
                    Value.Jack => "J",
                    Value.Queen => "Q",
                    Value.King => "K",
                    _ => ((int)Value).ToString(CultureInfo.InvariantCulture)
                };
                string card = $"{value}{suit}";
                string a = card.Length < 3 ? $"{card} " : card;
                string b = card.Length < 3 ? $" {card}" : card;
            } else
            {
                Console.WriteLine("│" + card.value + card.suit + "│");
            }
        }

        

        Console.WriteLine("\t\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│\n");
        Console.WriteLine("\t│██│\n");
        Console.WriteLine("\t│██│\n" + "\t\t\t\t\t\t\t\t\t│██│");
        Console.WriteLine("\t│██│\n");
        Console.WriteLine("\t│██│");

        Console.WriteLine();
    }
}
/*List<Card> game1;
List<Card> game2;
List<Card> game3;
List<Card> game4;

//Starting card stacks
List<Card> pile1 = new List<Card>();
List<Card> pile2;
List<Card> pile3;
List<Card> pile4;
List<Card> pile5;
List<Card> pile6;
List<Card> pile7;


List<Card> whitelist;

Console.Write(game1);*/
    
