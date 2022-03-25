# JapTask1

# Project Description

This is my first project in Junior acceleration program. Project is all about recipes,ingredients and prices.
 Its web application and it is easy to use so anyone can use easily use it. In this application you will be able to store your all recipes in one place,
and that will make your life easier because you wont need to waste time on finding right recipe book in your house

# Built with

This application is built with: 
* [React.js](https://reactjs.org/docs/getting-started.html)
* [Asp.net](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)

# Instructions to start application

First what we need to do is to on my  [github  account](https://github.com/krstoko/JapTask1) and copy url so we can clone project after that.
After you copied url open you [Git Bash](https://git-scm.com/download), and with command `git clone + url` we will clone project on our machine.
When git finish cloning our project we will open [visual studio](https://code.visualstudio.com/) and navigate to our project.
There are frontend folder and backend folder and we will explain what to do with each of them so dont worry.

## Frontend

Now we can navigate into our frontend folder. When you do that we will use terminal to install all packages needed for our application to work.
All you need to do is to open terminal and use command `npm install`. That will take couple of sacond and after its done, all we need to do
is to use our start command. We will do that by using `npm start`.

*Please dont start frontend untill we start our backend as well*

## Backend

For bakcend we need to install couple of thing:

* [Visual Studio](https://visualstudio.microsoft.com/)
* [PostgreSQL](https://www.postgresql.org/)

In PostgreSQL installation process, please make sure to type `password: 1234` or you can use your password but you will need to change database password in backend connection string. After you install all of that you can open Visual Studio and click on `Open Project`. On right side you will see Solution explorer and click on `Normative_Calculator.sln`.After you do that go into Visual Studio and go into Package Manager Console. You will do that by going `View > Other Windows > Package Manager Console`. After that terminal open you need to type `Update-Database` to update you local database. After all that is finish you just need to press Start button and thats it.

# Application manual

First thing you will see in our application is login screen. To successfully login into application we you will need to use this credentials

* Username: TestUser
* Password: test

After you login you will be redirected to page where you need to choose category for recipes you want to watch. After you do that you will be redirected to page with all recipes from that category. Every recipe has price and name and they will be orderd from lowest price to highest. You have option to load more recipes if there are any. You can sarch recipes by name and ingredient name as well.
If you click on one recipe, you will be redirected on page with all deatils about that recipe you picked. And last feature is adding our recipe.
To add recipe you have button in header. When you click it you will se form for adding recipe. Remamber that every field is required and that you cant add recipe without single ingredient. One more thing to know, if ingredient measure value is in litres you cant transform and add that ingrediants in kilograms.

