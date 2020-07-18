# AudioVisual : Web API with C# and .Net Core 3.1

Comments in code are there with detailed explanation of the steps to generate a billboard.

In this exercise, I've focused on these aspects and made the following assumptions:
1. To calculate blockbuster genres for big rooms: First get the movies from the test database with more seats sold, and then get the genres from these movies.
2. To calculate minority genres: Every genre not included as a blockbuster genre, is considered as a minority genre. And then we take two random minoriry genres. 
3. I've used a light version of the builder design pattern, to create an empty billboard.
4. I've used multithreading with the Task Parallel Library, to generate movies for big rooms and small rooms simultaneously.
5. I've used an IResultFilter to adjust and set the final response object. 
6. The final response is very simple, just triplets (week, room, movie), but it's enough to get the desired result.
7. As we stated in point 2 of this list, the fact that we've taken two random minority genres, implies a different result for each execution with the same querystring.
8. On the other hand, we always get the same result for movies with blockbuster genres. This is done intentionally, so we can see different possibilities to solve the requested problem. The final result was not the priority, but the organization of the code, and the development with best practices.
9. Just developed one example of unit testing, enough to demostrate the process. To improve the unit testing, we could have worked with an InMemoryDatabase for Entity Framework, but I've decided that it was out of the scope for this exercise.
10. Another improvement could have been the use of caching policies, to cache some frequent querys to the database or to the public api. For example, it's very possible that
blockbuster genres and minority genres can be cached, to avoid calculate them for every CreateBillBoard request. As in point 9., I've decided that it was out of the scope for this exercise. 

# Setup

