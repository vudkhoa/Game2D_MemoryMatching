using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList
{
    public List<Card> lst = new List<Card>();
    public int firstClickIndex;
    public int secondClickIndex;

    public void Init()
    {
        firstClickIndex = -1;
        secondClickIndex = -1;
    }

    public void SwapAgain(int idx1, int idx2)
    {
        CoroutineRunner.Instance.RunCoroutine(SwapDelay(idx1, idx2));
    }

    private IEnumerator SwapDelay(int idx1, int idx2)
    {
        yield return new WaitForSeconds(.5f);
        Swap(idx1, idx2);
    }

    private void Swap(int idx1, int idx2)
    {
        lst[idx1].Swap();
        lst[idx2].Swap();
    }
}