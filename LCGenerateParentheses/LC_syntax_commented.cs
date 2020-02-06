using System.Collections.Generic;

public class Solution
{
	public IList<string> GenerateParenthesis(int n)
	{

		//every valid set is going to be stored in here
		List<string> parenPermutations = new List<string>();

		//start our recursive function. We are passing in the requested number of valid sets,
		//an empty string to start building sets, the current number of open/closed parens,
		//and the list of solutions.
		GetPermutations(n, string.Empty, 0, 0, parenPermutations);

		return parenPermutations;
	}

	void GetPermutations(int numOfSets, string permutation, int openParens, int closingParens, IList<string> parenPermutations)
	{
		//break condition
		//this is the easy part to figure out. What defines a complete set? 
		//When the number of characters in the string is equal to the num of requested sets * 2.
		//it is multiplied by two because there are two characters per set.
		if (permutation.Length == numOfSets * 2)
		{
			//add it to the list and then exit the method
			parenPermutations.Add(permutation);
			return;
		}

		//recursive function
		//the first thing we need to do is start adding characters to the list. It has to start with '(',
		//so thats a safe place to start. We also know that we cannot have more '(' than
		//the number of sets, so we want to add them until we reach that number.
		if (openParens < numOfSets)
		{
			//our string is now "(", so we pass that in to the function again and adjust the count.
			//This will repeat until the string is "(((", then on the next pass the num of '(' will be equal
			//to the number of sets, so it will skip this if-statement.
			GetPermutations(numOfSets, permutation + "(", openParens + 1, closingParens, parenPermutations);
		}

		//we have populated the string with '(' so now we need to complete the sets.
		if (openParens > closingParens)
		{
			//this will continue calling itself and hitting this if-statement until the first set is complete.
			//"((()))"
			GetPermutations(numOfSets, permutation + ")", openParens, closingParens + 1, parenPermutations);
		}
		//after that first set is where the logic can get tough to follow. I'll do my best.

		//So the first set just wrote "((()))" and now that will hit the break statement at the top and
		//add that set to our solution list. The important thing to remember now, is that all of 
		//those recursive calls are still waiting to finish. They have to continue to make their way
		//through the entire method call. So each time we hit the end of the method,
		//the permutation string gets set back to what it was before it entered that level of the
		//recursive function. 

		//why does this matter? After we add the first set "((()))" and exit the call, we end up with the
		//previous iteration of the string that had that last ')' added to it, so we have "((())".
		//now that level of the call is at the end of its pass through the method, because it had
		//just added a ')' on the line before to complete the set.

		//Now it reaches the end of the method, and we go up a level to the previous version
		//"((()". This continues until the number of '(' we have is not equal to the number of sets.
		//once that happens, our permutation is "((", and its level had just added that third '(' on the line previous.
		//it has to continue playing out its run through the method, so it goes to the next if-statement
		//that is checking if the number of ')' is less than the number of '('.
		//it IS less, so it adds a closing paren and calls itself, so it starts digging into the function again with
		//the string "(()". Every time we add a character and call the function again, the current
		//pass through gets put on hold, but it still has to play out eventually.

		//I hope that made sense, but if it is hard to follow the written explanation, 
		//step through on your editor and it will become clear
	}
}