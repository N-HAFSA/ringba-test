# ringba-test
**The Code Test**

Please write a .Net Core 2.2 application that downloads the file http://ringba-test-html.s3-website-us-west-1.amaz… and prints out some statistics about the file.

The file is using a very simple form of compression in which there are no spaces, each word is separated by camel casing. For Example, the string "TheCatWillRun" is parsed as "The Cat Will Run".

**Now for the statistics**

Please print to the console the following statistics about the content in the file retrieved above.

- How many of each letter are in the file
- How many letters are capitalized in the file
- The most common word and the number of times it has been seen.
- The most common 2 character prefix and the number of occurrences in the text file. As well as all the words that contain that prefix printed out in a comma separated form.


Note that the word "in" does not contain the prefix "in" but the word "indirectly" does.

**Bonus Round**

Please print out the most common and complex prefix of any length greater than 1, the number of times it has been seen, and the words that contain the prefix.
