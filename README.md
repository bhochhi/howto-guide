# howto-guide

[Documenting](https://github.com/bhochhi/howto-guide/wiki) how to fix or solve any specific tasks or problem, whether its coding issue or operations. Should cover wide range of topics.


[Async and await]()
---
The begining of an async method is executed just like any other method. That is, it runs synchronously until it hits an "await" or throws an exception. Await is where things can get asynchronous. Await is like unary operator, it takes a single argument, an awaitable. Examines that awaitable to see if it has already completed; then the method just continues running, synhchronously just like regular method. But if awaitables are not completed yet, it waits for awaitable to complete or throw exception continue remaining of program flow. 

When method returns awaitables: Task\<T> or Task or void(don't recommend this, explained below), its saying you can await the result of such methods. Its not because method has async but it returns Task, which means you can await for the result of non-async method that returns Task. But you can't use await within such method. 

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
Well, in my opinion, its just good idea to not use aync method when you don't have to. __async__ is needed only when you need to __await__. If your method is just an intermidiatory which is just calling another async method, then just return the Task. 
```c#
public Task<int> NonAsyncMethod(){
var someService = new SomeService();
return someService.CallAync();
}
```
To support further, a tip from [Stephen Cleary](http://blog.stephencleary.com/); if you have a very simple asynchronous method, you may be able to write it without using the await keyword. If you can write it without await, then you should write it without await, and remove the async keyword from the method. A non-async method returning Task.FromResult is more efficient than an async method returning a value.
Also note that you can't return Task\<T> from non-async method. If an async method returns Task or void, there is no return value however if such method return Task\<T>, the method needs to return the type of T. 
```c#
public Task<int> NonAsyncMethod(){
.
.
return 5; //compile error, you need async method to do this.

}

 public async Task<int> Method1(){
 
 await ...
 .
 .
 return 2; // need to return integer 
 
 }
```

Alright, after knowing these basics, working on your first async/await codebase, you may ended up with two cases especially with ASP.NET as follow, else everything has gone well with you, congrats: 
  1. Everything is working, results are as expected. However it seems every tasks are running synchronously.
  2. Seems like every tasks are completed but await never seems knowing if tasks are completed. 

The root case for first senario is either you don't have __await__ in your async method. Without __await__, async method execute the method as the normal method execution. Or somewhere down the pipe, you are making a blocking call. or you have explicitly called task to run synchronously.

The second senario is a deadlock situation, which you may not like. This usually happens with UI or ASP.NET context when, Main calling method is waiting for called async method, which in turn waiting for the main context to excute the remaining of its method. Please check my [example]() repo showing such senario.

So, to prevent the deallock:
 1. use configurAwait(false) where possible inside aysnc method when it calls another async method.
 2. Don't make blocking calls within async method.

This bring us to some best practices using async and await as mentioned by [Stephen Cleary](https://msdn.microsoft.com/en-us/magazine/jj991977.aspx).

1. Avoid Async void
  Especially because of the way the exceptions are handled when using Async void. When expeception is thrown, it will be raise directly on the SynchronizationContext that was active when the async void method started. In the other hand, with async method with return type Task and Task\<T>, exceptions are captured and stored on the Return Task itself, resulting easier and simplier handling. Void returning async methods have a specific purpose: to make asynchronous event handlers possible.

2. Async all the way
 Means you shouldn't mix synchronous and asynchronous code.  Check out following ASP.NET code, async starts from controller  and continues with async calls if needed. 
  ```c#
   public class MyController:APiController
   {

     public async Task<string> Get(){
       var result = await callAnotherAsync(...);
       return result.ToString();
     }

   }
  ```
 However, thinks might not be as simple as 
    
3. Use configureAwait(false).





 [example]()
 ref: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
 https://www.youtube.com/watch?v=MCW_eJA2FeY
 
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

