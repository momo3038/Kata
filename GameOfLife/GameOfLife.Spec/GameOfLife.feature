Feature: Game of Life
	In order to be god
	As a god student
	I want to play the Game Of Life

Wikipedia (Conway's game of life) : http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

Scenario: Underpopulation

Any living cell with fewer than two live neighbours dies, as if caused by underpopulation.

	Given I have the following world
	"""
	**.....*
	....*...
	...*...*
	**.....*
	"""
	When I play god
	Then the world is now like that
	"""
	........
	........
	........
	........
	"""

Scenario: Overcrowding

Any living cell with more than three live neighbours dies, as if by overcrowding.

	Given I have the following world
	"""
	**......
	**......
	.....**.
	.....***
	"""
	When I play god
	Then the world is now like that
	"""
	**......
	**......
	.....*.*
	.....*.*
	"""

Scenario: Stay in life

 Any living cell with two or three live neighbours lives on to the next generation.

	Given I have the following world
	"""
	**......
	**......
	........
	........
	"""
	When I play god
	Then the world is now like that
	"""
	**......
	**......
	........
	........
	"""

Scenario: Resurection

Any dead cell with exactly three live neighbours becomes a live cell.

	Given I have the following world
	"""
	........
	.....*..	
	....**..
	........
	"""
	When I play god
	Then the world is now like that
	"""
	........
	....**..
	....**..
	........
	"""

Scenario: Can do a Blinker oscillator

	Given I have the following world
	"""
	........
	........
	..***...
	........
	"""
	When I play god
	Then the world is now like that
	"""
	........
	...*....
	...*....
	...*....
	"""
	When I play god
	Then the world is now like that
	"""
	........
	........
	..***...
	........
	"""