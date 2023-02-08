# CarsChallenge
Cars Site Chellange 

In this project maybe I used more functionalities that it needed. But I try to show how I use to working.
I created a Controller called CarController to allows receive request from the frontside. But, for the logic of the bussiness, I created a Service (service layer) called CarService that manages the logic of the CRUD operations. And Also I created a Data layer, called CarRepository, that manage the push, pop and edit in the car list. In all this layers, I used the dependency injection pattern.
In the front I user Razor for display the model information, and Jquery and sweetalert for the guess functionality.

Also create a Test Project with a little mocks of some functionalities.
