namespace CardGame;

public class Person
{
    public List<Card> ownCards; // 객체가 소유하고 있는 카드 List

    // 생성자 (소유 중인 카드 List 인스턴스 생성)
    public Person()
    {
        ownCards = new List<Card>();
    }

    // 게임 시작 후 카드 2장 뽑는 함수
    public void InitCards(Deck deck)
    {
        ownCards.Add(Hit(deck));
        ownCards.Add(Hit(deck));
    }

    // 덱에서 카드 뽑기
    public Card Hit(Deck deck)
    {
        Random random = new Random();
        int index = random.Next(deck.Cards.Count);
        Card selectedCard = deck.Cards[index]; // 랜덤한 카드 선별
        deck.Cards.RemoveAt(index); // 선별한 카드 삭제
        return selectedCard;
    }

    // 현재 가지고 있는 카드 List 출력 (디버깅용)
    public void PrintOwnCards()
    {
        Console.WriteLine("Own cards:");
        foreach (var card in ownCards)
        {
            card.PrintCardInfo();
        }
    }
}