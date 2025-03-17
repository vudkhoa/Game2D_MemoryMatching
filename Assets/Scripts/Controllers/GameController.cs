using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  GameController : MonoBehaviour
{
    [Header("Card")]
    public GameObject cardPrefab;
    public Transform cardContainer;
    public CardList cardList;

    [Header("Click")]
    public int clickCount = 0;

    [Header("Check")]
    public int maxClickCount = 5;

    private void Awake()
    {
        if (cardList == null)
        {
            cardList = new CardList();
        }
    }

    private void Start()
    {
        cardList.Init();
        InitCard(maxClickCount);
    }

    private void OnEnable()
    {
        CardView.onClick += ClickAction;
    }

    private void ClickAction(int idx)
    {
        Debug.Log(cardList.lst[idx].isMatched);
        if (cardList.lst[idx].isMatched) return;
        //Debug.Log(cardList.firstClickIndex + " " + idx);
        if (cardList.firstClickIndex != -1 && idx == cardList.firstClickIndex) return;
        //Debug.Log("Continue");
        clickCount++;
        if (clickCount % 2 == 1)
        {
            cardList.lst[idx].Swap();
            cardList.firstClickIndex = idx;
            //Debug.Log("First Click: " + cardList.firstClickIndex);
        }
        else
        {
            cardList.secondClickIndex = idx;
            cardList.lst[idx].Swap();
            //Debug.Log(cardList.lst[cardList.firstClickIndex].id + " " + cardList.lst[cardList.secondClickIndex].id);
            if (CheckSame(cardList.firstClickIndex, cardList.secondClickIndex))
            { 
                cardList.lst[cardList.firstClickIndex].isMatched = true;
                cardList.lst[cardList.secondClickIndex].isMatched = true;
                cardList.firstClickIndex = -1;
                cardList.secondClickIndex = -1;
                //Debug.Log("Matched");
            }
            else
            {
                //Debug.Log("Not Matched" + cardList.firstClickIndex +  cardList.secondClickIndex);
                SwapAgain(cardList.firstClickIndex, cardList.secondClickIndex);
            }
        }
    }

    private bool CheckSame(int idx1, int idx2)
    {
        if (cardList.lst[idx1].id == cardList.lst[idx2].id) return true;
        return false;
    }

    private void SwapAgain(int idx1, int idx2)
    {
        cardList.SwapAgain(idx1, idx2);
        //Debug.Log("Swap");
        cardList.firstClickIndex = -1;
        cardList.secondClickIndex = -1;
    }

    private void InitCard(int count)
    {
        List<int> cardIdList = new List<int>();
        for (int i = 1; i <= count; ++i)
        {
            cardIdList.Add(i);
        }
        for (int i = 1; i <= count; ++i)
        {
            cardIdList.Add(i);
        }

        // Shuffle cardIdList
        for (int i = 0; i < count * 2; ++i) 
        {
            int ranIdx = cardIdList[Random.Range(0, cardIdList.Count)];
            int tmp = cardIdList[i];
            cardIdList[i] = cardIdList[ranIdx];
            cardIdList[ranIdx] = tmp;
        }

        //Spawn Card
        for (int i = 0; i < count * 2; ++i)
        {
            // Tạo một GameObject mới từ cardPrefab, đặt nó vào cardContainer  
            // cardGO sẽ chứa tham chiếu đến thẻ bài mới vừa tạo  
            GameObject cardGO = Instantiate(cardPrefab, cardContainer);
            
            Card card = new Card();
            card.Init(cardIdList[i], i, cardGO.GetComponent<CardView>());
            cardList.lst.Add(card);
        }
    }
}