using System.Text;

namespace CardGame;

public class Player : Person
{
    // 인게임에서 현재 나의 덱 출력
    public void PrintStatus()
    {
        Console.WriteLine("현재 당신은...");
        foreach (var card in ownCards)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            switch (card.Suit)
            {
                case CardSuit.Hearts:
                    sb.Append("하트");
                    break;
                case CardSuit.Diamonds:
                    sb.Append("다이아몬드");
                    break;
                case CardSuit.Clubs:
                    sb.Append("클럽");
                    break;
                case CardSuit.Spades:
                    sb.Append("스페이드");
                    break;
            }

            sb.Append(' ');

            switch (card.Value)
            {
                case 1:
                    sb.Append("Ace (1)");
                    break;
                case 11:
                    sb.Append("J (11)");
                    break;
                case 12:
                    sb.Append("Q (12)");
                    break;
                case 13:
                    sb.Append("K (13)");
                    break;
                default:
                    sb.Append(card.Value);
                    break;
            }
            sb.Append(" ]");
            Console.WriteLine(sb.ToString());
        }
        Console.WriteLine("을(를) 가지고 계시네요");
    }

    // Person 클래스의 소유 중인 카드 출력 함수 오버라이딩 (디버깅용)
    public new void PrintOwnCards()
    {
        Console.WriteLine("Player's cards:");
        foreach (var card in ownCards)
        {
            card.PrintCardInfo();
        }
    }
}