namespace CardGame;

public enum CardSuit
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

public class Card
{
    // 무늬 프로퍼티
    public CardSuit Suit { get; set; }

    // 숫자 프로퍼티
    public int Value { get; set; } // 1, 11, 12, 13은 차례로 A, J, Q, K인 점 주의

    // 생성자
    public Card(int suit, int value)
    {
        Suit = (CardSuit)suit;
        Value = value;
    }

    // 카드 속성 출력
    public void PrintCardInfo()
    {
        Console.WriteLine($"{Value}: {Suit}");
    }
}