using System;

public class Decorato:Bnode

{ 
	Bnode Child { get; set; }





	public Decorato(BehaviorTree t, Bnode c): base(t)
    {
		Child = c;
	}


}
