# AudioVisual : Web API with C# and .Net Core 3.1
In the solution delivered, we will value aspects such as maintainable code, SOLID principles, rational use of architecture standards/patterns, organised code structure, data access patterns, exception handling, testing, logging… Or also additional documentation or diagrams you might provide.

Comments in code are there with detailed explanation of the steps to generate a billboard.

In this exercise, I've focused on these aspects and made the following assumptions:
1. To calculate blockbuster genres for big rooms: First get the movies from the test database with more seats sold, and then get the genres from these movies.
2. To calculate minority genres: Every genre not included as a blockbuster genre, is considered as a minority genre. And then we take two random minority genres. 
3. I've used a light version of the builder design pattern, to create an empty billboard.
4. I've used multithreading with the Task Parallel Library, to generate movies for big rooms and small rooms simultaneously.
5. I've used an IResultFilter to adjust and set the final response object. 
6. The final response is very simple, just triplets (week, room, movie), but it's enough to get the desired result.
7. As we stated in point 2 of this list, the fact that we've taken two random minority genres, implies a different result for each execution with the same querystring.
8. On the other hand, we always get the same result for movies with blockbuster genres. This is done intentionally, so we can see different possibilities to solve the requested problem. The final result was not the priority, but the organization of the code, and the development with best practices.
9. Just developed one example of unit testing, enough to demostrate the process. To improve the unit testing, we could have worked with an InMemoryDatabase for Entity Framework, but I've decided that it was out of the scope for this exercise.
10. Another improvement could have been the use of caching policies, to cache some frequent querys to the database or to the public api. For example, it's very possible that
blockbuster genres and minority genres can be cached, to avoid calculate them for every CreateBillBoard request. As in point 9., I've decided that it was out of the scope for this exercise.
11. I've use the appsettings.json file to get movies with a great vote_average:
 "MovieCriteria": {
    "BIG": {
      "Vote_Average": 8,
      "Vote_Count": 10
    },
    "SMALL": {
      "Vote_Average": 7,
      "Vote_Count": 0
    }
 An easy way to get different movies as a result, would be changing this movie criteria in the appsettings.json files. 
 12. I've configured logging to use Serilog with an output file Mylogs\logs\log.ndjson (in the root of the AudioVisual project).

# Setup
Just download to a local folder the zip version of this repository, and unzip at the same folder. You can open the solution in Visual Studio 2019 Community and run the tests, all of them should pass. 
If you execute the AudioVisual project, you'll be executing the request declared in launchSettings.json : 
"launchUrl": "api/managers/CreateIntelligentBillBoard?
billboardOptions.startDate=01-01-2020&billboardOptions.weeks=3&billboardOptions.BigRooms=5&billboardOptions.SmallRooms=3&billboardOptions.cityId=9"

An example of the request result would be a json object like:
{"startDate":"2020-01-01T00:00:00","endDate":"2020-01-22T00:00:00","cityId":9,"numberOfBigRooms":5,"numberOfSmallRooms":3,"numberOfMoviesForBigRooms":15,"numberOfMoviesForSmallRooms":9,"moviesForBigRooms":["[semana 1, sala 1, Avengers: Infinity War]","[semana 1, sala 2, Star Wars]","[semana 1, sala 3, Avengers: Endgame]","[semana 1, sala 4, Inception]","[semana 1, sala 5, The Lord of the Rings: The Fellowship of the Ring]","[semana 2, sala 1, Spider-Man: Into the Spider-Verse]","[semana 2, sala 2, The Lord of the Rings: The Return of the King]","[semana 2, sala 3, The Lord of the Rings: The Two Towers]","[semana 2, sala 4, Justice League Dark: Apokolips War]","[semana 2, sala 5, Mortal Kombat Legends: Scorpion's Revenge]","[semana 3, sala 1, The Empire Strikes Back]","[semana 3, sala 2, Gladiator]","[semana 3, sala 3, How to Train Your Dragon: Homecoming]","[semana 3, sala 4, My Hero Academia: Two Heroes]","[semana 3, sala 5, Steven Universe: The Movie]"],"moviesForSmallRooms":["[semana 1, sala 1, A Star Is Born]","[semana 1, sala 2, The High Note]","[semana 1, sala 3, La La Land]","[semana 2, sala 1, Walk the Line]","[semana 2, sala 2, Sing Street]","[semana 2, sala 3, Dirty Dancing]","[semana 3, sala 1, Scott Pilgrim vs. the World]","[semana 3, sala 2, Pitch Perfect]","[semana 3, sala 3, Z-O-M-B-I-E-S 2]"]}

# Performance
I've executed the CreateIntelligentBillBoard request 100 times with the Postman runner, the result is saved in the Beezy.postman_test_run.json file.
The median execution time is about 1'5 seconds.
