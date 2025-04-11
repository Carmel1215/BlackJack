namespace CardGame;

public class Deck
{
    // Card List 프로퍼티
    public List<Card> Cards { get; set; }

    // 생성자: Cards에 1~13까지의 숫자(1, 11, 12, 13은 차례로 A, J, Q, K에 대응)와 4가지의 모양을 부여함. 총 52장
    public Deck()
    {
        Cards = new List<Card>(52);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                Cards.Add(new Card(i, j + 1));
            }
        }
    }

    // 현재 Deck에 남아있는 카드 출력
    public void PrintDeckInfo()
    {
        Console.WriteLine("Deck Info:");
        foreach (var card in Cards)
        {
            card.PrintCardInfo();
        }
    }
}