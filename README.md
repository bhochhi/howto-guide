# howto-guide

[Documenting](https://github.com/bhochhi/howto-guide/wiki) how to fix or solve any specific tasks or problem, whether its coding issue or operations. Should cover wide range of topics.

[How CORS works](http://www.html5rocks.com/en/tutorials/cors/)

[How to use Regex? Show with example.]()

Recently, I have to write validation logic in javascript to check if the given string matches a specified criteria. The best way to do was to represent such criteria in regular expression. For instance, let say we want to validate the input string __value__. A __value__ is a time(hr:min) or time frame(hr-hr). Following are valid inputs: 8, 8am, 8pm, 8:30, 8:30am, 8-9, 8am-9am, 8:30-9, 11:30am-1pm, 11-12pm. So, the specified criteria are:
   1. Single digit or two digits from 1 to 12.
   2. Digit suffix either with "am" or "pm" 
   3. Digit suffix with ":[00 to 59]"
   4. Two digits following rules 1/2/3  separated by hypen.

Here is the regex that matches given criteria:  __/^((1[0-2]|0?[0-9])(:[0-5][0-9])?(am|pm)?)(-((1[0-2]|0?[0-9])(:[0-5][0-9])?(am|pm)?))?$/__
 
[ref](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Regular_Expressions)

[Async and Await](https://github.com/bhochhi/howto-guide/wiki/Async-and-Await)

[Troubleshooting using jmap](https://github.com/bhochhi/howto-guide/wiki/Troubleshooting-using-jmap)

[JNDI](https://github.com/bhochhi/howto-guide/wiki/JNDI)

[Enterprise JavaBeans](https://github.com/bhochhi/howto-guide/wiki/Enterprise-JavaBeans)

[Git vs Bare Git repository ](http://www.saintsjd.com/2011/01/what-is-a-bare-git-repository/);

[xclip]()

[How to map custom domain to app in heroku.](https://github.com/bhochhi/howto-guide/wiki/JNDI)

[How to build a plugin?,ex for eclipse]()

[Building Scalable Web Architecture and Distributed Systems](http://www.drdobbs.com/web-development/building-scalable-web-architecture-and-d/240142422)

Various db mapping mechanisms and examples for java applications

