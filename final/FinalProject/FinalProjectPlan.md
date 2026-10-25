# W05 Prepare: Final Project Plan

**Project option: Foundation 4**

The project options are the open-ended project and Foundation 4. I choose the Foundation 4 project option, because it consists of four programs that each use one of the principles of Programming with Classes.

**Program 1 (Abstraction, YouTube Videos):** This program stores information about YouTube videos and the comments on them. The Video class stores the title, author, video length in seconds and a list of comments, and can return its number of comments. The Comment class stores the name of the comment author and the comment text. The program creates several Video objects with Comment objects, saves them in a list, and outputs the information about each video and all of its comments.

**Program 2 (Encapsulation, Online Ordering):** This program handles product orders for an online company using Product, Customer, Address and Order classes, in which all member variables are private. The Order calculates the total cost using the price of each product, its quantity and the shipping cost ($5 in the USA, $35 elsewhere). It produces a packing label with information about the products and a shipping label with the customer's name and address.

**Program 3 (Inheritance, Event Planning):** This program tracks events for an event planning company using a base Event class (title, description, date, time and an Address class) and derived classes for lectures, receptions and outdoor gatherings. Each type of event has its own additional information, such as the speaker and capacity, an RSVP email, or the weather forecast. Each event can also create a standard details message, a full details message and a short description.

**Program 4 (Polymorphism, Exercise Tracking):** This program tracks exercise for a fitness center using a base Activity class (date and length in minutes) and derived classes for running, cycling and swimming. Each derived class overrides the methods that calculate distance, speed and pace. The program stores one object of each derived class in the same list and calls the GetSummary method on each object.
