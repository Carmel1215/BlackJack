namespace CardGame;

public class Game
{
    public void Run()
    {
        while (true)
        {
            Deck deck = new Deck(); // deck 초기화
            Player player = new Player(); // Player 인스턴스
            Dealer dealer = new Dealer(); // Dealer 인스턴스

            player.InitCards(deck); // 카드 2장 선정 (deck에서 차감)
            dealer.InitCards(deck); // 카드 2장 선정 (deck에서 차감)

            bool isPlayerWin = false; // 플레이어 승리 여부 (true이면 플레이어, false이면 딜러 승)

            Console.Clear();
            // 플레이어 턴과 딜러 턴 진행
            while (true)
            {
                player.PrintStatus();
                Console.WriteLine("더 뽑으시겠습니까? [y/n]");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    player.ownCards.Add(player.Hit(deck));

                    // 패의 총합이 21인지 검사
                    if (InspectBlackJack(player))
                    {
                        isPlayerWin = true;
                        break;
                    } else if (InspectOver(player)) // 패의 총합이 21 초과인지 검사
                    {
                        isPlayerWin = false;
                        break;
                    }
                } else if (key.Key == ConsoleKey.N)
                {
                    bool isContinue = true;
                    while (isContinue)
                    {
                        isContinue = dealer.Think(deck); // Hit or Stay 생각 및 행동 함수
                        if (InspectBlackJack(dealer))
                        {
                            isPlayerWin = false;
                            break;
                        } else if (InspectOver(dealer))
                        {
                            isPlayerWin = true;
                            break;
                        }
                    }
                    break;
                }
            }

            int playerSum = 0;
            int dealerSum = 0;

            foreach (Card card in player.ownCards)
            {
                playerSum += card.Value;
            }

            foreach (Card card in dealer.ownCards)
            {
                dealerSum += card.Value;
            }

            // 승패 판단
            if (InspectOver(player) != true && playerSum > dealerSum)
            {
                isPlayerWin = true;
            } else if (InspectOver(dealer) != true && playerSum < dealerSum)
            {
                isPlayerWin = false;
            }

            if (isPlayerWin)
            {
                // 플레이어 승리
                Console.WriteLine(playerSum);
                Console.WriteLine(dealerSum);
                Console.WriteLine("[ Debug ] 플레이어 승리!");

            }
            else
            {
                // 딜러 승리
                Console.WriteLine(playerSum);
                Console.WriteLine(dealerSum);
                Console.WriteLine("[ Debug ] 딜러 승리!");
            }

            Console.ReadKey(true);
        }
    }

    // 21이 넘었는지 검사하는 함수 (가독성 이슈로 추후에 함수명 변경 필요)
    private bool InspectOver(Person person)
    {
        int sum = 0;
        foreach (var card in person.ownCards)
        {
            sum += card.Value;
        }

        if (sum > 21)
        {
            return true;
        }

        return false;
    }

    // 블랙잭인지 검사하는 함수 (가독성 이슈로 추후에 함수명 변경 필요)
    private bool InspectBlackJack(Person person)
    {
        int sum = 0;
        foreach (var card in person.ownCards)
        {
            sum += card.Value;
        }

        if (sum == 21)
        {
            return true;
        }

        return false;
    }
}