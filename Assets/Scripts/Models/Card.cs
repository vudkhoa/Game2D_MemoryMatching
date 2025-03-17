using System.Collections;
using System.Collections.Generic;
public class Card
{
	public int id;
	public bool isMatched;
	public CardView cardView;

	public void Init(int id, int viewId, CardView cardView)
	{
		this.id = id;
		this.isMatched = false;
		this.cardView = cardView;
        cardView.SetIndexText(id);
		cardView.SetIndex(viewId);
	}

	public void Swap()
	{
		cardView.Swap();
	}
}
