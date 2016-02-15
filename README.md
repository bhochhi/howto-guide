# howto-guide

[Documenting](https://github.com/bhochhi/howto-guide/wiki) how to fix or solve any specific tasks or problem, whether its coding issue or operations. Should cover wide range of topics.


[Async and await]()
---
The begining of an async method is executed just like any other method. That is, it runs synchronously until it hits an "await" or throws an exception. Await is where things can get asynchronous. Await is like unary operator, it takes a single argument, an awaitable. Examines that awaitable to see if it has already completed; then the method just continues running, synhchronously just like regular method. But if awaitables are not completed yet, it waits for awaitable to complete or throw exception continue remaining of program flow. 

When method returns awaitables: Task```<T>``` or Task or void(don't recommend this), its saying you can await the result of such methods. Its not because method has async but it returns Task, which means you can await for the result of non-async method that returns Task. But you can't use await within such method. 

```c#
public async Task Method1(){

//you can use await here.
await...

}

public Task Method2{

 //you can't use await here. 
 
 
}



```

So, what is the benefit of using non-async method that returns a Task?

A tip from [Stephen Cleary](http://blog.stephencleary.com/); if you have a very simple asynchronous method, you may be able to write it without using the await keyword. If you can write it without await, then you should write it without await, and remove the async keyword from the method. A non-async method returning Task.FromResult is more efficient than an async method returning a value.

If an async method returns Task or void, there is no return value however if such method return Task<T>, the method needs to return the type of T. 
```c#
 public async Task<int> Method1(){
 
 await ...
 .
 .
 return 2; // need to return integer 
 
 }
```

__Context__





* Avoid Async void
  Especially because of the way the exceptions are handled when using Async void. When expeception is thrown, it will be raise directly on the SynchronizationContext that was active when the async void method started. In the other hand, with async method with return type Task and Task<T>, exceptions are captured and stored on the Return Task itself, resulting easier and simplier handling.
  Void returning async methods have a specific purpose: to make asynchronous event handlers possible.

* Async all the way



 ref: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
 http://blog.stephencleary.com/2012/02/async-and-await.html
 http://blog.stephencleary.com/2012/07/dont-block-on-async-code.html

[Troubleshooting using jmap](https://github.com/bhochhi/howto-guide/wiki/Troubleshooting-using-jmap)

[JNDI](https://github.com/bhochhi/howto-guide/wiki/JNDI)

[Enterprise JavaBeans](https://github.com/bhochhi/howto-guide/wiki/Enterprise-JavaBeans)

[Git vs Bare Git repository ](http://www.saintsjd.com/2011/01/what-is-a-bare-git-repository/);

[How maven works?](https://github.com/bhochhi/howto-guide/wiki/How-maven-works%3F)

[xclip]()

[How to map custom domain to app in heroku.](https://github.com/bhochhi/howto-guide/wiki/JNDI)

[How Maven work?](https://github.com/bhochhi/howto-guide/wiki/How-maven-works%3F)

[How maven resolve the dependency conflict, any difference with npm?]()

[How to build a plugin?,ex for eclipse]()

[Building Scalable Web Architecture and Distributed Systems](http://www.drdobbs.com/web-development/building-scalable-web-architecture-and-d/240142422)

Various db mapping mechanisms and examples for java applications

