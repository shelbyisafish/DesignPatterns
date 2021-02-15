
This code is a simple example of the Builder design pattern.

Inspired by Fran's work, this Builder creates the code representation of
a standard Settlers of Catan board. Each piece is a hexagon representing 
one resource. The full board is a large hexagon with 3 board pieces per side.

This is how I'm labeling the edges of a board piece.


			6		1
		       / \
		  5   |   |   2
		       \ /   
			4		 3

Note:
I'm not going to consider ports or the placement of the road/town pieces in this project.
The goal is less to build the game, and more to use the Builder pattern.