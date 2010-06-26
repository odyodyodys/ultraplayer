#include "StringHelper.h"

StringHelper::StringHelper(void)
{
}

StringHelper::~StringHelper(void)
{
}

int StringHelper::WordOccurrenceCount(string const & str, string const & word )
{
	int count = 0;
	
	string::size_type wordPos = 0;
	
	while ( wordPos != string::npos )
	{
		wordPos = str.find(word, wordPos );
		if ( wordPos != string::npos )
		{
			count++;

			// start next search after this word
			wordPos += word.length();
		}
	}

	return count;
}