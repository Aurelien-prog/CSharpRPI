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

        Random random = new Random();
        int randomNumber;
        randomNumber = random.Next(0, 51);

        List<Card> pile1 = new List<Card>();

        pile1.Add(new Card(drawcard[randomNumber].value, drawcard[randomNumber].suit));
        drawcard.RemoveAt(randomNumber);

        Console.WriteLine("\t\t    " + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐" + "\t┌──┐");
        Console.WriteLine("\t\t┌──┐" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│");
        Console.WriteLine("\t\t│" + translateCard(pile1.Last().value, pile1.Last().suit) + "│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│" + "\t│██│\n");
        Console.WriteLine("\t│██│\n");
        Console.WriteLine("\t│██│\n" + "\t\t\t\t\t\t\t\t\t│██│");
        Console.WriteLine("\t│██│\n");
        Console.WriteLine("\t│██│");
        //Console.WriteLine("dernière carte :" + pile1.GetEnumerator(pile1.size()-1));
    }

    public static string translateCard(Value value, Suit suit)
    {
        string result = "";
        switch (value)
        {
            case (Value.Ace): result = "A";
                break;
            case (Value.Two): result = "2";
                break;
            case (Value.Three): result = "3";
                break;
            case (Value.Four): result = "4";
                break;
            case (Value.Five): result = "5"; 
                break;
            case (Value.Six): result = "6";
                break;
            case (Value.Seven): result = "7";
                break;
            case (Value.Eight): result = "8";
                break;
            case (Value.Nine): result = "9";
                break;
            case (Value.Ten): result = "0";
                break;
            case (Value.Jack): result = "J";
                break;
            case (Value.Queen): result = "Q";
                break;
            case (Value.King):result = "K";
                break;            
        }
        switch (suit)
        {
            case (Suit.Clover): result += "%";
                break;
            case (Suit.Spade): result += "#";
                break;
            case (Suit.Heart): result += "$";
                break;
            case (Suit.Tile): result += "£";
                break;
        }
        return result;
    }

    /*foreach (Card.drawcard[randomNumber])
    {

        Console.WriteLine("│" + card.value + card.suit + "│");
    }

    Console.WriteLine()


    for (int a = 0; a < pile1.lenght; a++)
    {
        Console.WriteLine(pile1[0]);
    }

    foreach (Card card in drawcard)
    {
        if (card.darkside)
        {
            /*string value = Value switch
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
    }*/

    

}
/*List<Card> game1;
List<Card> game2;
List<Card> game3;
List<Card> game4;

List<Card> pile1 = new List<Card>();
List<Card> pile2;
List<Card> pile3;
List<Card> pile4;
List<Card> pile5;
List<Card> pile6;
List<Card> pile7;

List<Card> whitelist;*/

