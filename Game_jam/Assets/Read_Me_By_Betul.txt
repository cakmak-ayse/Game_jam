What to do when making a new level? here are the steps

1- add player
2- ad camerafollow scro=ipt to camera and add player to it
3- add grid if you cant find how make empty obj and add grid component to it and name it grid
4- grid will have at least 2 childs one of them is the ground
	ground --
	add tileset , tile renderer, tile collider. draw ground as you wish
	make sure to change its tag to Ground cus player script wont know its the ground if its not tagged.
	foreground --
	add tile set and tile renderer, not collider draw bg as you wish
	if the fore ground is infront of the purple tilesets you might have to change z value of the purpble ground to -0.05

well i wanna have enemies :(
	
	