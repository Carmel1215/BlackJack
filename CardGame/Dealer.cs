namespace CardGame;

public class Dealer : Person
{
    public bool Think(Deck deck)
    {
        int sum = 0;
        foreach (var card in ownCards)
        {
            sum += card.Value;
        }

        if (sum <= 16)
        {
            Console.WriteLine("[Dealer] Hit");
            ownCards.Add(Hit(deck));
            return true;
        }
        Console.WriteLine("[Dealer] Stay");
        return false;
    }

    // Person 클래스의 소유 중인 카드 출력 함수 오버라이딩 (디버깅용)
    public new void PrintOwnCards()
    {
        Console.WriteLine("Dealer's cards:");
        foreach (var card in ownCards)
        {
            card.PrintCardInfo();
        }
    }
}